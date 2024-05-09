using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SaveUrShowUsingCFA.Controllers;
using SaveUrShowUsingCFA.Dto;
using SaveUrShowUsingCFA.models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SaveUrShowUsingCFA.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly SaveUrShowUsingCFADbContext _context;
        private readonly ILogger<RegistrationsController> _logger;
        private readonly IConfiguration _configuration;

        public RegistrationRepository(SaveUrShowUsingCFADbContext context, ILogger<RegistrationsController> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }
        public async Task<ActionResult<IEnumerable<Registration>>> GetRegistration()
        {
            // _logger.LogInformation["Getting all the users successfully."];
            return await _context.Registration.ToListAsync();
            //throw new NotImplementedException();
        }

        public async Task<ActionResult<Registration>> GetRegistration(int id)
        {
            var registration = await _context.Registration.FindAsync(id);

            return registration;
        }

        public LoginResponse GetRegistration(string email, string password)
        {
            /* var registration = await _context.Registration.FirstOrDefaultAsync(record => record.email == email && record.password == password);
             return registration;*/
            var userExist = _context.Registration.FirstOrDefault(t => t.email == email && EF.Functions.Collate(t.password, "SQL_Latin1_General_CP1_CS_AS") == password);
            if (userExist != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[]
                {
         new Claim(ClaimTypes.Email,userExist.email),
         new Claim("UserId",userExist.userid.ToString()),
         new Claim(ClaimTypes.Role,userExist.usertype)
     };
                var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.Now.AddMinutes(30), signingCredentials: credentials);
                var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                var response = new LoginResponse
                {
                    Token = jwtToken,
                };
                return response;
            }
            return null;
        }
        public async Task<ActionResult<Registration>> PostRegistration(Registration registration)
        {
            _context.Registration.Add(registration);
            await _context.SaveChangesAsync();
            return registration;
        }

        public async Task<ActionResult<Registration>> PutRegistration(int id, Registration registration)
        {
            /*context.Entry(registration).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return registration;*/
            var user = _context.Registration.FirstOrDefault(t => t.userid == registration.userid);
            if (user != null)
            {
                user.username = registration.username;
                user.password = registration.password;
                user.email = registration.email;
                user.confirmpassword = registration.confirmpassword;

            }
            _context.SaveChanges();
            return user;

        }

        public async Task<ActionResult<Registration>> DeleteRegistration(int id)
        {
            var registration = await _context.Registration.FindAsync(id);
            _context.Registration.Remove(registration);
            await _context.SaveChangesAsync();
            return registration;
        }

        private bool RegistrationExists(int id)
        {
            return _context.Registration.Any(e => e.userid == id);
        }
    }
}
