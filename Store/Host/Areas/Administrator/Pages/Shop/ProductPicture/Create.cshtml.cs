using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductApp;
using ShopManagement.Application.Contracts.ProductPictureApp;
using ShopManagement.Domain.ProductPictureAgg;

namespace Host.Areas.Administrator.Pages.Shop.ProductPicture
{
    public class CreateModel : PageModel
    {
        private readonly IProductApplication _product;
        private readonly IProductPictureApplication _productPicture;
        public CreateProductPicture ProductPicture;
        public CreateModel(IProductApplication product, IProductPictureApplication productPicture)
        {
            _product = product;
            _productPicture = productPicture;
        }

        [HttpGet]
        public void OnGet()
        {
            ProductPicture = new CreateProductPicture
            {
                Products = _product.GetProducts(),
            };
        }

        [HttpPost]
        public IActionResult OnPost(CreateProductPicture ProductPicture)
        {
            var productPicture = _productPicture.Create(ProductPicture);
            return RedirectToPage("./Index");
        }
    }
}
