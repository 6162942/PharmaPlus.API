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
    public class Composition_commandeController : ControllerBase
    {

        private readonly ProduitsContext _context;

        public Composition_commandeController(ProduitsContext context)
        {
            _context = context;
        }

        // GET: api/Composition_commandes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Composition_commande>>> GetDCandidates()
        {
            return await _context.Composition_commandes.ToListAsync();
        }

        // GET: api/Composition_commandes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Composition_commande>> GetDCandidate(int id)
        {
            var dCandidate = await _context.Composition_commandes.FindAsync(id);

            if (dCandidate == null)
            {
                return NotFound();
            }

            return dCandidate;
        }

        // PUT: api/Composition_commandes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDCandidate(int id, Composition_commande Composition_commande)
        {
            /* if (id != dCandidate.id)
             {
                 return BadRequest();
             }*/
            Composition_commande.CommandeId = id;

            _context.Entry(Composition_commande).State = EntityState.Modified;

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
        public async Task<ActionResult<Composition_commande>> PostDCandidate(Composition_commande Composition_commande)
        {
            _context.Composition_commandes.Add(Composition_commande);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDCandidate", new { id = Composition_commande.CommandeId }, Composition_commande);
        }

        // DELETE: api/DCandidates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Composition_commande>> DeleteDCandidate(int id)
        {
            var dCandidate = await _context.Composition_commandes.FindAsync(id);
            if (dCandidate == null)
            {
                return NotFound();
            }

            _context.Composition_commandes.Remove(dCandidate);
            await _context.SaveChangesAsync();

            return dCandidate;
        }

        private bool DCandidateExists(int id)
        {
            return _context.Composition_commandes.Any(e => e.CommandeId == id);
        }

    }
}
