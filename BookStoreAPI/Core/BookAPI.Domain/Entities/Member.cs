namespace BookAPI.Domain.Entites
{
    public class Member
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
