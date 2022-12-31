using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductApp;
using ShopManagement.Application.Contracts.ProductCategoryApp;

namespace Host.Areas.Administrator.Pages.Shop.Product
{
    public class EditModel : PageModel
    {

        public EditProduct category;
        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;

        public EditModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }

        [HttpGet]
        public void OnGet(long id)
        {
            category= _productApplication.GetDetails(id);
            category.Category = _productCategoryApplication.GetProductCategories();

        }
        [HttpPost]
        public IActionResult OnPost(EditProduct category)
        {
            var productcategory = _productApplication.Edit(category);
            return RedirectToPage("./Index");
        }
    }
}
