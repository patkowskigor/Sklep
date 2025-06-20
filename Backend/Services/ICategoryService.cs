using Shop.Library.Models;

namespace Backend.Services
{
    public interface ICategoryService 
    {
        Task<List<Category>> GetCategoriesAsync();
    }
}
