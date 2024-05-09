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
      /*  private readonly SaveUrShowUsingCFADbContext _context;*/
        private readonly IBookTicketRepository _bookTicketRepository;
        private readonly ILogger<BookTicketsController> _logger;

        public BookTicketsController( IBookTicketRepository bookTicketRepository,
          ILogger<BookTicketsController> logger)
        {
           /* _context = context;*/
            _bookTicketRepository = bookTicketRepository;
            _logger = logger;

        }
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
    
            /* var bookTickets = await _context.BookTicket.Where(bt => bt.UserId == userId).ToListAsync();*/
            var bookTickets = await _bookTicketRepository.GetBookTicketsByUserId(userId);

            /*if (bookTickets == null || !bookTickets.Any())*/
            if (bookTickets == null)
            {
                return NotFound();
            }

            return bookTickets;
        }

        // PUT: api/BookTickets/5

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
        }

        // POST: api/BookTickets
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

    }
}