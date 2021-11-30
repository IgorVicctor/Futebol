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
    public class CompeticoesController : ControllerBase
    {
        private readonly FutebolContext _context;

        public CompeticoesController(FutebolContext context)
        {
            _context = context;
        }

        // GET: api/Competicoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Competicao>>> GetCompeticao()
        {
            return await _context.Competicao.ToListAsync();
        }

        // GET: api/Competicoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Competicao>> GetCompeticao(int id)
        {
            var competicao = await _context.Competicao.FindAsync(id);

            if (competicao == null)
            {
                return NotFound();
            }

            return competicao;
        }

        // PUT: api/Competicoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompeticao(int id, Competicao competicao)
        {
            if (id != competicao.timeId)
            {
                return BadRequest();
            }

            _context.Entry(competicao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompeticaoExists(id))
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

        // POST: api/Competicoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Competicao>> PostCompeticao(Competicao competicao)
        {
            _context.Competicao.Add(competicao);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CompeticaoExists(competicao.timeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCompeticao", new { id = competicao.timeId }, competicao);
        }

        // DELETE: api/Competicoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompeticao(int id)
        {
            var competicao = await _context.Competicao.FindAsync(id);
            if (competicao == null)
            {
                return NotFound();
            }

            _context.Competicao.Remove(competicao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompeticaoExists(int id)
        {
            return _context.Competicao.Any(e => e.timeId == id);
        }
    }
}
