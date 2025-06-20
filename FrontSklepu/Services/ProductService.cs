using FrontSklepu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FrontSklepu.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;
        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<List<Category>> GetCategoriesAsync()
        {
            var categories = await httpClient.GetAsync("https://localhost:7003/api/Products/categories");
            var respnse = await categories.Content.ReadFromJsonAsync<List<Category>>();
            return respnse;
        }
    }
}
