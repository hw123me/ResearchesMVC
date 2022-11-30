#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResearchesMVC.Areas.Identity.Data;
using ResearchesMVC.Models;

namespace ResearchesMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ImagesController : Controller
    {
        private readonly ApplictionDbContext _context;
        private readonly IWebHostEnvironment hosting;
        public ImagesController(ApplictionDbContext context, IWebHostEnvironment hosting)
        {
            _context = context;
            this.hosting = hosting;
        }

        // GET: Admin/Images
        public async Task<IActionResult> Index()
        {
            return View(await _context.Images.ToListAsync());
        }

        // GET: Admin/Images/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var image = await _context.Images
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (image == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(image);
        //}

        // GET: Admin/Images/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Images/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Image image)
        {
            if (ModelState.IsValid)
            {
                int ExitData = _context.Images.Count();
                if(ExitData > 0)
                {
                    ModelState.AddModelError("", "لا يمكن اضافة بيانات جديدة, قم بتعدبل البيانات الموجودة");
                    return View(image);
                }
                if (image.SignImage != null)
                {
                    if (image.SignImage.Length > 5242880)
                    {
                        ModelState.AddModelError("", "لا يمكن رفع صورة أكبر من 5 ميجابايت");
                        return View(image);
                    }
                    var fileName = Path.GetFileName(image.SignImage.FileName);
                    //judge if it is pdf file
                    string ext = Path.GetExtension(image.SignImage.FileName);

                    if (ext.ToLower() != ".jpg" && ext.ToLower() != ".jpeg" && ext.ToLower() != ".png")
                    {
                        ModelState.AddModelError("", "ارفع صورة من نوع jpg أو png");
                        return View(image);
                    }
                    string filefolder = Path.Combine(this.hosting.WebRootPath, "Images");
                    string filepath = Path.Combine(filefolder, image.SignImage.FileName);
                    image.SignImage.CopyTo(new FileStream(filepath, FileMode.Create));
                    image.SignImageUrl = image.SignImage.FileName;
                }
                _context.Add(image);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(image);
        }

        // GET: Admin/Images/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Images.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }
            return View(image);
        }

        // POST: Admin/Images/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Image image)
        {
            if (id != image.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (image.SignImage != null)
                {
                    if (image.SignImage.Length > 5242880)
                    {
                        ModelState.AddModelError("", "لا يمكن رفع صورة أكبر من 5 ميجابايت");
                        return View(image);
                    }
                    var fileName = Path.GetFileName(image.SignImage.FileName);
                    //judge if it is pdf file
                    string ext = Path.GetExtension(image.SignImage.FileName);

                    if (ext.ToLower() != ".png" && ext.ToLower() != ".jpg" && ext.ToLower() != ".jpeg")
                    {
                        ModelState.AddModelError("", "ارفع صورة من نوع jpg أو png");
                        return View(image);
                    }
                    string filefolder = Path.Combine(this.hosting.WebRootPath, "Images");
                    string filepath = Path.Combine(filefolder, image.SignImage.FileName);

                    //System.IO.File.Delete(fullOldPath);
                    image.SignImage.CopyTo(new FileStream(filepath, FileMode.Create));
                    //}



                    image.SignImageUrl = image.SignImage.FileName;
                }
                try
                {
                    _context.Update(image);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageExists(image.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(image);
        }

        // GET: Admin/Images/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var image = await _context.Images
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (image == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(image);
        //}

        //// POST: Admin/Images/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var image = await _context.Images.FindAsync(id);
        //    _context.Images.Remove(image);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool ImageExists(int id)
        {
            return _context.Images.Any(e => e.Id == id);
        }
    }
}
