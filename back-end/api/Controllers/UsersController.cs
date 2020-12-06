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


        [HttpPost("add")]
        public IActionResult UserRegisterInsideSystem([FromHeader] string Token, [FromBody] UserAdd data)
        {
            try
            {
                //Autênticação
                User auth = new AuthService(_context).GetUserByToken(Token);

                if (auth != null)
                {
                    User verify = _context.Users.FirstOrDefault(x => x.CPF == data.CPF);

                    if (verify == null)
                    {
                        new UsersService(_context).InsertUser(data);
                        
                        return Ok("Usuário criado com sucesso.");
                    }
                    else
                    {
                        return BadRequest("Usuário já cadastrado.");
                    }
                }
                else
                {
                    return Unauthorized("Token inválido ou expirado.");
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}