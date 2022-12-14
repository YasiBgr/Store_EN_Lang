using _0_FramBase.Application;
using _0_FrameWork.Application;
using ShopManagement.Application.Contracts.ProductCategoryApp;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _repository;
        private readonly IFileUploader _fileUploader;

        public ProductCategoryApplication(IProductCategoryRepository repository, IFileUploader fileUploader)
        {
            _repository = repository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateProductCategory createProductCategory)
        {
           var operation=new OperationResult();
            if (_repository.Exist(x=>x.Name==createProductCategory.Name))
                return operation.Failed("It is not possible to register a duplicate record,please put another Name");
            var slug = createProductCategory.Slug.Slugify();
            var picturePath = $"{createProductCategory.Slug}";
            var pictureName = _fileUploader.UpLoad(createProductCategory.Picture, picturePath);
            var product = new ProductCategory(createProductCategory.Name, createProductCategory.Description, pictureName
                , createProductCategory.PictureAlt, createProductCategory.PictureTitle, createProductCategory.Keywords,
                slug,createProductCategory.MetaDescription);
            _repository.Create(product);
            _repository.Save();
            return operation.Succeeded();
        }

        public OperationResult Edit(EditProductCategory editProductCategory)
        {
            var operation = new OperationResult();
            var productCategory = _repository.Get(editProductCategory.Id);
            if (productCategory == null)
                return operation.Failed("Record Not Found");
                    if (_repository.Exist(x=>x.Name==editProductCategory.Name && x.Id!=editProductCategory.Id))
                return operation.Failed("It is not possible to register a duplicate record, please put another Name");
            var slug = editProductCategory.Slug.Slugify();
            var picturePath = $"{editProductCategory.Slug}";
            var pictureName = _fileUploader.UpLoad(editProductCategory.Picture, picturePath);
            productCategory.Edit(editProductCategory.Name,editProductCategory.Description,pictureName,editProductCategory.PictureAlt,
                editProductCategory.PictureTitle,editProductCategory.Keywords,editProductCategory.Slug,
                editProductCategory.MetaDescription);
          
            _repository.Save();
            return operation.Succeeded();
        }

        public EditProductCategory GetDetails(long Id)
        {
            return _repository.GetDetails(Id);
        }

        public List<ProductCategoryViewModel> Search(SearchProductCategory searchProductCategory)
        {
           return _repository.Search(searchProductCategory);
        }
    }
}
