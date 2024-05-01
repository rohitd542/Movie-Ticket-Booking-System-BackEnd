using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaveUrShowUsingCFA.models;

namespace SaveUrShowUsingCFA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindTicketsController : ControllerBase
    {
        private readonly SaveUrShowUsingCFADbContext _context;

        public FindTicketsController(SaveUrShowUsingCFADbContext context)
        {
            _context = context;
        }

        // GET: api/FindTickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FindTicket>>> GetFindTicket()
        {
            return await _context.FindTicket.ToListAsync();
        }

        // GET: api/FindTickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FindTicket>> GetFindTicket(int id)
        {
            var findTicket = await _context.FindTicket.FindAsync(id);

            if (findTicket == null)
            {
                return NotFound();
            }

            return findTicket;
        }

        // PUT: api/FindTickets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFindTicket(int id, FindTicket findTicket)
        {
            if (id != findTicket.MovieId)
            {
                return BadRequest();
            }

            _context.Entry(findTicket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FindTicketExists(id))
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

        // POST: api/FindTickets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FindTicket>> PostFindTicket(FindTicket findTicket)
        {
            _context.FindTicket.Add(findTicket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFindTicket", new { id = findTicket.MovieId }, findTicket);
        }

        // DELETE: api/FindTickets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FindTicket>> DeleteFindTicket(int id)
        {
            var findTicket = await _context.FindTicket.FindAsync(id);
            if (findTicket == null)
            {
                return NotFound();
            }

            _context.FindTicket.Remove(findTicket);
            await _context.SaveChangesAsync();

            return findTicket;
        }

        private bool FindTicketExists(int id)
        {
            return _context.FindTicket.Any(e => e.MovieId == id);
        }
    }
}
