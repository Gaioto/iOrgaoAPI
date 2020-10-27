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
    public class TbOrganListsController : ControllerBase
    {
        private readonly iorgaoSQL_BDContext _context;

        public TbOrganListsController(iorgaoSQL_BDContext context)
        {
            _context = context;
        }

        // GET: api/TbOrganLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbOrganList>>> GetTbOrganLists()
        {
            return await _context.TbOrganLists.ToListAsync();
        }

        // GET: api/TbOrganLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbOrganList>> GetTbOrganList(int id)
        {
            var tbOrganList = await _context.TbOrganLists.FindAsync(id);

            if (tbOrganList == null)
            {
                return NotFound();
            }

            return tbOrganList;
        }

        // PUT: api/TbOrganLists/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbOrganList(int id, TbOrganList tbOrganList)
        {
            if (id != tbOrganList.IdOrg)
            {
                return BadRequest();
            }

            _context.Entry(tbOrganList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbOrganListExists(id))
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

        // POST: api/TbOrganLists
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TbOrganList>> PostTbOrganList(TbOrganList tbOrganList)
        {
            _context.TbOrganLists.Add(tbOrganList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbOrganList", new { id = tbOrganList.IdOrg }, tbOrganList);
        }

        // DELETE: api/TbOrganLists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TbOrganList>> DeleteTbOrganList(int id)
        {
            var tbOrganList = await _context.TbOrganLists.FindAsync(id);
            if (tbOrganList == null)
            {
                return NotFound();
            }

            _context.TbOrganLists.Remove(tbOrganList);
            await _context.SaveChangesAsync();

            return tbOrganList;
        }

        private bool TbOrganListExists(int id)
        {
            return _context.TbOrganLists.Any(e => e.IdOrg == id);
        }
    }
}
