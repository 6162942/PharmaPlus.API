using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmaPlus.Core.Produits.Domain;
using PharmaPlus.Core.Produits.Infrastructures.Data;

namespace PharmaPlus.API.UI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LotController : ControllerBase
    {

        private readonly ProduitsContext _context;

        public LotController(ProduitsContext context)
        {
            _context = context;
        }

        // GET: api/Lots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lot>>> GetDCandidates()
        {
            return await _context.Lots.ToListAsync();
        }

        // GET: api/Lots/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lot>> GetDCandidate(int id)
        {
            var dCandidate = await _context.Lots.FindAsync(id);

            if (dCandidate == null)
            {
                return NotFound();
            }

            return dCandidate;
        }

        // PUT: api/Lots/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDCandidate(int id, Lot Lot)
        {
            /* if (id != dCandidate.id)
             {
                 return BadRequest();
             }*/
            Lot.Id = id;

            _context.Entry(Lot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DCandidateExists(id))
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

        // POST: api/DCandidates
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Lot>> PostDCandidate(Lot Lot)
        {
            _context.Lots.Add(Lot);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDCandidate", new { id = Lot.Id }, Lot);
        }

        // DELETE: api/DCandidates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Lot>> DeleteDCandidate(int id)
        {
            var dCandidate = await _context.Lots.FindAsync(id);
            if (dCandidate == null)
            {
                return NotFound();
            }

            _context.Lots.Remove(dCandidate);
            await _context.SaveChangesAsync();

            return dCandidate;
        }

        private bool DCandidateExists(int id)
        {
            return _context.Lots.Any(e => e.Id == id);
        }

    }
}
