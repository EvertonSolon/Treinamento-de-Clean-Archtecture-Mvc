using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product With Negative Id Value and Exception Invalid")]
        public void CreateProduct_WithNullImageName_NotNullReferenceException()
        {
            Action action = () => new Product(1, "Product name", "Product description", 9.99m, 99, null);
            action.Should()
                .Throw<NullReferenceException>();
                //.WithMessage("Null product name is not allowed!");
        }
    }
}
