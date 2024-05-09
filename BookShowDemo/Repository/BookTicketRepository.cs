using SaveUrShowUsingCFA.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaveUrShowUsingCFA.models;
using SaveUrShowUsingCFA.Repository;

namespace SaveUrShowUsingCFA.Repository
{
    public class BookTicketRepository : IBookTicketRepository
    {
        private readonly SaveUrShowUsingCFADbContext _context;
        private readonly ILogger<BookTicketsController> _logger;
        private readonly IConfiguration configuration;
        public BookTicketRepository(SaveUrShowUsingCFADbContext context, ILogger<BookTicketsController> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            this.configuration = configuration;
        }
        public async Task<ActionResult<IEnumerable<BookTicket>>> GetBookTicket()
        {
        
            return await _context.BookTicket.ToListAsync();
               }

        public async Task<ActionResult<IEnumerable<BookTicket>>> GetBookTicketsByUserId(long userId)
        {
            var book = await _context.BookTicket.Where(t => t.UserId==userId).ToListAsync();

            return book;
        }
        public async Task<ActionResult<BookTicket>> PostBookTicket(BookTicket bookTicket)
        {
            _context.BookTicket.Add(bookTicket);
            await _context.SaveChangesAsync();
            return bookTicket;
        }

        public async Task<ActionResult<BookTicket>> PutBookTicket(int id, BookTicket bookTicket)
        {
            _context.Entry(bookTicket).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return bookTicket;
        }

        public async Task<ActionResult<BookTicket>> DeleteBookTicket(long id)
        {
            var bookTicket = await _context.BookTicket.FindAsync(id);
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