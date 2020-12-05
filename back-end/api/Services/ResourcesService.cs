using System.Collections.Generic;
using System.Linq;
using api.Data;
using api.Handlers;

namespace api.Services
{
    public class ResourcesService
    {
        private readonly DataContext _context;

        public ResourcesService(DataContext context)
        {
            this._context = context;
        }

        public List<ResourceList> GetResources()
        {
            try
            {
                List<ResourceList> response = new List<ResourceList>();

                var resources = _context.Resources.ToList();

                foreach(var x in resources)
                {
                    response.Add(new ResourceList{
                        Nome = x.Name,
                        Descricao = x.Description,
                        Quantidade = x.Quantity,
                        Observacao = x.Observation,
                        InseridoPor = "Gustavo",
                        DataInsercao = x.CreationDate.ToString("dd/MM/yyyy HH:mm:ss")
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