using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id <= 0, "Id must be greater than 0!");
            Id = id;

            ValidateDomain(name, description, price, stock, image);
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Empty name is not allowed!");
            DomainExceptionValidation.When(name.Length < 3, "Too short name! Minimum 3 characteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Empty name is not allowed!");
            DomainExceptionValidation.When(description.Length < 3, "Too short name! Minimum 3 characteres");

            DomainExceptionValidation.When(price <= 0, "Value must be greater than 0!");
            DomainExceptionValidation.When(stock < 0, "Stock must be greater than 0!");

            DomainExceptionValidation.When(image.Length > 250, "Image name too long! Max 250 characters.");
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
            CategoryId = categoryId;
        }
    }
}
