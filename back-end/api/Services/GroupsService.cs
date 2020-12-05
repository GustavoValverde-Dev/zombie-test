using System.Collections.Generic;
using System.Linq;
using api.Data;
using api.Handlers;

namespace api.Services
{
    public class GroupsService
    {
        private readonly DataContext _context;

        public GroupsService(DataContext context)
        {
            this._context = context;
        }

        public List<GroupList> GetGroups()
        {
            try
            {
                List<GroupList> response = new List<GroupList>();

                var groups = _context.Groups.ToList();

                foreach(var x in groups)
                {
                    response.Add(new GroupList{
                        Id = x.Id,
                        Descricao = x.Description,
                        Funcao = _context.Functions.FirstOrDefault(y => y.Id == x.FunctionId)?.Description
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