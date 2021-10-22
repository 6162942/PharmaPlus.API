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
    public class Composition_commandeAchatController : ControllerBase
    {

        private readonly ProduitsContext _context;

        public Composition_commandeAchatController(ProduitsContext context)
        {
            _context = context;
        }

        // GET: api/Composition_commandeAchats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Composition_commandeAchat>>> GetDCandidates()
        {
            return await _context.Composition_commandeAchats.ToListAsync();
        }

        // GET: api/Composition_commandeAchats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Composition_commandeAchat>> GetDCandidate(int id)
        {
            var dCandidate = await _context.Composition_commandeAchats.FindAsync(id);

            if (dCandidate == null)
            {
                return NotFound();
            }

            return dCandidate;
        }

        // PUT: api/Composition_commandeAchats/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDCandidate(int id, Composition_commandeAchat Composition_commandeAchat)
        {
            /* if (id != dCandidate.id)
             {
                 return BadRequest();
             }*/
            Composition_commandeAchat.CommandeAchatId = id;

            _context.Entry(Composition_commandeAchat).State = EntityState.Modified;

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
        public async Task<ActionResult<Composition_commandeAchat>> PostDCandidate(Composition_commandeAchat Composition_commandeAchat)
        {
            _context.Composition_commandeAchats.Add(Composition_commandeAchat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDCandidate", new { id = Composition_commandeAchat.CommandeAchatId }, Composition_commandeAchat);
        }

        // DELETE: api/DCandidates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Composition_commandeAchat>> DeleteDCandidate(int id)
        {
            var dCandidate = await _context.Composition_commandeAchats.FindAsync(id);
            if (dCandidate == null)
            {
                return NotFound();
            }

            _context.Composition_commandeAchats.Remove(dCandidate);
            await _context.SaveChangesAsync();

            return dCandidate;
        }

        private bool DCandidateExists(int id)
        {
            return _context.Composition_commandeAchats.Any(e => e.CommandeAchatId == id);
        }

    }
}
