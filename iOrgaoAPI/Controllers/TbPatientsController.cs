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
    public class TbPatientsController : ControllerBase
    {
        private readonly iorgaoSQL_BDContext _context;

        public TbPatientsController(iorgaoSQL_BDContext context)
        {
            _context = context;
        }

        // GET: api/TbPatients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbPatient>>> GetTbPatients()
        {
            return await _context.TbPatients.ToListAsync();
        }

        // GET: api/TbPatients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbPatient>> GetTbPatient(int id)
        {
            var tbPatient = await _context.TbPatients.FindAsync(id);

            if (tbPatient == null)
            {
                return NotFound();
            }

            return tbPatient;
        }

        // PUT: api/TbPatients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbPatient(int id, TbPatient tbPatient)
        {

            DateTime actual = DateTime.Now;

            tbPatient.DateUpdatedPatient = actual;

            if (id != tbPatient.IdPatient)
            {
                return BadRequest();
            }

            _context.Entry(tbPatient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbPatientExists(id))
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

        // POST: api/TbPatients
        [HttpPost]
        public async Task<ActionResult<TbPatient>> PostTbPatient(TbPatient tbPatient)
        {

            DateTime actual = DateTime.Now;

            tbPatient.DateCreatedPatient = actual;

            _context.TbPatients.Add(tbPatient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbPatient", new { id = tbPatient.IdPatient }, tbPatient);
        }

        // DELETE: api/TbPatients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TbPatient>> DeleteTbPatient(int id)
        {
            var tbPatient = await _context.TbPatients.FindAsync(id);
            if (tbPatient == null)
            {
                return NotFound();
            }

            _context.TbPatients.Remove(tbPatient);
            await _context.SaveChangesAsync();

            return tbPatient;
        }

        private bool TbPatientExists(int id)
        {
            return _context.TbPatients.Any(e => e.IdPatient == id);
        }
    }
}
