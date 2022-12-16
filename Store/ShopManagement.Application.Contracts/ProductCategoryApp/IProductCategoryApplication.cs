using _0_FrameWork.Application;

namespace ShopManagement.Application.Contracts.ProductCategoryApp
{
    public interface IProductCategoryApplication
    {
        OperationResult Create(CreateProductCategory createProductCategory);
        OperationResult Edit(EditProductCategory editProductCategory);
        EditProductCategory GetDetails(long Id);
        List<ProductCategoryViewModel> Search(SearchProductCategory searchProductCategory);
        List<ProductCategoryViewModel> GetProductCategories();
        OperationResult Removed(long Id);
        OperationResult Restore(long Id);

    }
}
