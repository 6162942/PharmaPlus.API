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
    public class CommandeAchatController : ControllerBase
    {

        private readonly ProduitsContext _context;

        public CommandeAchatController(ProduitsContext context)
        {
            _context = context;
        }

        // GET: api/CommandeAchats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommandeAchat>>> GetDCandidates()
        {
            return await _context.CommandeAchats.ToListAsync();
        }

        // GET: api/CommandeAchats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommandeAchat>> GetDCandidate(int id)
        {
            var dCandidate = await _context.CommandeAchats.FindAsync(id);

            if (dCandidate == null)
            {
                return NotFound();
            }

            return dCandidate;
        }

        // PUT: api/CommandeAchats/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDCandidate(int id, CommandeAchat CommandeAchat)
        {
            /* if (id != dCandidate.id)
             {
                 return BadRequest();
             }*/
            CommandeAchat.Id = id;

            _context.Entry(CommandeAchat).State = EntityState.Modified;

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
        public async Task<ActionResult<CommandeAchat>> PostDCandidate(CommandeAchat CommandeAchat)
        {
            _context.CommandeAchats.Add(CommandeAchat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDCandidate", new { id = CommandeAchat.Id }, CommandeAchat);
        }

        // DELETE: api/DCandidates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CommandeAchat>> DeleteDCandidate(int id)
        {
            var dCandidate = await _context.CommandeAchats.FindAsync(id);
            if (dCandidate == null)
            {
                return NotFound();
            }

            _context.CommandeAchats.Remove(dCandidate);
            await _context.SaveChangesAsync();

            return dCandidate;
        }

        private bool DCandidateExists(int id)
        {
            return _context.CommandeAchats.Any(e => e.Id == id);
        }

    }
}
