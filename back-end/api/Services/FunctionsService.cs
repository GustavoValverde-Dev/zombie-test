using System.Collections.Generic;
using System.Linq;
using api.Data;
using api.Handlers;

namespace api.Services
{
    public class FunctionsService
    {
        private readonly DataContext _context;

        public FunctionsService(DataContext context)
        {
            this._context = context;
        }

        public List<OptionHandler> GetFunctions()
        {
            try
            {
                List<OptionHandler> response = new List<OptionHandler>();

                var functions = _context.Functions.ToList();

                foreach(var x in functions)
                {
                    response.Add(new OptionHandler{
                        Id = x.Id,
                        Descricao = x.Description
                    });
                }

                return response;
            }
            catch (System.Exception e)
            {
                var errorMessage = e.InnerException;
                throw;
            }
        }
    }
}