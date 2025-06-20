using CommunityToolkit.Mvvm.ComponentModel;
using FrontSklepu.Models;
using FrontSklepu.Services;
using MvvmHelpers;


namespace FrontSklepu.ViewModels
{
    public partial class AddProductPageViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Category> Categories { get; set; } = new();

        

        [ObservableProperty]
        private Product _addProductModel;
        
        private readonly IProductService productService;

        public AddProductPageViewModel(IProductService productService)
        {
            Title = "Add Product";
            AddProductModel = new Product();
            this.productService = productService;
            LoadCategories();
        }

        private async void LoadCategories()
        {
            var categories = await productService.GetCategoriesAsync();
            if (categories is null)
                return;
            if (categories.Count > 0)
                categories.Clear();

            Categories.AddRange(categories);
        }
    }
}
