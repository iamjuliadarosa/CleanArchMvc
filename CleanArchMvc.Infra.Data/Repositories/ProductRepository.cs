using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories {
    public class ProductRepository:IProductRepository {
        ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) {
            _context = context;
        }
        public async Task<Product> CreateAsync(Product _product) {
            _context.Products.Add(_product);
            await _context.SaveChangesAsync();
            return _product;
        }

        public async Task<IEnumerable<Product>> GetProductAsync() {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByCategoryIDAsync(int? _categoryId) {
            //eager loading
            return await _context.Products.Include(c => c.Category)
                .SingleOrDefaultAsync(p => p.Id ==_categoryId);
        }

        public async Task<Product> GetProductByIdAsync(int? _id) {
            return await _context.Products.FindAsync(_id);
        }

        public async Task<Product> RemoveAsync(Product _product) {
            _context.Remove(_product);
            await _context.SaveChangesAsync();
            return _product;
        }

        public async Task<Product> UpdateAsync(Product _product) {
            _context.Update(_product);
            await _context.SaveChangesAsync();
            return _product;
        }
    }
}
