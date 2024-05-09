using SaveUrShowUsingCFA.models;
using SaveUrShowUsingCFA.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace SaveUrShowUsingCFA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindTicketsController : ControllerBase
    {
        /*private readonly SaveUrShowUsingCFADbContext _context;*/
        private readonly IFindTicketRepository _findTicketRepository;
        private readonly ILogger<FindTicketsController> _logger;

        public FindTicketsController(IFindTicketRepository findTicketRepository,
          ILogger<FindTicketsController> logger)
        {
           /* _context = context;*/
            _findTicketRepository = findTicketRepository;
            _logger = logger;

        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<FindTicket>>> GetFindTicket()
        {
            return await _findTicketRepository.GetFindTicket();
            // return await _context.FindTicket.ToListAsync();
        }

  
        [HttpGet("{id}")]
        public async Task<ActionResult<FindTicket>> GetFindTicket(int id)
        {
            var findTicket = await _findTicketRepository.GetFindTicket(id);
            //var findTicket = await _context.FindTicket.FindAsync(id);

            if (findTicket == null)
            {
                return NotFound();
            }

            return findTicket;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFindTicket(int id, FindTicket findTicket)
        {
            if (id != findTicket.MovieId)
            {
                return BadRequest();
            }


            var ticket = await _findTicketRepository.PutFindTicket(id, findTicket);
            if (ticket == null)
                return NotFound();

            return Ok("Updated");
        }

    [HttpPost]
      [Authorize(Roles ="Admin")]
        public async Task<ActionResult<FindTicket>> PostFindTicket(FindTicket findTicket)
        {
            /* _context.FindTicket.Add(findTicket);
             await _context.SaveChangesAsync();*/
            await _findTicketRepository.PostFindTicket(findTicket);

            return CreatedAtAction("GetFindTicket", new { id = findTicket.MovieId }, findTicket);
        }


        // DELETE: api/FindTickets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FindTicket>> DeleteFindTicket(int id)
        {
            /* var findTicket = await _context.FindTicket.FindAsync(id);*/
            var findTicket = await _findTicketRepository.DeleteFindTicket(id);
            if (findTicket == null)
            {
                return NotFound();
            }

            /* _context.FindTicket.Remove(findTicket);
             await _context.SaveChangesAsync();*/

            return findTicket;
        }

    }
}