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
    public class TbOrgansController : ControllerBase
    {
        private readonly iorgaoSQL_BDContext _context;

        public TbOrgansController(iorgaoSQL_BDContext context)
        {
            _context = context;
        }

        // GET: api/TbOrgans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbOrgan>>> GetTbOrgans()
        {
            return await _context.TbOrgans.ToListAsync();
        }

        // GET: api/TbOrgans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbOrgan>> GetTbOrgan(int id)
        {
            var tbOrgan = await _context.TbOrgans.FindAsync(id);

            if (tbOrgan == null)
            {
                return NotFound();
            }

            return tbOrgan;
        }

        // PUT: api/TbOrgans/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbOrgan(int id, TbOrgan tbOrgan)
        {
            if (id != tbOrgan.IdOrgan)
            {
                return BadRequest();
            }

            _context.Entry(tbOrgan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbOrganExists(id))
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

        // POST: api/TbOrgans
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TbOrgan>> PostTbOrgan(TbOrgan tbOrgan)
        {
            _context.TbOrgans.Add(tbOrgan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbOrgan", new { id = tbOrgan.IdOrgan }, tbOrgan);
        }

        // DELETE: api/TbOrgans/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TbOrgan>> DeleteTbOrgan(int id)
        {
            var tbOrgan = await _context.TbOrgans.FindAsync(id);
            if (tbOrgan == null)
            {
                return NotFound();
            }

            _context.TbOrgans.Remove(tbOrgan);
            await _context.SaveChangesAsync();

            return tbOrgan;
        }

        private bool TbOrganExists(int id)
        {
            return _context.TbOrgans.Any(e => e.IdOrgan == id);
        }
    }
}
