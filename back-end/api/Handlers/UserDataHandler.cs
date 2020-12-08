using System.Collections.Generic;

namespace api.Handlers
{
    public class UserDataHandler
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public List<GroupUserList> Group { get; set; }
        public string Token { get; set; }
    }
}