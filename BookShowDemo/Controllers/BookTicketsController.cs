/*using System;
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
    public class BookTicketsController : ControllerBase
    {
        private readonly SaveUrShowUsingCFADbContext _context;

        public BookTicketsController(SaveUrShowUsingCFADbContext context)
        {
            _context = context;
        }

        // GET: api/BookTickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookTicket>>> GetBookTicket()
        {
            return await _context.BookTicket.ToListAsync();
        }

        // GET: api/BookTickets/5
        *//*[HttpGet("{id}")]
        public async Task<ActionResult<BookTicket>> GetBookTicket(long id)
        {
            var bookTicket = await _context.BookTicket.FindAsync(id);

            if (bookTicket == null)
            {
                return NotFound();
            }

            return bookTicket;
        }*//*

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<BookTicket>>> GetBookTicketsByUserId(long userId)
        {
            // Find all book tickets for the given user ID
            var bookTickets = await _context.BookTicket.Where(bt => bt.UserId == userId).ToListAsync();

            if (bookTickets == null || !bookTickets.Any())
            {
                return NotFound();
            }

            return bookTickets;
        }



        // PUT: api/BookTickets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookTicket(long id, BookTicket bookTicket)
        {
            if (id != bookTicket.Bookid)
            {
                return BadRequest();
            }

            _context.Entry(bookTicket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookTicketExists(id))
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

        // POST: api/BookTickets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BookTicket>> PostBookTicket(BookTicket bookTicket)
        {
            _context.BookTicket.Add(bookTicket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookTicket", new { id = bookTicket.Bookid }, bookTicket);
        }

        // DELETE: api/BookTickets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookTicket>> DeleteBookTicket(long id)
        {
            var bookTicket = await _context.BookTicket.FindAsync(id);
            if (bookTicket == null)
            {
                return NotFound();
            }

            _context.BookTicket.Remove(bookTicket);
            await _context.SaveChangesAsync();

            return bookTicket;
        }

        private bool BookTicketExists(long id)
        {
            return _context.BookTicket.Any(e => e.Bookid == id);
        }
    }
}
*/



using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaveUrShowUsingCFA.models;
using SaveUrShowUsingCFA.Repository;
using System.Net;

namespace SaveUrShowUsingCFA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookTicketsController : ControllerBase
    {
        private readonly SaveUrShowUsingCFADbContext _context;
        private readonly IBookTicketRepository _bookTicketRepository;
        private readonly ILogger<BookTicketsController> _logger;

        public BookTicketsController(SaveUrShowUsingCFADbContext context, IBookTicketRepository bookTicketRepository,
          ILogger<BookTicketsController> logger)
        {
            _context = context;
            _bookTicketRepository = bookTicketRepository;
            _logger = logger;

        }
        /* private readonly StadiumDbContext _context;
 
         public BookTicketsController(StadiumDbContext context)
         {
             _context = context;
         }
*/
        // GET: api/BookTickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookTicket>>> GetBookTicket()
        {
            //return await _context.BookTicket.ToListAsync();
            return await _bookTicketRepository.GetBookTicket();
        }
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<BookTicket>>> GetBookTicketsByUserId(long userId)
        {
            // Find all book tickets for the given user ID
            /* var bookTickets = await _context.BookTicket.Where(bt => bt.UserId == userId).ToListAsync();*/
            var bookTickets = await _bookTicketRepository.GetBookTicketsByUserId(userId);

            /*if (bookTickets == null || !bookTickets.Any())*/
            if (bookTickets == null)
            {
                return NotFound();
            }

            return bookTickets;
        }

        // GET: api/BookTickets/5
        /* [HttpGet("{id}")]
         public async Task<ActionResult<BookTicket>> GetBookTicket(long id)
         {
             var bookTicket = await _context.BookTicket.FindAsync(id);
 
             if (bookTicket == null)
             {
                 return NotFound();
             }
 
             return bookTicket;
         }*/

        // PUT: api/BookTickets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookTicket(int id, BookTicket bookTicket)
        {
            if (id != bookTicket.Bookid)
            {
                return BadRequest();
            }

            // _context.Entry(bookTicket).State = EntityState.Modified;
            var ticket = await _bookTicketRepository.PutBookTicket(id, bookTicket);
            if (ticket == null)
                return NotFound();

            return Ok("Updated");

            /*try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookTicketExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
 
            return NoContent();*/
        }

        // POST: api/BookTickets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BookTicket>> PostBookTicket(BookTicket bookTicket)
        {
            /*_context.BookTicket.Add(bookTicket);
            await _context.SaveChangesAsync();*/
            await _bookTicketRepository.PostBookTicket(bookTicket);

            return CreatedAtAction("GetBookTicket", new { id = bookTicket.Bookid }, bookTicket);
        }

        // DELETE: api/BookTickets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookTicket>> DeleteBookTicket(long id)
        {
            /*var bookTicket = await _context.BookTicket.FindAsync(id);*/
            var bookTicket = await _bookTicketRepository.DeleteBookTicket(id);
            if (bookTicket == null)
            {
                return NotFound();
            }

            /*_context.BookTicket.Remove(bookTicket);
            await _context.SaveChangesAsync();*/

            return bookTicket;
        }

        private bool BookTicketExists(long id)
        {
            return _context.BookTicket.Any(e => e.Bookid == id);
        }
    }
}