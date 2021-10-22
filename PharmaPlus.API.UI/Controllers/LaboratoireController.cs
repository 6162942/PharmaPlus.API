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
    public class LaboratoireController : ControllerBase
    {

        private readonly ProduitsContext _context;

        public LaboratoireController(ProduitsContext context)
        {
            _context = context;
        }

        // GET: api/Laboratoires
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Laboratoire>>> GetDCandidates()
        {
            return await _context.Laboratoires.ToListAsync();
        }

        // GET: api/Laboratoires/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Laboratoire>> GetDCandidate(int id)
        {
            var dCandidate = await _context.Laboratoires.FindAsync(id);

            if (dCandidate == null)
            {
                return NotFound();
            }

            return dCandidate;
        }

        // PUT: api/Laboratoires/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDCandidate(int id, Laboratoire Laboratoire)
        {
            /* if (id != dCandidate.id)
             {
                 return BadRequest();
             }*/
            Laboratoire.Id = id;

            _context.Entry(Laboratoire).State = EntityState.Modified;

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
        public async Task<ActionResult<Laboratoire>> PostDCandidate(Laboratoire Laboratoire)
        {
            _context.Laboratoires.Add(Laboratoire);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDCandidate", new { id = Laboratoire.Id }, Laboratoire);
        }

        // DELETE: api/DCandidates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Laboratoire>> DeleteDCandidate(int id)
        {
            var dCandidate = await _context.Laboratoires.FindAsync(id);
            if (dCandidate == null)
            {
                return NotFound();
            }

            _context.Laboratoires.Remove(dCandidate);
            await _context.SaveChangesAsync();

            return dCandidate;
        }

        private bool DCandidateExists(int id)
        {
            return _context.Laboratoires.Any(e => e.Id == id);
        }

    }
}
