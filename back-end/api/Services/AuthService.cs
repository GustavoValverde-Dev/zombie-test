using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using api.Data;
using api.Handlers;
using api.Models;

namespace api.Services
{
    public class AuthService
    {
        private readonly DataContext _context;

        public AuthService(DataContext context)
        {
            this._context = context;
        }

        public bool Authentication(LoginHandler data)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.CPF == data.CPF && x.Password == data.Senha);

                if (user == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public UserDataHandler GetUserByToken(string token)
        {
            try
            {
                var tokenActive = _context.TokenLogs.FirstOrDefault(x => x.Token == token && x.Active == true && DateTime.Now < x.ValidThru);

                if (tokenActive == null)
                {
                    return null;
                }
                else
                {
                    var user = _context.Users.FirstOrDefault(x => x.Id == tokenActive.UserId);

                    var groups = _context.UserGroups.Where(y => y.UserId == user.Id).ToList();

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

                    UserDataHandler response = new UserDataHandler
                    {
                        Id = user.Id,
                        Name = user.Name,
                        CPF = user.CPF,
                        Group = groupsresult,
                        Token = token
                    };

                    return response;
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public string GenerateToken(string cpf)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.CPF == cpf);

                if (user != null)
                {
                    var checkTokenExistence = _context.TokenLogs.FirstOrDefault(x => x.UserId == user.Id && x.Active == true);

                    if (checkTokenExistence != null)
                    {
                        checkTokenExistence.Active = false;
                        _context.TokenLogs.Update(checkTokenExistence);
                        _context.SaveChanges();
                    }

                    var token = MD5Hash(cpf + DateTime.Now.ToString());

                    TokenLog auth = new TokenLog
                    {
                        Active = true,
                        Token = token,
                        UserId = user.Id,
                        ValidThru = DateTime.Now.AddDays(3),
                        CreationDate = DateTime.Now
                    };

                    _context.TokenLogs.Add(auth);
                    _context.SaveChanges();

                    return token;
                }
                else
                {
                    return null;
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        

        public static string MD5Hash(string text)  
        {  
        MD5 md5 = new MD5CryptoServiceProvider();  

        //compute hash from the bytes of text  
        md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));  
    
        //get hash result after compute it  
        byte[] result = md5.Hash;  

        StringBuilder strBuilder = new StringBuilder();  
        for (int i = 0; i < result.Length; i++)  
        {  
            //change it into 2 hexadecimal digits  
            //for each byte  
            strBuilder.Append(result[i].ToString("x2"));  
        }  

        return strBuilder.ToString();  
        }  
    }
}