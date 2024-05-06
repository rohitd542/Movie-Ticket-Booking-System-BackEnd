/*using SaveUrShowUsingCFA.Controllers;
using SaveUrShowUsingCFA.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            // _logger.LogInformation["Getting all the users successfully."];
            return await _context.BookTicket.ToListAsync();
            //throw new NotImplementedException();
        }

        public async Task<ActionResult<BookTicket>> GetBookTicketsByUserId(long userId)
        {
            var book = await _context.BookTicket.FindAsync(userId);

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

    }
}*/



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
            // _logger.LogInformation["Getting all the users successfully."];
            return await _context.BookTicket.ToListAsync();
            //throw new NotImplementedException();
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
    }
}