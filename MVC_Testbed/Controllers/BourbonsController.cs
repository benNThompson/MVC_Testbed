using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Testbed.Data;
using MVC_Testbed.Models;

namespace MVC_Testbed.Controllers
{
    public class BourbonsController : Controller
    {
        private readonly MvcTestbedContext _context;

        public BourbonsController(MvcTestbedContext context)
        {
            _context = context;
        }

        // GET: Bourbons
        public async Task<IActionResult> Index()
        {
            var mvcTestbedContext = _context.Bourbons.Include(b => b.Distillery);
            return View(await mvcTestbedContext.ToListAsync());
        }

        public async Task<IActionResult> ApiIndex()
        {
            return View();
        }

        // GET: Bourbons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bourbon = await _context.Bourbons
                .Include(b => b.Distillery)
                .Include(b => b.Ratings)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bourbon == null)
            {
                return NotFound();
            }

            ViewData["AverageRating"] = bourbon.Ratings.Any() ? bourbon.Ratings.Average(r => r.Rating).ToString() : "No ratings";

            return View(bourbon);
        }

        // GET: Bourbons/Create
        public IActionResult Create()
        {
            ViewData["DistilleryId"] = new SelectList(_context.Distilleries, "Id", "Name");
            return View();
        }

        // POST: Bourbons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DistilleryId")] Bourbon bourbon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bourbon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DistilleryId"] = new SelectList(_context.Distilleries, "Id", "Id", bourbon.DistilleryId);
            return View(bourbon);
        }

        // GET: Bourbons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bourbon = await _context.Bourbons.FindAsync(id);
            if (bourbon == null)
            {
                return NotFound();
            }
            ViewData["Distillery"] = new SelectList(_context.Distilleries, "Id", "Name", bourbon.DistilleryId);
            return View(bourbon);
        }

        // POST: Bourbons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DistilleryId")] Bourbon bourbon)
        {
            if (id != bourbon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bourbon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BourbonExists(bourbon.Id))
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
            ViewData["DistilleryId"] = new SelectList(_context.Distilleries, "Id", "Id", bourbon.DistilleryId);
            return View(bourbon);
        }

        // GET: Bourbons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bourbon = await _context.Bourbons
                .Include(b => b.Distillery)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bourbon == null)
            {
                return NotFound();
            }

            return View(bourbon);
        }

        // POST: Bourbons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bourbon = await _context.Bourbons.FindAsync(id);
            _context.Bourbons.Remove(bourbon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BourbonExists(int id)
        {
            return _context.Bourbons.Any(e => e.Id == id);
        }
    }
}
