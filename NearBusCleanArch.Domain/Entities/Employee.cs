using System.Collections.Generic;

namespace NearBusCleanArch.Domain.Entities
{
    public class Employee
    {
        public string Name { get; set; }
        public string Document { get; set; }
        
        public int AdressId { get; set; }
        
        #nullable enable
        public Adress? Adress { get; set; }
        #nullable disable
        
        public int CompanieId { get; set; }
        public Companie Companie { get; set; }
        
        public int AccountId { get; set; }
        public Account Account { get; set; }
        
        public ICollection<Route> Routes { get; } = new List<Route>();
    }
}