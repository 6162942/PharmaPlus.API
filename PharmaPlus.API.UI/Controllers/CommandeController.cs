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
    public class CommandeController : ControllerBase
    {

        private readonly ProduitsContext _context;

        public CommandeController(ProduitsContext context)
        {
            _context = context;
        }

        // GET: api/Commandes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commande>>> GetDCandidates()
        {
            return await _context.Commandes.ToListAsync();
        }

        // GET: api/Commandes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Commande>> GetDCandidate(int id)
        {
            var dCandidate = await _context.Commandes.FindAsync(id);

            if (dCandidate == null)
            {
                return NotFound();
            }

            return dCandidate;
        }

        // PUT: api/Commandes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDCandidate(int id, Commande Commande)
        {
            /* if (id != dCandidate.id)
             {
                 return BadRequest();
             }*/
            Commande.Id = id;

            _context.Entry(Commande).State = EntityState.Modified;

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
        public async Task<ActionResult<Commande>> PostDCandidate(Commande Commande)
        {
            _context.Commandes.Add(Commande);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDCandidate", new { id = Commande.Id }, Commande);
        }

        // DELETE: api/DCandidates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Commande>> DeleteDCandidate(int id)
        {
            var dCandidate = await _context.Commandes.FindAsync(id);
            if (dCandidate == null)
            {
                return NotFound();
            }

            _context.Commandes.Remove(dCandidate);
            await _context.SaveChangesAsync();

            return dCandidate;
        }

        private bool DCandidateExists(int id)
        {
            return _context.Commandes.Any(e => e.Id == id);
        }

    }
}
