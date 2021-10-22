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
    public class AffectationController : ControllerBase
    {

        private readonly ProduitsContext _context;

        public AffectationController(ProduitsContext context)
        {
            _context = context;
        }

        // GET: api/Affectations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Affectation>>> GetDCandidates()
        {
            return await _context.Affectations.ToListAsync();
        }

        // GET: api/Affectations/5
        [HttpGet("{id1, id2}")]
        public async Task<ActionResult<Affectation>> GetDCandidate(int id1, int id2)
        {
            var dCandidate = await _context.Affectations.FindAsync(id1, id2);

            if (dCandidate == null)
            {
                return NotFound();
            }

            return dCandidate;
        }

        // PUT: api/Affectations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id1,id2}")]
        public async Task<IActionResult> PutDCandidate(int id1, int id2,Affectation Affectation)
        {
            /* if (id != dCandidate.id)
             {
                 return BadRequest();
             }*/
            Affectation.EmployeId = id1;
            Affectation.DepartementId = id2;

            _context.Entry(Affectation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DCandidateExists(id1, id2))
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
        public async Task<ActionResult<Affectation>> PostDCandidate(Affectation Affectation)
        {
            _context.Affectations.Add(Affectation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDCandidate", new { id = Affectation.EmployeId }, Affectation);
        }

        // DELETE: api/DCandidates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Affectation>> DeleteDCandidate(int id)
        {
            var dCandidate = await _context.Affectations.FindAsync(id);
            if (dCandidate == null)
            {
                return NotFound();
            }

            _context.Affectations.Remove(dCandidate);
            await _context.SaveChangesAsync();

            return dCandidate;
        }

        private bool DCandidateExists(int id1, int id2)
        {
            return _context.Affectations.Any(e => e.EmployeId == id1 & e.DepartementId == id2);
        }

    }
}
