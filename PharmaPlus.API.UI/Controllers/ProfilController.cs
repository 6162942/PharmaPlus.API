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
    public class ProfilController : ControllerBase
    {

        private readonly ProduitsContext _context;

        public ProfilController(ProduitsContext context)
        {
            _context = context;
        }

        // GET: api/Profils
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profil>>> GetDCandidates()
        {
            return await _context.Profils.ToListAsync();
        }

        // GET: api/Profils/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profil>> GetDCandidate(int id)
        {
            var dCandidate = await _context.Profils.FindAsync(id);

            if (dCandidate == null)
            {
                return NotFound();
            }

            return dCandidate;
        }

        // PUT: api/Profils/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDCandidate(int id, Profil Profil)
        {
            /* if (id != dCandidate.id)
             {
                 return BadRequest();
             }*/
            Profil.Id = id;

            _context.Entry(Profil).State = EntityState.Modified;

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
        public async Task<ActionResult<Profil>> PostDCandidate(Profil Profil)
        {
            _context.Profils.Add(Profil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDCandidate", new { id = Profil.Id }, Profil);
        }

        // DELETE: api/DCandidates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Profil>> DeleteDCandidate(int id)
        {
            var dCandidate = await _context.Profils.FindAsync(id);
            if (dCandidate == null)
            {
                return NotFound();
            }

            _context.Profils.Remove(dCandidate);
            await _context.SaveChangesAsync();

            return dCandidate;
        }

        private bool DCandidateExists(int id)
        {
            return _context.Profils.Any(e => e.Id == id);
        }

    }
}
