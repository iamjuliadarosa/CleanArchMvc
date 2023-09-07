using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories {
    public class CategoryRepository:ICategoryRepository {
        ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) {
            _context = context;
        }
        public async Task<Category> Create(Category _category) {
            _context.Add(_category);
            await _context.SaveChangesAsync();
            return _category;
        }

        public async Task<IEnumerable<Category>> GetCategories() {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int? _id) {
            return await _context.Categories.FindAsync(_id);
        }

        public async Task<Category> Remove(Category _category) {
            _context.Remove(_category);
            await _context.SaveChangesAsync();
            return _category;
        }

        public async Task<Category> Update(Category _category) {
            _context.Update(_category);
            await _context.SaveChangesAsync();
            return _category;
        }
    }
}
