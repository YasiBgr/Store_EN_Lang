using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.ProductApp;
using ShopManagement.Application.Contracts.ProductCategoryApp;

namespace Host.Areas.Administrator.Pages.Shop.Product
{
    public class IndexModel : PageModel
    {
        public ProductSearchModel search;
        public SelectList ProductCategory;
        public List<ProductViewModel> product; //{ get; set; }

        private readonly IProductApplication _productApplication;

        public IndexModel(IProductApplication productApplication, IProductCategoryApplication productCategory)
        {
            _productApplication = productApplication;
            _productCategory = productCategory;
        }

        private readonly IProductCategoryApplication _productCategory;
      

        [TempData]
        public string Message { get;set; }
       

        public void OnGet(ProductSearchModel searchProduct)
        {
            ProductCategory = new SelectList(_productCategory.GetProductCategories(), "Id", "Name"); 
            product= _productApplication.Search(searchProduct);
        }
        public IActionResult OnGetRemoved(long Id)
        {
            var result = _productApplication.Removed(Id);
            if (result.IsSucceeded)
                return RedirectToPage("./Index");
            Message = result.Massage;
            return RedirectToPage("./Index");

        }
        public IActionResult OnGetRestore(long Id)
        {
            var result = _productApplication.Restore(Id);
            if (result.IsSucceeded)
                return RedirectToPage("./Index");
            Message = result.Massage;
            return RedirectToPage("./Index");

        }
    }
}
