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
    public class FunctionsController : ControllerBase
    {
        private readonly DataContext _context;

        public FunctionsController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet("getall")]
        public IActionResult GetFunctions()
        {
            try
            {
               var functions = new FunctionsService(_context).GetFunctions();
                
                if (!functions.Any())
                {
                    return NotFound();
                }
               return Ok(functions); 
            }
            catch (System.Exception)
            {
                
                throw;
            }
            
        }
    }
}