using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QQQQ;

namespace QQQQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientEntitiesController : ControllerBase
    {
        private readonly RestoranDbContext _context;

        public ClientEntitiesController(RestoranDbContext context)
        {
            _context = context;
        }

        // GET: api/ClientEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientEntity>>> GetClient()
        {
            return await _context.Client.ToListAsync();
        }

        // GET: api/ClientEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientEntity>> GetClientEntity(int id)
        {
            var clientEntity = await _context.Client.FindAsync(id);

            if (clientEntity == null)
            {
                return NotFound();
            }

            return clientEntity;
        }

        // PUT: api/ClientEntities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientEntity(int id, ClientEntity clientEntity)
        {
            if (id != clientEntity.ClientId)
            {
                return BadRequest();
            }

            _context.Entry(clientEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientEntityExists(id))
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

        // POST: api/ClientEntities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClientEntity>> PostClientEntity(ClientEntity clientEntity)
        {
            _context.Client.Add(clientEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientEntity", new { id = clientEntity.ClientId }, clientEntity);
        }

        // DELETE: api/ClientEntities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientEntity(int id)
        {
            var clientEntity = await _context.Client.FindAsync(id);
            if (clientEntity == null)
            {
                return NotFound();
            }

            _context.Client.Remove(clientEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientEntityExists(int id)
        {
            return _context.Client.Any(e => e.ClientId == id);
        }
    }
}
