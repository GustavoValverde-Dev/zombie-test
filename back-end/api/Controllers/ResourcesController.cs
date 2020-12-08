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
        public IActionResult GetResources([FromHeader] string Token)
        {
            try
            {
                User authUser = new AuthService(_context).GetUserByToken(Token);

                    if (authUser != null)
                    {
                        var resources = new ResourcesService(_context).GetResources();
                        
                        if (!resources.Any())
                        {
                            return BadRequest("Não há recursos.");
                        }
                        return Ok(resources); 
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

        [HttpPost("entry")]
        public IActionResult ResourceEntryInsert([FromHeader] string Token, [FromBody] ResourceMovimentation data)
        {
            try
            {
                    User authUser = new AuthService(_context).GetUserByToken(Token);

                    if (authUser != null)
                    {
                        bool entryCheck = new ResourcesService(_context).ResourceEntryCheck(data);
                        if (entryCheck)
                        {
                            new ResourcesService(_context).InsertResourceEntry(data, authUser.Id);
                        
                            return Ok("Entrada de recurso cadastrada com sucesso.");
                        }
                        else
                        {
                            return BadRequest("Você não pode armazenar essa quantidade.");
                        }
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

        [HttpPost("departure")]
        public IActionResult ResourceDepartureInsert([FromHeader] string Token, [FromBody] ResourceMovimentation data)
        {
            try
            {
                    User authUser = new AuthService(_context).GetUserByToken(Token);

                    if (authUser != null)
                    {
                        bool departureCheck = new ResourcesService(_context).ResourceDepartureCheck(data);
                        if (departureCheck)
                        {
                            new ResourcesService(_context).InsertResourceDeparture(data, authUser.Id);
                        
                            return Ok("Saída de recurso cadastrada com sucesso.");
                        }
                        else
                        {
                            return BadRequest("Você não pode retirar essa quantidade!");
                        }
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