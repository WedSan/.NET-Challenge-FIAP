using Domain;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace web.Controllers
{
    [ApiController]
    [Route("api/teste")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("user")]
        public async Task<ActionResult<User>> createUser(string name, string email, string password, char gender)
        {

            Gender genderParsed = Enum.Parse<Gender>(gender.ToString());

            User user = new User
            { 
                Name = name,
                Email = email,
                Password = password,
                Gender = genderParsed
            };

           return await _context.Users.AddAsync(user);
        }
    }
}
