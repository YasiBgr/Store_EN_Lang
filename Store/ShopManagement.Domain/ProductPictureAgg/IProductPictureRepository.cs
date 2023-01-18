using _0_FrameWork.Domain;
using ShopManagement.Application.Contracts.ProductPictureApp;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public interface IProductPictureRepository:IRepository<long,ProductPicture>
    {
        EditProductPicture GetDetails(long id);
        ProductPicture GetCategoryWithProduct(long id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel productPictureSearchModel);

    }
}
