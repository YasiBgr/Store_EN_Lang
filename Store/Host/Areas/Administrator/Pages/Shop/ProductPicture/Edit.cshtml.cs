using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductApp;
using ShopManagement.Application.Contracts.ProductCategoryApp;
using ShopManagement.Application.Contracts.ProductPictureApp;

namespace Host.Areas.Administrator.Pages.Shop.ProductPicture
{
    public class EditModel : PageModel
    {
        public EditProductPicture ProductPicture;
        private readonly IProductPictureApplication _productPictureApplication;
        private readonly IProductApplication _productApplication;

        public EditModel(IProductPictureApplication productPictureApplication, IProductApplication productApplication)
        {
            _productPictureApplication = productPictureApplication;
            _productApplication = productApplication;
        }

        [HttpGet]
        public void OnGet(long id)
        {
            ProductPicture = _productPictureApplication.GetDetails(id);
            ProductPicture.Products = _productApplication.GetProducts();
            //ProductPicture = new EditProductPicture
            //{
            //    Products = _productApplication.GetProducts(),
            //};
        }
        [HttpPost]
        public IActionResult OnPost(EditProductPicture editProductPicture)
        {
            var productcategory = _productPictureApplication.Edit( editProductPicture);
            return RedirectToPage("./Index");
        }
    }
}
