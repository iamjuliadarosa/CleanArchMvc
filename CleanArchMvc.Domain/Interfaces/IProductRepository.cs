using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces {
    public interface IProductRepository {
        Task<IEnumerable<Product>> GetProductAsync();
        Task<IEnumerable<Product>> GetProductByCategoryIDAsync(int? _categoryId);
        Task<Product> GetProductByIdAsync(int? _id);
        Task<Product> CreateAsync(Product _product);
        Task<Product> UpdateAsync(Product _product);
        Task<Product> RemoveAsync(Product _product);
    }
}
