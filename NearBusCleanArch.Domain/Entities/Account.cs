namespace NearBusCleanArch.Domain.Entities
{
    public class Account : Entity
    {

        public string Email { get; set; }
        public string Password { get; set; }
        
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}