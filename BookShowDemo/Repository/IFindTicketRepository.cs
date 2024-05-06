using Microsoft.AspNetCore.Mvc;
using SaveUrShowUsingCFA.models;

namespace SaveUrShowUsingCFA.Repository

{
    public interface IFindTicketRepository
    {
        Task<ActionResult<IEnumerable<FindTicket>>> GetFindTicket();
        Task<ActionResult<FindTicket>> GetFindTicket(int id);
        Task<ActionResult<FindTicket>> PostFindTicket(FindTicket findTicket);
        Task<ActionResult<FindTicket>> PutFindTicket(int id, FindTicket findTicket);
        Task<ActionResult<FindTicket>> DeleteFindTicket(int id);

    }
}