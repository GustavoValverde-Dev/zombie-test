namespace api.Handlers
{
    public class UserAdd
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Password { get; set; }
        public int[] GroupsId { get; set; }
    }
}