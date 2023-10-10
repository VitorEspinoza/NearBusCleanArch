using NearBusCleanArch.Domain.Validation;

namespace NearBusCleanArch.Domain.Entities
{
    public sealed class Role : Entity
    { public string Name { get; private set; }

        public Role(string name)
        {
            ValidateDomain(name);
        }

        public Role(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value"); 
            ValidateDomain(name);

        }
        public void Update(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short. Minimum 3 characters.");

            Name = name;
        }
      
    }
}