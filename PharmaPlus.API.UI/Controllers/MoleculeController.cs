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
    public class MoleculeController : ControllerBase
    {

        private readonly ProduitsContext _context;

        public MoleculeController(ProduitsContext context)
        {
            _context = context;
        }

        // GET: api/Molecules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Molecule>>> GetDCandidates()
        {
            return await _context.Molecules.ToListAsync();
        }

        // GET: api/Molecules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Molecule>> GetDCandidate(int id)
        {
            var dCandidate = await _context.Molecules.FindAsync(id);

            if (dCandidate == null)
            {
                return NotFound();
            }

            return dCandidate;
        }

        // PUT: api/Molecules/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDCandidate(int id, Molecule Molecule)
        {
            /* if (id != dCandidate.id)
             {
                 return BadRequest();
             }*/
            Molecule.Id = id;

            _context.Entry(Molecule).State = EntityState.Modified;

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
        public async Task<ActionResult<Molecule>> PostDCandidate(Molecule Molecule)
        {
            _context.Molecules.Add(Molecule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDCandidate", new { id = Molecule.Id }, Molecule);
        }

        // DELETE: api/DCandidates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Molecule>> DeleteDCandidate(int id)
        {
            var dCandidate = await _context.Molecules.FindAsync(id);
            if (dCandidate == null)
            {
                return NotFound();
            }

            _context.Molecules.Remove(dCandidate);
            await _context.SaveChangesAsync();

            return dCandidate;
        }

        private bool DCandidateExists(int id)
        {
            return _context.Molecules.Any(e => e.Id == id);
        }

    }
}
