using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductCategoryApp;

namespace Host.Areas.Administrator.Pages.Shop.ProductCategory
{
    public class EditModel : PageModel
    {
        public EditProductCategory category;
        private readonly IProductCategoryApplication _productCategoryApplication;

        public EditModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        [HttpGet]
        public void OnGet(long id)
        {
            category = _productCategoryApplication.GetDetails(id);
          
        }
        [HttpPost]
        public IActionResult OnPost(EditProductCategory category)
        {
            var productcategory=_productCategoryApplication.Edit(category);
            return RedirectToPage("./Index");
        }
    }
}
