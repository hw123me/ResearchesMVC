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
    public class StudySamplesController : Controller
    {
        private readonly ApplictionDbContext _context;

        public StudySamplesController(ApplictionDbContext context)
        {
            _context = context;
        }

        // GET: Admin/StudySamples
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudySamples.ToListAsync());
        }

        // GET: Admin/StudySamples/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studySample = await _context.StudySamples
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studySample == null)
            {
                return NotFound();
            }

            return View(studySample);
        }

        // GET: Admin/StudySamples/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/StudySamples/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SampleName")] StudySample studySample)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studySample);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studySample);
        }

        // GET: Admin/StudySamples/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studySample = await _context.StudySamples.FindAsync(id);
            if (studySample == null)
            {
                return NotFound();
            }
            return View(studySample);
        }

        // POST: Admin/StudySamples/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SampleName")] StudySample studySample)
        {
            if (id != studySample.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studySample);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudySampleExists(studySample.Id))
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
            return View(studySample);
        }

        // GET: Admin/StudySamples/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studySample = await _context.StudySamples
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studySample == null)
            {
                return NotFound();
            }

            return View(studySample);
        }

        // POST: Admin/StudySamples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studySample = await _context.StudySamples.FindAsync(id);
            _context.StudySamples.Remove(studySample);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudySampleExists(int id)
        {
            return _context.StudySamples.Any(e => e.Id == id);
        }
    }
}
