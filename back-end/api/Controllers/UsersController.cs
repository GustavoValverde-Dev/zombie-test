using System.Linq;
using System.Net;
using System.Threading.Tasks;
using api.Data;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet("getall")]
        public IActionResult GetUsers()
        {
            try
            {
               var users = new UsersService(_context).GetUsers();
                
                if (!users.Any())
                {
                    return NotFound();
                }
               return Ok(users); 
            }
            catch (System.Exception)
            {
                
                throw;
            }
            
        }
    }
}