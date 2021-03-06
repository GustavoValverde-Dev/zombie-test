using System;
using System.Collections.Generic;
using System.Linq;
using api.Data;
using api.Handlers;
using api.Models;

namespace api.Services
{
    public class UsersService
    {
        private readonly DataContext _context;

        public UsersService(DataContext context)
        {
            this._context = context;
        }

        public List<UserList> GetUsers()
        {
            try
            {
                List<UserList> response = new List<UserList>();

                var users = _context.Users.ToList();

                foreach(var x in users)
                {
                    UserList user = new UserList();

                    user.Id = x.Id;
                    user.Name = x.Name;
                    user.CPF = x.CPF;
                    
                    var groups = _context.UserGroups.Where(y => y.UserId == x.Id).ToList();

                    List<GroupUserList> groupsresult = new List<GroupUserList>();

                    foreach(var g in groups)
                    {
                        var group = _context.Groups.FirstOrDefault(gr => gr.Id == g.GroupId);
                        GroupUserList groupHandler = new GroupUserList();
                        groupHandler.Id = g.Id;
                        groupHandler.Descricao = group.Description;
                        groupHandler.Funcao = _context.Functions.FirstOrDefault(y => y.Id == group.FunctionId)?.Description;
                        groupHandler.Inserido = g.CreationDate;

                        groupsresult.Add(groupHandler);
                    }

                    user.Group = groupsresult;

                    response.Add(user);
                }

                return response;
            }
            catch (System.Exception e)
            {
                var errorMessage = e.InnerException;
                throw;
            }
        }

        public void InsertUser(UserAdd data)
        {
            try
            {
                User user = new User
                {
                    Name = data.Name,
                    CPF = data.CPF,
                    Password = data.Password,
                    CreationDate = DateTime.Now
                };

                _context.Users.Add(user);
                _context.SaveChanges();
                
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}