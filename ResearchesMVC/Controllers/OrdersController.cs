#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResearchesMVC.Areas.Identity.Data;
using ResearchesMVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Reporting.NETCore;
using System.Data;
using System.Data.SqlClient;
using ResearchesMVC.Models.ViewModel;
using ResearchesMVC.Services;

namespace ResearchesMVC.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly ApplictionDbContext _context;
        private readonly IWebHostEnvironment hosting;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrdersController(ApplictionDbContext context, IWebHostEnvironment hosting, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.hosting = hosting;
            _userManager = userManager;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var applictionDbContext = _context.Orders.Include(o => o.User)
                                        .Include(s => s.Status)
                                       .Where(u => u.User.Id == userId);
            //var applictionDbContext = _context.Orders.Include(o => o.User);
            return View(await applictionDbContext.ToListAsync());
        }

        public async Task<IActionResult> ViewReport(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(x => x.Tools).ThenInclude(y => y.StudyTool)
                .Include(x => x.Samples).ThenInclude(y => y.StudySample)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            OrderViewModel vm = new OrderViewModel();
            var toside = vm.ToSide.Select(x => new SelectListItem()
            {
                Text = x.Text,
                Value = x.Value.ToString(),
            }).ToList();


            // OrderViewModel vm2 = new OrderViewModel();
            vm.ToSide = toside;
            vm.Id = order.Id;
            vm.UserId = order.UserId;

            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ViewReport(OrderViewModel vm)
        {
            var selectedTools = vm.ToSide.Where(x => x.Selected).Select(y => y.Value).ToList();
            string allstring = "";
            if (selectedTools.Count == 0)
            {
                TempData["error"] = "يرجى اختيار الجهة";
                return RedirectToAction("ViewReport", new { id = vm.Id });
            }
            foreach (var item in selectedTools)
            {
                if (item == "المدير العام" || item == "مساعد/ة المدير العام للشؤون التعليمية" || item == "مساعد/ة المدير العام للشؤون المدرسية")
                {
                    allstring += "سعادة: " + "" + item + System.Environment.NewLine;
                }
                if (item == "مدير/ة مكتب")
                {
                    if (vm.OfficeAdmin == null)
                    {
                        TempData["error"] = "يرجى كتابة اسم المكتب";
                        return RedirectToAction("ViewReport", new { id = vm.Id });
                    }
                    allstring += "المكرم مدير/ة مكتب: " + "" + vm.OfficeAdmin + System.Environment.NewLine;
                }
                if (item == "مدير/ة إدارة")
                {
                    if (vm.OrgAdmin == null)
                    {
                        TempData["error"] = "يرجى كتابة اسم مدير/ة الإدارة";
                        return RedirectToAction("ViewReport", new { id = vm.Id });
                    }
                    allstring += "المكرم مدير/ة إدارة: " + "" + vm.OrgAdmin + System.Environment.NewLine;
                }
                if (item == "رئيس/ة قسم")
                {
                    if (vm.SectionAdmin == null)
                    {
                        TempData["error"] = "يرجى كتابة اسم رئيس/ة القسم";
                        return RedirectToAction("ViewReport", new { id = vm.Id });
                    }
                    allstring += "المكرم رئيس/ة قسم: " + "" + vm.SectionAdmin + System.Environment.NewLine;
                }
                if (item == "مدير/ة مدرسة")
                {
                    if (vm.SchoolAdmin == null)
                    {
                        TempData["error"] = "يرجى كتابة اسم مدير/ة المدرسة";
                        return RedirectToAction("ViewReport", new { id = vm.Id });
                    }
                    allstring += "المكرم مدير/ة مدرسة: " + "" + vm.SchoolAdmin + System.Environment.NewLine;
                }

            }

            //ViewData["ToList"] = names;

            return RedirectToAction("Print2", new { id = vm.Id, to = allstring });
        }

        public IActionResult Print2(int? id, string to)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Status = _context.Orders.SingleOrDefault(u => u.Id == id);
            var StatusId = Status.StatusId;
            if (StatusId != 5)
            {
                return NotFound();
            }

            var order = _context.Orders
                 .Include(o => o.User)
                 .FirstOrDefaultAsync(m => m.Id == id);


            if (order == null)
            {
                return NotFound();
            }


            //استخراج اسم الباحث
            // var userName = User.FindFirstValue(ClaimTypes.Name);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return NotFound();
            }
            ApplicationUser user = _context.Users.SingleOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return NotFound();
            }
            string name = user.FullName;

            //استخراج اسم مدير التعليم
            string AdminName = _context.Images.Select(a => a.AdminName).SingleOrDefault();
            string SignUrl = _context.Images.Select(a => a.SignImageUrl).SingleOrDefault();

            string reportName = "OrderReport";

            string reportPath = Path.Combine(hosting.WebRootPath, "Reports", "OrderReport.rdlc");

            Stream reportDefinition;

            using var fs = new FileStream(reportPath, FileMode.Open);
            reportDefinition = fs;
            LocalReport report = new LocalReport();
            report.LoadReportDefinition(reportDefinition);

            report.EnableExternalImages = true;


            string filefolder = Path.Combine(this.hosting.WebRootPath, "Images");
            string imagePath = Path.Combine(filefolder, SignUrl);

            var data = _context.Orders.Include(o => o.User)
                                      .Where(c => c.Id == id);

            //أدوات الدراسة
            var orderTools = _context.OrderTools.Where(x => x.OrderId == id).Include(y => y.StudyTool).ToList();
            string t = "";
            if (orderTools != null)
            {
                foreach (var item in orderTools)
                {
                    t += item.StudyTool.ToolName + " - ";
                }
            }
            //عينة الدراسة
            var orderSamples = _context.OrderSamples.Where(x => x.OrderId == id).Include(y => y.StudySample).ToList();
            string s = "";
            if (orderSamples != null)
            {
                foreach (var item in orderSamples)
                {
                    s += item.StudySample.SampleName + " - ";
                }
            }

            ReportDataSource datasource = new ReportDataSource("DataSet1", data);
            report.DataSources.Add(datasource);

            report.SetParameters(new[] {
                new ReportParameter("prm", "الموضوع: تسهيل مهمة باحث "),
                new ReportParameter("prm2",name.ToString()),
                new ReportParameter("prm3",AdminName),
                new ReportParameter("imagepath",imagePath),
                new ReportParameter("to",to),
                new ReportParameter("tools",t),
                new ReportParameter("samples",s),
            });

            byte[] pdf = report.Render("PDF");
            fs.Dispose();

            return File(pdf, "application/pdf", reportName + ".pdf");

        }


        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(x => x.Tools).ThenInclude(y => y.StudyTool)
                .Include(x => x.Samples).ThenInclude(y => y.StudySample)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Name");
            var studyTools = _context.StudyTools.Select(x => new SelectListItem()
            {
                Text = x.ToolName,
                Value = x.Id.ToString(),
            }).ToList();

            var studySamples = _context.StudySamples.Select(x => new SelectListItem()
            {
                Text = x.SampleName,
                Value = x.Id.ToString(),
            }).ToList();

            OrderViewModel vm = new OrderViewModel();
            vm.StudyTools = studyTools;
            vm.StudySamples = studySamples;

            return View(vm);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]


        public IActionResult Create(OrderViewModel vm)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (vm.ToolsPdf != null)
            {
                if (vm.ToolsPdf.Length > 5242880)
                {
                    ModelState.AddModelError("", "لا يمكن رفع ملف أكبر من 5 ميجابايت");
                    return View(vm);
                }

                var fileName = Path.GetFileName(vm.ToolsPdf.FileName);

                //judge if it is pdf file
                string ext = Path.GetExtension(vm.ToolsPdf.FileName);
                fileName = DateTime.Now.Ticks + ext;

                if (ext.ToLower() != ".pdf")
                {
                    ModelState.AddModelError("", "ارفع ملف من نوع pdf");
                    return View(vm);
                }

                string filefolder = Path.Combine(this.hosting.WebRootPath, "uploads");
                //  string filepath = Path.Combine(filefolder, vm.ToolsPdf.FileName);
                string filepath = Path.Combine(filefolder, fileName);
                vm.ToolsPdf.CopyTo(new FileStream(filepath, FileMode.Create));

                vm.ToolsPdfUrl = vm.ToolsPdf.FileName;
            }
            var order = new Order
            {
                UserId = userId,
                Uneviersity = vm.Uneviersity,
                City_Univ = vm.City_Univ,
                College = vm.College,
                Section = vm.Section,
                Specialize = vm.Specialize,
                StudyTitle = vm.StudyTitle,
                Goal = vm.Goal,
                ToolsPdfUrl = vm.ToolsPdfUrl,
                School_Type = vm.School_Type,
                Term_Year = vm.Term_Year,
                Term = vm.Term,
                StatusId = vm.StatusId,
                Active = true,
                Notes = vm.Notes,
                CreatedOn = DateTime.Now

            };
            var selectedTools = vm.StudyTools.Where(x => x.Selected).Select(y => y.Value).ToList();
            foreach (var item in selectedTools)
            {
                order.Tools.Add(new OrderTool()
                {
                    StudyToolId = int.Parse(item)
                });
            }
            var selectedSamples = vm.StudySamples.Where(x => x.Selected).Select(y => y.Value).ToList();
            foreach (var item in selectedSamples)
            {
                order.Samples.Add(new OrderSample()
                {
                    StudySampleId = int.Parse(item)
                });
            }
            _context.Orders.Add(order);
            _context.SaveChanges();

            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Name");
            return RedirectToAction("Index");




            //if (ModelState.IsValid)
            //{
            //    //عدم تكرار الطلب
            //    var exitorder = _context.Orders.Any(x => x.UserId == userId && x.Term == order.Term && x.Term_Year == order.Term_Year);
            //    if (exitorder)
            //    {
            //        ModelState.AddModelError("", "يوجد طلب سابق");
            //        TempData["error"] = "يوجد طلب سابق";
            //        return View(order);
            //    }

            //    if (order.ToolsPdf != null)
            //    {
            //        if (order.ToolsPdf.Length > 5242880)
            //        {
            //            ModelState.AddModelError("", "لا يمكن رفع ملف أكبر من 5 ميجابايت");
            //            return View(order);
            //        }

            //        var fileName = Path.GetFileName(order.ToolsPdf.FileName);
            //        //judge if it is pdf file
            //        string ext = Path.GetExtension(order.ToolsPdf.FileName);

            //        if (ext.ToLower() != ".pdf")
            //        {
            //            ModelState.AddModelError("", "ارفع ملف من نوع pdf");
            //            return View(order);
            //        }
            //        string filefolder = Path.Combine(this.hosting.WebRootPath, "uploads");
            //        string filepath = Path.Combine(filefolder, order.ToolsPdf.FileName);
            //        order.ToolsPdf.CopyTo(new FileStream(filepath, FileMode.Create));
            //        order.ToolsPdfUrl = order.ToolsPdf.FileName;
            //    }

            //    order.UserId = userId;
            //    order.StatusId = 1;
            //    order.Active = true;
            //    order.Notes = "";
            //    order.CreatedOn = DateTime.Now;

            //    _context.Add(order);
            //    await _context.SaveChangesAsync();

            //    OrderTool orderTool = new OrderTool();

            //    TempData["success"] = "تم إرسال الطلب بنجاح";
            //    return RedirectToAction(nameof(Index));

            //}




        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var order = await _context.Orders.Include(x => x.Tools).Include(x => x.Samples).Where(y => y.Id == id).FirstOrDefaultAsync();
            if (order == null)
            {
                return NotFound();
            }
            var selectedIds = order.Tools.Select(x => x.StudyToolId).ToList();
            var items = _context.StudyTools.Select(x => new SelectListItem()
            {
                Text = x.ToolName,
                Value = x.Id.ToString(),
                Selected = selectedIds.Contains(x.Id)
            }).ToList();

            var selectedIdsSamples = order.Samples.Select(x => x.StudySampleId).ToList();
            var itemsSamples = _context.StudySamples.Select(x => new SelectListItem()
            {
                Text = x.SampleName,
                Value = x.Id.ToString(),
                Selected = selectedIdsSamples.Contains(x.Id)
            }).ToList();

            OrderViewModel vm = new OrderViewModel();

            vm.Uneviersity = order.Uneviersity;
            vm.City_Univ = order.City_Univ;
            vm.College = order.College;
            vm.Section = order.Section;
            vm.Specialize = order.Specialize;
            vm.StudyTitle = order.StudyTitle;
            vm.Goal = order.Goal;
            vm.ToolsPdfUrl = order.ToolsPdfUrl;
            vm.School_Type = order.School_Type;
            vm.Term_Year = order.Term_Year;
            vm.Term = order.Term;
            vm.StatusId = order.StatusId;
            vm.Active = order.Active;
            vm.Notes = order.Notes;
            vm.CreatedOn = order.CreatedOn;

            vm.StudyTools = items;
            vm.StudySamples = itemsSamples;

            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", order.UserId);

            return View(vm);


        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OrderViewModel vm)
        {
            var order = _context.Orders.Find(vm.Id);
            if (order == null)
            {
                return NotFound();
            }

            var StatusId = order.StatusId;
            if (StatusId == 4)
            {
                order.StatusId = 1;
            }

            order.Uneviersity = vm.Uneviersity;
            order.City_Univ = vm.City_Univ;
            order.College = vm.College;
            order.Section = vm.Section;
            order.Specialize = vm.Specialize;
            order.StudyTitle = vm.StudyTitle;
            order.Goal = vm.Goal;
            order.ToolsPdfUrl = vm.ToolsPdfUrl;
            order.School_Type = vm.School_Type;
            order.Term_Year = vm.Term_Year;
            order.Term = vm.Term;
            //  order.StatusId = vm.StatusId;
            order.Active = vm.Active;
            order.Notes = vm.Notes;
            order.CreatedOn = vm.CreatedOn;

            if (vm.ToolsPdf != null)
            {
                var fileName = Path.GetFileName(vm.ToolsPdf.FileName);
                //judge if it is pdf file
                string ext = Path.GetExtension(vm.ToolsPdf.FileName);

                if (ext.ToLower() != ".pdf")
                {
                    ModelState.AddModelError("", "ارفع ملف من نوع pdf");
                    return View(vm);
                }
                string filefolder = Path.Combine(this.hosting.WebRootPath, "uploads");
                string filepath = Path.Combine(filefolder, vm.ToolsPdf.FileName);


                vm.ToolsPdf.CopyTo(new FileStream(filepath, FileMode.Create));

                vm.ToolsPdfUrl = vm.ToolsPdf.FileName;

                //تخزين الاسم الجديد
                order.ToolsPdfUrl = vm.ToolsPdf.FileName;
            }





            var orderById = _context.Orders.Include(x => x.Tools).Include(x => x.Samples).FirstOrDefault(y => y.Id == vm.Id);

            var existingIds = orderById.Tools.Select(x => x.StudyToolId).ToList();
            var selectedIds = vm.StudyTools.Where(x => x.Selected).Select(y => y.Value).Select(int.Parse).ToList();
            var toAdd = selectedIds.Except(existingIds);
            var toRemove = existingIds.Except(selectedIds);
            order.Tools = order.Tools.Where(x => !toRemove.Contains(x.StudyToolId)).ToList();

            foreach (var item in toAdd)
            {
                order.Tools.Add(new OrderTool()
                {
                    StudyToolId = item
                });
            }

            var existingIds2 = orderById.Samples.Select(x => x.StudySampleId).ToList();
            var selectedIds2 = vm.StudySamples.Where(x => x.Selected).Select(y => y.Value).Select(int.Parse).ToList();
            var toAdd2 = selectedIds2.Except(existingIds2);
            var toRemove2 = existingIds2.Except(selectedIds2);
            order.Samples = order.Samples.Where(x => !toRemove2.Contains(x.StudySampleId)).ToList();

            foreach (var item in toAdd2)
            {
                order.Samples.Add(new OrderSample()
                {
                    StudySampleId = item
                });
            }

            _context.Orders.Update(order);
            _context.SaveChanges();
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", order.UserId);
            return RedirectToAction(nameof(Index));


        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }

        // Download file from the server
        public async Task<IActionResult> Download(string filename)
        {
            if (filename == null)
                return Content("filename is not availble");

            string filefolder = Path.Combine(this.hosting.WebRootPath, "uploads");
            string path = Path.Combine(filefolder, filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }
        // Get content type
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }
        // Get mime types
        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
    {
        {".txt", "text/plain"},
        {".pdf", "application/pdf"},
        {".doc", "application/vnd.ms-word"},
        {".docx", "application/vnd.ms-word"},
        {".xls", "application/vnd.ms-excel"},
        {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
        {".png", "image/png"},
        {".jpg", "image/jpeg"},
        {".jpeg", "image/jpeg"},
        {".gif", "image/gif"},
        {".csv", "text/csv"}
    };
        }





    }
}
