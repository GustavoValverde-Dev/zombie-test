using System.Linq;
using System.Net;
using System.Threading.Tasks;
using api.Data;
using api.Handlers;
using api.Models;
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


        [HttpPost("add")]
        public IActionResult ResourceInsert([FromHeader] string Token, [FromBody] ResourceAdd data)
        {
            try
            {
                    User authUser = new AuthService(_context).GetUserByToken(Token);

                    if (authUser != null)
                    {
                        new ResourcesService(_context).InsertResource(data, authUser.Id);
                        
                        return Ok("Recurso criado com sucesso.");
                    }
                    else
                    {
                        return Unauthorized("Token inválido.");
                    }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}