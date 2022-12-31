using _0_FrameWork.Application;

namespace ShopManagement.Application.Contracts.ProductPictureApp
{
    public interface IProductPictureApplication
    {
        OperationResult Create(CreateProductPicture model);
        OperationResult Edit(EditProductPicture model);
        OperationResult Delete(long id);
        OperationResult Restore(long id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel model);
        EditProductPicture GetDetails(long id);

    }
}
