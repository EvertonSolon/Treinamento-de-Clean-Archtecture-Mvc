using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity
    {
        public Category(string name)
        {
            //Name = name;
            ValidateDomain(name);
            Name = name;
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Id must be greater than 0!");
            Id = id;

            ValidateDomain(name);
            Name = name;
        }

        public string Name { get; private set; }
        public ICollection<Product> Products { get; set; }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Empty name is not allowed!");
            DomainExceptionValidation.When(name.Length < 3, "Too short name! Minimum 3 characteres");
        }

        public void Update(string name)
        {
            ValidateDomain(name);
            Name = name;
        }
    }
}
