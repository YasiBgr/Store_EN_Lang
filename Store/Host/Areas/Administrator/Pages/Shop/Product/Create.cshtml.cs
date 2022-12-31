using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.ProductApp;
using ShopManagement.Application.Contracts.ProductCategoryApp;

namespace Host.Areas.Administrator.Pages.Shop.Product
{
    public class CreateModel : PageModel
    {
        public CreateProduct category;
        
        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;


        public CreateModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }

        [HttpGet]
        public void OnGet()
        {
             category = new CreateProduct
            {
                Category = _productCategoryApplication.GetProductCategories()
            };

        }
        [HttpPost]
        public IActionResult OnPost(CreateProduct category)
        {
            var productcategory = _productApplication.Create(category);
            return RedirectToPage("./Index");
        }
    }
}
