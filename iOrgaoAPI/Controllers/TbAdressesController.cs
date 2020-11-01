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
    public class TbAdressesController : ControllerBase
    {
        private readonly iorgaoSQL_BDContext _context;

        public TbAdressesController(iorgaoSQL_BDContext context)
        {
            _context = context;
        }

        // GET: api/TbAdresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbAdress>>> GetTbAdresses()
        {
            return await _context.TbAdresses.ToListAsync();
        }

        // GET: api/TbAdressesByNumber/5
        [HttpGet("TbAdressesByNumber/{number}")]
        public async Task<ActionResult<TbAdress>> GetTbAdressByNumber(int number)
        {
            var tbAdress = _context.TbAdresses.Where(adr => adr.NumberAdress == number).FirstOrDefault();

            if (tbAdress == null)
            {
                return NotFound();
            }

            return tbAdress;
        }

        // GET: api/TbAdresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbAdress>> GetTbAdress(int id)
        {
            var tbAdress = await _context.TbAdresses.FindAsync(id);

            if (tbAdress == null)
            {
                return NotFound();
            }

            return tbAdress;
        }

        // PUT: api/TbAdresses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbAdress(int id, TbAdress tbAdress)
        {
            DateTime actual = DateTime.Now;

            tbAdress.DateUpdatedAdress = actual;

            if (id != tbAdress.IdAdress)
            {
                return BadRequest();
            }

            _context.Entry(tbAdress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbAdressExists(id))
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

        // POST: api/TbAdresses
        [HttpPost]
        public async Task<ActionResult<TbAdress>> PostTbAdress(TbAdress tbAdress)
        {
            DateTime actual = DateTime.Now;

            tbAdress.DateCreatedAdress = actual;

            _context.TbAdresses.Add(tbAdress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbAdress", new { id = tbAdress.IdAdress }, tbAdress);
        }

        // DELETE: api/TbAdresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TbAdress>> DeleteTbAdress(int id)
        {
            var tbAdress = await _context.TbAdresses.FindAsync(id);
            if (tbAdress == null)
            {
                return NotFound();
            }

            _context.TbAdresses.Remove(tbAdress);
            await _context.SaveChangesAsync();

            return tbAdress;
        }

        private bool TbAdressExists(int id)
        {
            return _context.TbAdresses.Any(e => e.IdAdress == id);
        }
    }
}
