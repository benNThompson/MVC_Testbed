using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Testbed.Data;
using MVC_Testbed.Models;

namespace MVC_Testbed.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistilleriesApiController : ControllerBase
    {
        private readonly MvcTestbedContext _context;

        public DistilleriesApiController(MvcTestbedContext context)
        {
            _context = context;
        }

        // GET: api/DistilleriesApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Distillery>>> GetDistilleries()
        {
            return await _context.Distilleries.ToListAsync();
        }

        // GET: api/DistilleriesApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Distillery>> GetDistillery(int id)
        {
            var distillery = await _context.Distilleries.FindAsync(id);

            if (distillery == null)
            {
                return NotFound();
            }

            return distillery;
        }

        // PUT: api/DistilleriesApi/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDistillery(int id, Distillery distillery)
        {
            if (id != distillery.Id)
            {
                return BadRequest();
            }

            _context.Entry(distillery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistilleryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DistilleriesApi
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Distillery>> PostDistillery(Distillery distillery)
        {
            _context.Distilleries.Add(distillery);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDistillery", new { id = distillery.Id }, distillery);
        }

        // DELETE: api/DistilleriesApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Distillery>> DeleteDistillery(int id)
        {
            var distillery = await _context.Distilleries.FindAsync(id);
            if (distillery == null)
            {
                return NotFound();
            }

            _context.Distilleries.Remove(distillery);
            await _context.SaveChangesAsync();

            return distillery;
        }

        private bool DistilleryExists(int id)
        {
            return _context.Distilleries.Any(e => e.Id == id);
        }
    }
}
