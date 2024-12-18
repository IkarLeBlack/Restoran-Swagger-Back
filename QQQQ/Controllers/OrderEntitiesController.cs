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
    public class OrderEntitiesController : ControllerBase
    {
        private readonly RestoranDbContext _context;

        public OrderEntitiesController(RestoranDbContext context)
        {
            _context = context;
        }

        // GET: api/OrderEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderEntity>>> GetOrder()
        {
            return await _context.Order.ToListAsync();
        }

        // GET: api/OrderEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderEntity>> GetOrderEntity(int id)
        {
            var orderEntity = await _context.Order.FindAsync(id);

            if (orderEntity == null)
            {
                return NotFound();
            }

            return orderEntity;
        }

        // PUT: api/OrderEntities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderEntity(int id, OrderEntity orderEntity)
        {
            if (id != orderEntity.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(orderEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderEntityExists(id))
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

        // POST: api/OrderEntities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderEntity>> PostOrderEntity(OrderEntity orderEntity)
        {
            _context.Order.Add(orderEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderEntity", new { id = orderEntity.OrderId }, orderEntity);
        }

        // DELETE: api/OrderEntities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderEntity(int id)
        {
            var orderEntity = await _context.Order.FindAsync(id);
            if (orderEntity == null)
            {
                return NotFound();
            }

            _context.Order.Remove(orderEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderEntityExists(int id)
        {
            return _context.Order.Any(e => e.OrderId == id);
        }
    }
}
