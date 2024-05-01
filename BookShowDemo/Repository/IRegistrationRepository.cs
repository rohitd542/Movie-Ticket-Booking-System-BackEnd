using Microsoft.AspNetCore.Mvc;
using SaveUrShowUsingCFA.Dto;
using SaveUrShowUsingCFA.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaveUrShowUsingCFA.Repository
{
    public interface IRegistrationRepository
    {
        Task<ActionResult<IEnumerable<Registration>>> GetRegistration();
        Task<ActionResult<Registration>> GetRegistration(int id);
        LoginResponse GetRegistration(string email, string password);
        Task<ActionResult<Registration>> PostRegistration(Registration registration);
        Task<ActionResult<Registration>> PutRegistration(int id, Registration registration);
        Task<ActionResult<Registration>> DeleteRegistration(int id);
    }
}
