using Example.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Example.Models;

namespace Example.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly ApplicationContext _context;

        public UsersController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>>  GetUsers()
        {

            
            if (_context.Users == null)
            {
                return NotFound();
            }
            return await _context.Users.ToListAsync();

            /*
             * IActionResult
            var users = new[]
            {
                new {Name = "oleg"},
                new {Name = "semen"}
            };
            return Ok(users);
         */
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(string name)
        {
            var user = new User
            {
                Name = name
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
