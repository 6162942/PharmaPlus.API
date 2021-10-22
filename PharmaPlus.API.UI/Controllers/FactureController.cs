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
    public class FactureController : ControllerBase
    {

        private readonly ProduitsContext _context;

        public FactureController(ProduitsContext context)
        {
            _context = context;
        }

        // GET: api/Factures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facture>>> GetDCandidates()
        {
            return await _context.Factures.ToListAsync();
        }

        // GET: api/Factures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Facture>> GetDCandidate(int id)
        {
            var dCandidate = await _context.Factures.FindAsync(id);

            if (dCandidate == null)
            {
                return NotFound();
            }

            return dCandidate;
        }

        // PUT: api/Factures/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDCandidate(int id, Facture Facture)
        {
            /* if (id != dCandidate.id)
             {
                 return BadRequest();
             }*/
            Facture.Id = id;

            _context.Entry(Facture).State = EntityState.Modified;

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
        public async Task<ActionResult<Facture>> PostDCandidate(Facture Facture)
        {
            _context.Factures.Add(Facture);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDCandidate", new { id = Facture.Id }, Facture);
        }

        // DELETE: api/DCandidates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Facture>> DeleteDCandidate(int id)
        {
            var dCandidate = await _context.Factures.FindAsync(id);
            if (dCandidate == null)
            {
                return NotFound();
            }

            _context.Factures.Remove(dCandidate);
            await _context.SaveChangesAsync();

            return dCandidate;
        }

        private bool DCandidateExists(int id)
        {
            return _context.Factures.Any(e => e.Id == id);
        }

    }
}
