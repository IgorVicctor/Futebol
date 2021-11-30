using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Futebol.Dados;
using Futebol.Models;

namespace Futebol.Controllers
{
    [Route("futebol/[controller]")]
    [ApiController]
    public class ArbitragensController : ControllerBase
    {
        private readonly FutebolContext _context;

        public ArbitragensController(FutebolContext context)
        {
            _context = context;
        }

        // GET: api/Arbitragens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Arbitragem>>> GetArbitragem()
        {
            return await _context.Arbitragem.ToListAsync();
        }

        // GET: api/Arbitragens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Arbitragem>> GetArbitragem(int id)
        {
            var arbitragem = await _context.Arbitragem.FindAsync(id);

            if (arbitragem == null)
            {
                return NotFound();
            }

            return arbitragem;
        }

        // PUT: api/Arbitragens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArbitragem(int id, Arbitragem arbitragem)
        {
            if (id != arbitragem.jogoId)
            {
                return BadRequest();
            }

            _context.Entry(arbitragem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArbitragemExists(id))
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

        // POST: api/Arbitragens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Arbitragem>> PostArbitragem(Arbitragem arbitragem)
        {
            _context.Arbitragem.Add(arbitragem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArbitragem", new { id = arbitragem.jogoId }, arbitragem);
        }

        // DELETE: api/Arbitragens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArbitragem(int id)
        {
            var arbitragem = await _context.Arbitragem.FindAsync(id);
            if (arbitragem == null)
            {
                return NotFound();
            }

            _context.Arbitragem.Remove(arbitragem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArbitragemExists(int id)
        {
            return _context.Arbitragem.Any(e => e.jogoId == id);
        }
    }
}
