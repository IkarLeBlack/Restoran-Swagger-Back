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
    public class DishEntitiesController : ControllerBase
    {
        private readonly RestoranDbContext _context;

        public DishEntitiesController(RestoranDbContext context)
        {
            _context = context;
        }

        // GET: api/DishEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DishEntity>>> GetDish()
        {
            return await _context.Dish.ToListAsync();
        }

        // GET: api/DishEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DishEntity>> GetDishEntity(int id)
        {
            var dishEntity = await _context.Dish.FindAsync(id);

            if (dishEntity == null)
            {
                return NotFound();
            }

            return dishEntity;
        }

        // PUT: api/DishEntities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDishEntity(int id, DishEntity dishEntity)
        {
            if (id != dishEntity.DishId)
            {
                return BadRequest();
            }

            _context.Entry(dishEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishEntityExists(id))
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

        // POST: api/DishEntities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DishEntity>> PostDishEntity(DishEntity dishEntity)
        {
            _context.Dish.Add(dishEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDishEntity", new { id = dishEntity.DishId }, dishEntity);
        }

        // DELETE: api/DishEntities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDishEntity(int id)
        {
            var dishEntity = await _context.Dish.FindAsync(id);
            if (dishEntity == null)
            {
                return NotFound();
            }

            _context.Dish.Remove(dishEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DishEntityExists(int id)
        {
            return _context.Dish.Any(e => e.DishId == id);
        }
    }
}
