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
    public class ResourcesController : ControllerBase
    {
        private readonly DataContext _context;

        public ResourcesController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet("getall")]
        public IActionResult GetResources()
        {
            try
            {
               var resources = new ResourcesService(_context).GetResources();
                
                if (!resources.Any())
                {
                    return NotFound();
                }
               return Ok(resources); 
            }
            catch (System.Exception)
            {
                
                throw;
            }
            
        }
    }
}