using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities {
    public sealed class Product:Entity {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string? Image { get; private set; }
        public Product(string _name,string _description,decimal _price,int _stock,string? _image) {
            ValidateDomain(_name,_description,_price,_stock,_image);
        }
        public Product(int _id,string _name,string _description,decimal _price,int _stock,string? _image) {
            DomainExceptionValidation.When(_id <= 0,"A Product's ID can not be zero.",new ArgumentException("A Product's Name can not be zero."));
            Id = _id;
            ValidateDomain(_name,_description,_price,_stock,_image);
        }
        public void Update(string _name,string _description,decimal _price,int _stock,string? _image,int _categoryId) {
            ValidateDomain(_name,_description,_price,_stock,_image);
            CategoryID = _categoryId;
        }

        public int CategoryID { get; set; }
        public Category? Category { get; set; }
        private void ValidateDomain(string _name,string _description,decimal _price,int _stock,string? _image) {

            DomainExceptionValidation.When(string.IsNullOrEmpty(_name),"A Product's Name can not be null.",new ArgumentNullException("A Product's Name can not be null."));
            DomainExceptionValidation.When(_name.Length < 3,"A Product's Name can not be smaller than 3 characters.",new ArgumentException("A Product's Name can not be smaller than 3 characters."));
            Name = _name;
            DomainExceptionValidation.When(string.IsNullOrEmpty(_description),"A Product's Description can not be null.",new ArgumentNullException("A Product's Description can not be null."));
            DomainExceptionValidation.When(_description.Length < 5,"A Product's Description can not be smaller than 5 characters.",new ArgumentException("A Product's Description can not be smaller than 5 characters."));
            Description = _description;
            DomainExceptionValidation.When(_price <= 0,"A Product's Price can not be zero.",new ArgumentException("A Product's Price can not be zero."));
            Price = _price;
            DomainExceptionValidation.When(_stock <= 0,"A Product's Stock can not be zero.",new ArgumentException("A Product's Stock can not be zero."));
            Stock = _stock;
            DomainExceptionValidation.When(_image?.Length < 250,"A Product's Image can not be bigger than 250 characters.",new ArgumentException("A Product's Image can not be bigger than 250 characters."));
            Image = _image;
        }
    }
}
