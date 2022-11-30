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
    public class StudyToolsController : Controller
    {
        private readonly ApplictionDbContext _context;

        public StudyToolsController(ApplictionDbContext context)
        {
            _context = context;
        }

        // GET: Admin/StudyTools
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudyTools.ToListAsync());
        }

        // GET: Admin/StudyTools/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyTool = await _context.StudyTools
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studyTool == null)
            {
                return NotFound();
            }

            return View(studyTool);
        }

        // GET: Admin/StudyTools/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/StudyTools/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ToolName")] StudyTool studyTool)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studyTool);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studyTool);
        }

        // GET: Admin/StudyTools/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyTool = await _context.StudyTools.FindAsync(id);
            if (studyTool == null)
            {
                return NotFound();
            }
            return View(studyTool);
        }

        // POST: Admin/StudyTools/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ToolName")] StudyTool studyTool)
        {
            if (id != studyTool.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studyTool);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudyToolExists(studyTool.Id))
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
            return View(studyTool);
        }

        // GET: Admin/StudyTools/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyTool = await _context.StudyTools
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studyTool == null)
            {
                return NotFound();
            }

            return View(studyTool);
        }

        // POST: Admin/StudyTools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studyTool = await _context.StudyTools.FindAsync(id);
            _context.StudyTools.Remove(studyTool);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudyToolExists(int id)
        {
            return _context.StudyTools.Any(e => e.Id == id);
        }
    }
}
