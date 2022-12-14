using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductCategoryApp;

namespace Host.Areas.Administrator.Pages.Shop.ProductCategory
{
    public class IndexModel : PageModel
    {
        private readonly IProductCategoryApplication _productCategoryApplication;

        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        public List<ProductCategoryViewModel> productCategories; //{ get; set; }
        

        public void OnGet(SearchProductCategory searchProductCategory)
        {

            productCategories = _productCategoryApplication.Search(searchProductCategory);
        }
        public IActionResult OnGetCreate()
        {
           return RedirectToAction("Create");
        }
        public JsonResult OnPostCreate(CreateProductCategory command)
        {
            var result = _productCategoryApplication.Create(command);
            return new JsonResult(result);
        }

     
    }
}
