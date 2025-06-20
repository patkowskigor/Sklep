
using FrontSklepu.Models;

namespace FrontSklepu.Services
{
    public interface IProductService
    {
        Task<List<Category>> GetCategoriesAsync();
    }
}
