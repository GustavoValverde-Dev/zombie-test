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
    public class GroupsController : ControllerBase
    {
        private readonly DataContext _context;

        public GroupsController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet("getall")]
        public IActionResult GetGroups()
        {
            try
            {
               var groups = new GroupsService(_context).GetGroups();
                
                if (!groups.Any())
                {
                    return NotFound();
                }
               return Ok(groups); 
            }
            catch (System.Exception)
            {
                
                throw;
            }
            
        }
    }
}