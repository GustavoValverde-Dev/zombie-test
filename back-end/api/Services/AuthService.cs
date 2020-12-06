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