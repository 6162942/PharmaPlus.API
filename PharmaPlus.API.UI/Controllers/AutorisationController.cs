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
    public class AutorisationController : ControllerBase
    {

        private readonly ProduitsContext _context;

        public AutorisationController(ProduitsContext context)
        {
            _context = context;
        }

        // GET: api/Autorisations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autorisation>>> GetDCandidates()
        {
            return await _context.Autorisations.ToListAsync();
        }

        // GET: api/Autorisations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Autorisation>> GetDCandidate(int id)
        {
            var dCandidate = await _context.Autorisations.FindAsync(id);

            if (dCandidate == null)
            {
                return NotFound();
            }

            return dCandidate;
        }

        // PUT: api/Autorisations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDCandidate(int id, Autorisation Autorisation)
        {
            /* if (id != dCandidate.id)
             {
                 return BadRequest();
             }*/
            Autorisation.DepartementId = id;

            _context.Entry(Autorisation).State = EntityState.Modified;

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
        public async Task<ActionResult<Autorisation>> PostDCandidate(Autorisation Autorisation)
        {
            _context.Autorisations.Add(Autorisation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDCandidate", new { id = Autorisation.DepartementId }, Autorisation);
        }

        // DELETE: api/DCandidates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Autorisation>> DeleteDCandidate(int id)
        {
            var dCandidate = await _context.Autorisations.FindAsync(id);
            if (dCandidate == null)
            {
                return NotFound();
            }

            _context.Autorisations.Remove(dCandidate);
            await _context.SaveChangesAsync();

            return dCandidate;
        }

        private bool DCandidateExists(int id)
        {
            return _context.Autorisations.Any(e => e.DepartementId == id);
        }

    }
}
