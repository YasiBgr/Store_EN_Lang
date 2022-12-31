using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.ProductApp;
using ShopManagement.Application.Contracts.ProductCategoryApp;

namespace Host.Areas.Administrator.Pages.Shop.Product
{
    public class IndexModel : PageModel
    {
        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategory;
        public SelectList ProductCategory;
        public ProductSearchModel search;
        public IndexModel(IProductApplication productApplication, IProductCategoryApplication productCategory)
        {
            _productApplication = productApplication;
            _productCategory = productCategory;
        }

        public List<ProductViewModel> product; //{ get; set; }


        public void OnGet(ProductSearchModel searchProduct)
        {
            ProductCategory = new SelectList(_productCategory.GetProductCategories(), "Id", "Name"); 
            product= _productApplication.Search(searchProduct);
        }
        //public IActionResult OnGetCreate()
        //{
        //    return RedirectToAction("Create");
        //}
      
        //public IActionResult OnGetEdit(long id)
        //{
        //    return RedirectToAction("Edit");
        //}
    }
}
