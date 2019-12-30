using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Testbed.Data;
using MVC_Testbed.Models;

namespace MVC_Testbed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BourbonsApiController : ControllerBase
    {
        private readonly MvcTestbedContext _context;

        public BourbonsApiController(MvcTestbedContext context)
        {
            _context = context;
        }

        // GET: api/BourbonsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bourbon>>> GetBourbons()
        {
            var bourbons = await _context.Bourbons.ToListAsync();
            return bourbons;
        }

        // GET: api/BourbonsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bourbon>> GetBourbon(int id)
        {
            var bourbon = await _context.Bourbons.FindAsync(id);

            if (bourbon == null)
            {
                return NotFound();
            }

            return bourbon;
        }

        // PUT: api/BourbonsApi/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBourbon(int id, Bourbon bourbon)
        {
            if (id != bourbon.Id)
            {
                return BadRequest();
            }

            _context.Entry(bourbon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BourbonExists(id))
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

        // POST: api/BourbonsApi
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Bourbon>> PostBourbon(Bourbon bourbon)
        {
            _context.Bourbons.Add(bourbon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBourbon", new { id = bourbon.Id }, bourbon);
        }

        // DELETE: api/BourbonsApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bourbon>> DeleteBourbon(int id)
        {
            var bourbon = await _context.Bourbons.FindAsync(id);
            if (bourbon == null)
            {
                return NotFound();
            }

            _context.Bourbons.Remove(bourbon);
            await _context.SaveChangesAsync();

            return bourbon;
        }

        private bool BourbonExists(int id)
        {
            return _context.Bourbons.Any(e => e.Id == id);
        }
    }
}
