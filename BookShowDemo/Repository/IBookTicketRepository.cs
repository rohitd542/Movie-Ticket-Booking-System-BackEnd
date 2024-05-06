using Microsoft.AspNetCore.Mvc;
using SaveUrShowUsingCFA.models;

namespace SaveUrShowUsingCFA.Repository

{
    public interface IBookTicketRepository
    {
        Task<ActionResult<IEnumerable<BookTicket>>> GetBookTicket();
        Task<ActionResult<IEnumerable<BookTicket>>> GetBookTicketsByUserId(long userId);
        Task<ActionResult<BookTicket>> PostBookTicket(BookTicket bookTicket);
        Task<ActionResult<BookTicket>> PutBookTicket(int id, BookTicket bookTicket);
        Task<ActionResult<BookTicket>> DeleteBookTicket(long id);
    }
}           