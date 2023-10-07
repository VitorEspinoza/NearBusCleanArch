namespace NearBusCleanArch.Domain.Entities
{
    public class Companie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        
        public int AccountId { get; set; }
        public Account Account { get; set; }
        
        public int AdressId { get; set; }
        public Adress Adress { get; set; }
    }
}