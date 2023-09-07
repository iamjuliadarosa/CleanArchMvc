using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces {
    public interface ICategoryRepository {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategoryById(int? _id);
        Task<Category> Create(Category _category);
        Task<Category> Update(Category _category);
        Task<Category> Remove(Category _category);
    }
}
