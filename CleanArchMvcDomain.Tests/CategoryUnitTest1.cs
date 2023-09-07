using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests {
    public class CategoryUnitTest1 {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParamenters_ResultObjectValidState() {
            Action action = () => new Category(1,"Category Name");
            
            action
                .Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category With Invalid State")]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId() {
            Action action = () => new Category(-1,"Category Name");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A Category's ID can not be zero.");
        }

        [Fact(DisplayName = "Create Category With Invalid Name")]
        public void CreateCategory_ShortNameValue_DomainExceptionInvalidId() {
            Action action = () => new Category(1,"Ca");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A Category's Name can not be smaller than 3 characters.");
        }

        [Fact(DisplayName = "Create Category With Null Name")]
        public void CreateCategory_NullNameValue_DomainExceptionInvalidId() {
            Action action = () => new Category(1,null);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A Category's Name can not be null.");
        }

    }
}