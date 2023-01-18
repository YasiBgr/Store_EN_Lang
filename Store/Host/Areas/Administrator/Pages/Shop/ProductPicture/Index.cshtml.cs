using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductPictureApp;

namespace Host.Areas.Administrator.Pages.Shop.ProductPicture
{
    public class IndexModel : PageModel
    {
        private readonly IProductPictureApplication _productPictureApplication;

        public IndexModel(IProductPictureApplication productPictureApplication)
        {
            _productPictureApplication = productPictureApplication;
        }

        public List<ProductPictureViewModel> productPictures; //{ get; set; }


        public void OnGet(ProductPictureSearchModel productPictureSearchModel)
        {
            productPictures = _productPictureApplication.Search(productPictureSearchModel);
        }

    }
}
