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

        // POST: api/PostTbAdressToPatient/TbAdresses/
        [HttpPost("PostTbAdressToPatient/{id}")]
        public async Task<ActionResult<TbAdress>> PostTbAdressToPatient(TbAdress tbAdress, int id)
        {

            var tbPatient = await _context.TbPatients.FindAsync(id);

            tbPatient.IdAdress = tbAdress.IdAdress;

            DateTime actual = DateTime.Now;

            tbAdress.DateCreatedAdress = actual;

            _context.TbAdresses.Add(tbAdress);
            _context.TbPatients.Update(tbPatient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbAdress", new { id = tbAdress.IdAdress }, tbAdress);
        }

        // POST: api/PostTbAdressToDonator/TbAdresses/
        [HttpPost("PostTbAdressToDonator/{id}")]
        public async Task<ActionResult<TbAdress>> PostTbAdressToDonator(TbAdress tbAdress, int id)
        {

            var tbDonator = await _context.TbDonators.FindAsync(id);

            tbDonator.IdAdress = tbAdress.IdAdress;

            DateTime actual = DateTime.Now;

            tbAdress.DateCreatedAdress = actual;

            _context.TbAdresses.Add(tbAdress);
            _context.TbDonators.Update(tbDonator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbAdress", new { id = tbAdress.IdAdress }, tbAdress);
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
