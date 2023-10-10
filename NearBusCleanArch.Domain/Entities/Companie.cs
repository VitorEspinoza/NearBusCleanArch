using NearBusCleanArch.Domain.Validation;

namespace NearBusCleanArch.Domain.Entities
{
    public class Companie: Entity
    {
        public string Name { get; private set; }
        public string Document { get; private set; }
        
        public Companie(string name, string document)
        {
            ValidateDomain(name, document);
        }

        public Companie(int id, string name, string document)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value"); 
            ValidateDomain(name, document);

        }

        public void Update(string name, string document)
        {
            ValidateDomain(name, document);
        }
        private void ValidateDomain(string name, string document)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short. Minimum 3 characters.");
            
            DomainExceptionValidation.When(string.IsNullOrEmpty(document), "Invalid document. document is required");
            DomainExceptionValidation.When(!ValidateCnpj.IsCnpj(document), "Invalid document. Incorrect document format");

            Name = name;
            Document = document;
        }
        
        
     public int AdressId { get; set; }
     public Adress Adress { get; set; }

    }
}