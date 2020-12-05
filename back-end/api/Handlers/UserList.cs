using System.Collections.Generic;

namespace api.Handlers
{
    public class UserList
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public List<GroupUserList> Grupo { get; set; }
    }
}