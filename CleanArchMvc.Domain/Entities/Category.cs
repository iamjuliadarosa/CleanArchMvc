using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities {
    public sealed class Category:Entity {
        public string? Name { get; private set; }
        public Category(string _name) {
            ValidateDomain(_name);
        }
        public Category(int _id,string _name) {
            DomainExceptionValidation.When(_id <= 0,"A Category's ID can not be zero.",new ArgumentException("A Category's Name can not be zero."));
            Id = _id;
            ValidateDomain(_name);
        }
        public void Update(string _name) {
            ValidateDomain(_name);
        }
        public ICollection<Product>? Products { get; set; }
        private void ValidateDomain(string _name) {
            DomainExceptionValidation.When(string.IsNullOrEmpty(_name),"A Category's Name can not be null.",new ArgumentNullException("A Category's Name can not be null."));
            DomainExceptionValidation.When(_name.Length < 3,"A Category's Name can not be smaller than 3 characters.",new ArgumentException("A Category's Name can not be smaller than 3 characters."));
            Name = _name;
        }
    }
}
