using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using iOrgaoAPI.Models;

namespace iOrgaoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbDonatorsController : ControllerBase
    {
        private readonly iorgaoSQL_BDContext _context;

        public TbDonatorsController(iorgaoSQL_BDContext context)
        {
            _context = context;
        }

        // GET: api/TbDonators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbDonator>>> GetTbDonators()
        {                  
            return await _context.TbDonators.ToListAsync();
        }

        // GET: api/TbDonators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbDonator>> GetTbDonator(int id)
        {
            var tbDonator = await _context.TbDonators.FindAsync(id);

            if (tbDonator == null)
            {
                return NotFound();
            }

            return tbDonator;
        }

        // PUT: api/TbDonators/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbDonator(int id, TbDonator tbDonator)
        {

            DateTime actual = DateTime.Now;

            tbDonator.DateUpdatedDonator = actual;

            if (id != tbDonator.IdDonator)
            {
                return BadRequest();
            }

            _context.Entry(tbDonator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbDonatorExists(id))
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

        // POST: api/TbDonators
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TbDonator>> PostTbDonator(TbDonator tbDonator)
        {

            DateTime actual = DateTime.Now;

            tbDonator.DateCreatedDonator = actual;

            _context.TbDonators.Add(tbDonator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbDonator", new { id = tbDonator.IdDonator }, tbDonator);
        }

        // DELETE: api/TbDonators/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TbDonator>> DeleteTbDonator(int id)
        {
            var tbDonator = await _context.TbDonators.FindAsync(id);
            if (tbDonator == null)
            {
                return NotFound();
            }

            _context.TbDonators.Remove(tbDonator);
            await _context.SaveChangesAsync();

            return tbDonator;
        }

        private bool TbDonatorExists(int id)
        {
            return _context.TbDonators.Any(e => e.IdDonator == id);
        }
    }
}
