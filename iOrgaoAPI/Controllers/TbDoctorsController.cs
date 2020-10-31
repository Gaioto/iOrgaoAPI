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
    public class TbDoctorsController : ControllerBase
    {
        private readonly iorgaoSQL_BDContext _context;

        public TbDoctorsController(iorgaoSQL_BDContext context)
        {
            _context = context;
        }

        // GET: api/TbDoctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbDoctor>>> GetTbDoctors()
        {
            return await _context.TbDoctors.ToListAsync();
        }

        // GET: api/TbDonators/GetTbDoctorLogin
        [HttpGet("GetTbDoctorLogin/{email}/{password}")]
        public async Task<ActionResult<TbDoctor>> GetTbDoctorLogin(String email, String password)
        {
            TbDoctor doctor = _context.TbDoctors.Where(doc => doc.EmailDoctor == email).FirstOrDefault();

            if (doctor.EmailDoctor == email && doctor.PasswordDoctor == password)
            {

                return doctor;

            }
            else
            {
                return NotFound();
            }

        }
            // GET: api/TbDoctors/GetTbDoctorDetails/5
            [HttpGet("GetTbDoctorDetails/{id}")]
        public async Task<ActionResult<TbDoctor>> GetTbDoctorDetails(int id)
        {
            var tbDoctor = _context.TbDoctors
                                           .Include(doc => doc.IdPatientNavigation)
                                           .Include(doc => doc.TbDonations)
                                           .Where(doc => doc.IdDoctor == id)
                                           .FirstOrDefault();

            if (tbDoctor == null)
            {
                return NotFound();
            }

            return tbDoctor;
        }

        // GET: api/TbDoctors/GetTbDoctor/5
        [HttpGet("GetTbDoctor/{id}")]
        public async Task<ActionResult<TbDoctor>> GetTbDoctor(int id)
        {
            var tbDoctor = await _context.TbDoctors.FindAsync(id);

            if (tbDoctor == null)
            {
                return NotFound();
            }

            return tbDoctor;
        }

        // PUT: api/TbDoctors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbDoctor(int id, TbDoctor tbDoctor)
        {

            DateTime actual = DateTime.Now;

            tbDoctor.DateUpdatedDoctor = actual;

            if (id != tbDoctor.IdDoctor)
            {
                return BadRequest();
            }

            _context.Entry(tbDoctor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbDoctorExists(id))
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

        // POST: api/TbDoctors
        [HttpPost]
        public async Task<ActionResult<TbDoctor>> PostTbDoctor(TbDoctor tbDoctor)
        {

            DateTime actual = DateTime.Now;

            tbDoctor.DateCreatedDoctor = actual;

            _context.TbDoctors.Add(tbDoctor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbDoctor", new { id = tbDoctor.IdDoctor }, tbDoctor);
        }

        // DELETE: api/TbDoctors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TbDoctor>> DeleteTbDoctor(int id)
        {
            var tbDoctor = await _context.TbDoctors.FindAsync(id);
            if (tbDoctor == null)
            {
                return NotFound();
            }

            _context.TbDoctors.Remove(tbDoctor);
            await _context.SaveChangesAsync();

            return tbDoctor;
        }

        private bool TbDoctorExists(int id)
        {
            return _context.TbDoctors.Any(e => e.IdDoctor == id);
        }
    }
}
