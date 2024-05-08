using SaveUrShowUsingCFA.Controllers;
using SaveUrShowUsingCFA.models;
using SaveUrShowUsingCFA.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace SaveUrShowUsingCFA.Repository
{
    public class FindTicketRepository : IFindTicketRepository
    {
        private readonly SaveUrShowUsingCFADbContext _context;
        private readonly ILogger<FindTicketsController> _logger;
        private readonly IConfiguration configuration;
        public FindTicketRepository(SaveUrShowUsingCFADbContext context, ILogger<FindTicketsController> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            this.configuration = configuration;
        }
        public async Task<ActionResult<IEnumerable<FindTicket>>> GetFindTicket()
        {
            // _logger.LogInformation["Getting all the users successfully."];
            return await _context.FindTicket.ToListAsync();
            //throw new NotImplementedException();
        }

        public async Task<ActionResult<FindTicket>> GetFindTicket(int id)
        {
            var find = await _context.FindTicket.FindAsync(id);

            return find;
        }
        public async Task<ActionResult<FindTicket>> PostFindTicket(FindTicket findTicket)
        {
            _context.FindTicket.Add(findTicket);
            await _context.SaveChangesAsync();
            return findTicket;
        }

        public async Task<ActionResult<FindTicket>> PutFindTicket(int id, FindTicket findTicket)
        {
            _context.Entry(findTicket).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return findTicket;
        }

        public async Task<ActionResult<FindTicket>> DeleteFindTicket(int id)
        {
            var findTicket = await _context.FindTicket.FindAsync(id);
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