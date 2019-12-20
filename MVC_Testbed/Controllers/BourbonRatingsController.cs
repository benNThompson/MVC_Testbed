using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Testbed.Data;
using MVC_Testbed.Models;

namespace MVC_Testbed.Views
{
    public class BourbonRatingsController : Controller
    {
        private readonly MvcTestbedContext _context;

        public BourbonRatingsController(MvcTestbedContext context)
        {
            _context = context;
        }

        // GET: BourbonRatings
        public async Task<IActionResult> Index()
        {
            var mvcTestbedContext = _context.BourbonRatings.Include(b => b.Bourbon);
            return View(await mvcTestbedContext.ToListAsync());
        }

        // GET: BourbonRatings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bourbonRating = await _context.BourbonRatings
                .Include(b => b.Bourbon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bourbonRating == null)
            {
                return NotFound();
            }

            return View(bourbonRating);
        }

        // GET: BourbonRatings/Create
        public IActionResult Create()
        {
            ViewData["Bourbon"] = new SelectList(_context.Bourbons, "Id", "Name");
            return View();
        }

        // POST: BourbonRatings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BourbonId,Rating,TastingDate")] BourbonRating bourbonRating)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bourbonRating);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Bourbon"] = new SelectList(_context.Bourbons, "Id", "Name", bourbonRating.BourbonId);
            return View(bourbonRating);
        }

        // GET: BourbonRatings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bourbonRating = await _context.BourbonRatings.FindAsync(id);
            if (bourbonRating == null)
            {
                return NotFound();
            }
            ViewData["Bourbon"] = new SelectList(_context.Bourbons, "Id", "Name", bourbonRating.BourbonId);
            return View(bourbonRating);
        }

        // POST: BourbonRatings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BourbonId,Rating,TastingDate")] BourbonRating bourbonRating)
        {
            if (id != bourbonRating.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bourbonRating);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BourbonRatingExists(bourbonRating.Id))
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
            ViewData["Bourbon"] = new SelectList(_context.Bourbons, "Id", "Name", bourbonRating.BourbonId);
            return View(bourbonRating);
        }

        // GET: BourbonRatings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bourbonRating = await _context.BourbonRatings
                .Include(b => b.Bourbon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bourbonRating == null)
            {
                return NotFound();
            }

            return View(bourbonRating);
        }

        // POST: BourbonRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bourbonRating = await _context.BourbonRatings.FindAsync(id);
            _context.BourbonRatings.Remove(bourbonRating);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BourbonRatingExists(int id)
        {
            return _context.BourbonRatings.Any(e => e.Id == id);
        }
    }
}
