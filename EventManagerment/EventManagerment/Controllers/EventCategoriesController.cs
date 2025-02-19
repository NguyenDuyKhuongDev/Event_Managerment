using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventManagerment.DBContext;
using EventManagerment.Models;

namespace EventManagerment.Controllers
{
    public class EventCategoriesController : Controller
    {
        private readonly AppDBContext _context;

        public EventCategoriesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: EventCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.EventCategories.ToListAsync());
        }

        // GET: EventCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventCategories = await _context.EventCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (eventCategories == null)
            {
                return NotFound();
            }

            return View(eventCategories);
        }

        // GET: EventCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName")] EventCategories eventCategories)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventCategories);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventCategories);
        }

        // GET: EventCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventCategories = await _context.EventCategories.FindAsync(id);
            if (eventCategories == null)
            {
                return NotFound();
            }
            return View(eventCategories);
        }

        // POST: EventCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,CategoryName")] EventCategories eventCategories)
        {
            if (id != eventCategories.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventCategories);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventCategoriesExists(eventCategories.CategoryId))
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
            return View(eventCategories);
        }

        // GET: EventCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventCategories = await _context.EventCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (eventCategories == null)
            {
                return NotFound();
            }

            return View(eventCategories);
        }

        // POST: EventCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventCategories = await _context.EventCategories.FindAsync(id);
            if (eventCategories != null)
            {
                _context.EventCategories.Remove(eventCategories);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventCategoriesExists(int id)
        {
            return _context.EventCategories.Any(e => e.CategoryId == id);
        }
    }
}
