using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category name");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category With Negative Id Value and Exception Invalid")]
        public void CreateCategory_WithNegativeValue_ResultExceptionInvalid()
        {
            Action action = () => new Category(-1, "Category name");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Id must be greater than 0!");
        }

        [Theory(DisplayName = "Create Category With Negative Id Value Parameter and Exception Invalid")]
        [InlineData(-1)]
        public void DontCreateCategory_WithNegativeValueParameter_ResultExceptionInvalid(int value)
        {
            Action action = () => new Category(value, "Category name");
            action.Should()
                .Throw<DomainExceptionValidation>();
        }
    }
}