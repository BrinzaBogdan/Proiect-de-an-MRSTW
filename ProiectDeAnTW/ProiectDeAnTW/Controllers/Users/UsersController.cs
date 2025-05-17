using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ProiectDeAnMRSTW.Infrastructure.Data;

namespace ProiectDeAnTW.Controllers.Users
{
    [ApiController]
    [Route("api/users")] 
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _appContext;
        private HttpClient HttpClient { get; set; }
        public UsersController(UserManager<ApplicationUser> userManager, ApplicationDbContext appContext)
        {
            _userManager = userManager;
            _appContext = appContext;
        }

        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return Ok(users);
        }

        [HttpDelete("delete-user-by-email")]
        public async Task<IActionResult> DeleteUserByEmail(string email)
        {
            var user = await _appContext.Users.Where(e => e.Email == email).FirstOrDefaultAsync();
            if (user == null)
                return NotFound();

            _appContext.Users.Remove(user);
            _appContext.SaveChanges();

            return NoContent();
        }
    }
}

