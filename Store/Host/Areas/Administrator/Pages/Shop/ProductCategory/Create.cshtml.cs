using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductCategoryApp;

namespace Host.Areas.Administrator.Pages.Shop.ProductCategory
{
    public class CreateModel : PageModel
    {
        public CreateProductCategory category;
        private readonly IProductCategoryApplication _productCategoryApplication;

        public CreateModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }
        [HttpGet]
        public void OnGet()
        {
        }
        [HttpPost]
        public IActionResult OnPost(CreateProductCategory category)
        {
            var productcategory=_productCategoryApplication.Create(category);
            return RedirectToPage("./Index");
        }
    }
}
