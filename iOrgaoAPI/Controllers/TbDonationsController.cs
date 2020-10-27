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
    public class TbDonationsController : ControllerBase
    {
        private readonly iorgaoSQL_BDContext _context;

        public TbDonationsController(iorgaoSQL_BDContext context)
        {
            _context = context;
        }

        // GET: api/TbDonations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbDonation>>> GetTbDonations()
        {
            return await _context.TbDonations.ToListAsync();
        }

        // GET: api/TbDonations/GetTbDonationDetails/5
        [HttpGet("GetTbDonationDetails/{id}")]
        public async Task<ActionResult<TbDonation>> GetTbDonationDetails(int id)
        {
            var tbDonation = _context.TbDonations
                                               .Include(don => don.IdDoctorNavigation)
                                               .Include(don => don.IdDonatorNavigation)
                                               .Include(don => don.IdPatientNavigation)                                     
                                               .Where(don => don.IdDonation == id)
                                               .FirstOrDefault(); 

            if (tbDonation == null)
            {
                return NotFound();
            }

            return tbDonation;
        }

        // GET: api/TbDonations/GetTbDonation/5
        [HttpGet("GetTbDonation/{id}")]
        public async Task<ActionResult<TbDonation>> GetTbDonation(int id)
        {
            var tbDonation = await _context.TbDonations.FindAsync(id);

            if (tbDonation == null)
            {
                return NotFound();
            }

            return tbDonation;
        }

        // PUT: api/TbDonations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbDonation(int id, TbDonation tbDonation)
        {

            DateTime actual = DateTime.Now;

            tbDonation.DateUpdatedDonation = actual;

            if (id != tbDonation.IdDonation)
            {
                return BadRequest();
            }

            _context.Entry(tbDonation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbDonationExists(id))
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

        // POST: api/TbDonations
        [HttpPost]
        public async Task<ActionResult<TbDonation>> PostTbDonation(TbDonation tbDonation)
        {

            DateTime actual = DateTime.Now;

            tbDonation.DateCreatedDonation = actual;

            _context.TbDonations.Add(tbDonation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbDonation", new { id = tbDonation.IdDonation }, tbDonation);
        }

        // DELETE: api/TbDonations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TbDonation>> DeleteTbDonation(int id)
        {
            var tbDonation = await _context.TbDonations.FindAsync(id);
            if (tbDonation == null)
            {
                return NotFound();
            }

            _context.TbDonations.Remove(tbDonation);
            await _context.SaveChangesAsync();

            return tbDonation;
        }

        private bool TbDonationExists(int id)
        {
            return _context.TbDonations.Any(e => e.IdDonation == id);
        }
    }
}
