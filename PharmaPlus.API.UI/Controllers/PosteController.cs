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
    public class PosteController : ControllerBase
    {

        private readonly ProduitsContext _context;

        public PosteController(ProduitsContext context)
        {
            _context = context;
        }

        // GET: api/Postes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Poste>>> GetDCandidates()
        {
            return await _context.Postes.ToListAsync();
        }

        // GET: api/Postes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Poste>> GetDCandidate(int id)
        {
            var dCandidate = await _context.Postes.FindAsync(id);

            if (dCandidate == null)
            {
                return NotFound();
            }

            return dCandidate;
        }

        // PUT: api/Postes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDCandidate(int id, Poste Poste)
        {
            /* if (id != dCandidate.id)
             {
                 return BadRequest();
             }*/
            Poste.Id = id;

            _context.Entry(Poste).State = EntityState.Modified;

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
        public async Task<ActionResult<Poste>> PostDCandidate(Poste Poste)
        {
            _context.Postes.Add(Poste);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDCandidate", new { id = Poste.Id }, Poste);
        }

        // DELETE: api/DCandidates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Poste>> DeleteDCandidate(int id)
        {
            var dCandidate = await _context.Postes.FindAsync(id);
            if (dCandidate == null)
            {
                return NotFound();
            }

            _context.Postes.Remove(dCandidate);
            await _context.SaveChangesAsync();

            return dCandidate;
        }

        private bool DCandidateExists(int id)
        {
            return _context.Postes.Any(e => e.Id == id);
        }

    }
}
