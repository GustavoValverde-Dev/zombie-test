using System;
using System.Collections.Generic;
using System.Linq;
using api.Data;
using api.Handlers;
using api.Models;

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

        public void InsertGroup(GroupAdd data, int creationUserId)
        {
            try
            {
                Group newGroup = new Group
                {
                    Description = data.Description,
                    FunctionId = data.Function,
                    CreationUserId = creationUserId,
                    CreationDate = DateTime.Now
                };

                _context.Groups.Add(newGroup);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public void EditGroup(GroupAdd data, int creationUserId)
        {
            try
            {
                Group newGroup = new Group
                {
                    Description = data.Description,
                    FunctionId = data.Function,
                    CreationUserId = creationUserId,
                    CreationDate = DateTime.Now
                };

                _context.Groups.Add(newGroup);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}