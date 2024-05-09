using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SaveUrShowUsingCFA.models;
using SaveUrShowUsingCFA.Repository;


namespace SaveUrShowUsingCFA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        /*private readonly SaveUrShowUsingCFADbContext _context;*/
        private readonly IRegistrationRepository _registrationRepository;
        private readonly ILogger<RegistrationsController> _logger;

        public RegistrationsController( IRegistrationRepository registrationRepository,
          ILogger<RegistrationsController> logger)
        {
          /*  _context = context;*/
            _registrationRepository = registrationRepository;
            _logger = logger;

        }


        // GET: api/Registrations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Registration>>> GetRegistration()
        {
            return await _registrationRepository.GetRegistration();
            //return await _context.Registration.ToListAsync();
        }

        // GET: api/Registrations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Registration>> GetRegistration(int id)
        {
            try
            {
                return await _registrationRepository.GetRegistration(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }

        [HttpPost("{email}/{password}")]
        public async Task<ActionResult<Registration>> GetRegistration(string email, string password)
        {
            Hashtable err = new Hashtable();
            try
            {
                var authUser = _registrationRepository.GetRegistration(email, password);
                if (authUser != null)
                {
                    return Ok(authUser);
                }
                else
                {
                    err.Add("Status", "Error");

                    err.Add("Message", "Invalid Credentials");

                    return Ok(err);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
         public async Task<IActionResult> PutRegistration(int id, Registration registration)
        {
            if (id != registration.userid)
            {
                return BadRequest();
            }

            var res = await _registrationRepository.PutRegistration(id, registration);
            if (res != null)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Registrations
        [HttpPost]
        public async Task<ActionResult<Registration>> PostRegistration(Registration registration)
        {
            // _context.Registration.Add(registration);
            //await _context.SaveChangesAsync();
            await _registrationRepository.PostRegistration(registration);

            return CreatedAtAction("GetRegistration", new { id = registration.userid }, registration);
        }


        // DELETE: api/Registrations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Registration>> DeleteRegistration(int id)
        {
            try
            {
                return await _registrationRepository.DeleteRegistration(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }


  
    }
}
