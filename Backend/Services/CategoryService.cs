using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Shop.Library.Models;

namespace Backend.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext appDbContext;
        public CategoryService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<List<Category>> GetCategoriesAsync() => await appDbContext.Categories.ToListAsync();
      
    }
}
