using api.Data;
using api.Handlers;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;

        public AuthController(DataContext context)
        {
            this._context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginHandler data)
        {
            try
            {
                bool auth = new AuthService(_context).Authentication(data);

                if (auth == true)
                {
                    string token = new AuthService(_context).GenerateToken(data.CPF);

                    if (token != null)
                    {
                        User userData = new AuthService(_context).GetUserByToken(token);

                        return Ok(userData);
                    }
                    else
                    {
                        return BadRequest("Usuário inválido.");
                    }
                }
                else
                {
                    return NotFound("CPF ou Senha incorretos.");
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

    }
}