using _0_FramBase.Application;
using _0_FrameWork.Application;
using ShopManagement.Application.Contracts.ProductApp;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication

    {
        public readonly IProductRepository _productRepository;
        public readonly IProductCategoryRepository _productCategoryRepository;
        public readonly IFileUploader _fileUploader;

        public ProductApplication(IProductRepository productRepository, IFileUploader fileUploader, IProductCategoryRepository productCategoryRepository)
        {
            _productRepository = productRepository;
            _fileUploader = fileUploader;
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreateProduct product)
        {
            var operation = new OperationResult();
            if (_productRepository.Exist(x => x.Name == product.Name))
                return operation.Failed(ApplicationMessage.DuplicationRecords);
            var slug = product.Slug.Slugify;
            var categorySlug=_productCategoryRepository.GetSlugById(product.CategoryId);
            var picturePath = $"{categorySlug}//{slug}";
            var pictureName = _fileUploader.UpLoad(product.Picture, picturePath);
            var newProduct = new Product(product.Name, product.Description, product.Code, product.UnitPrice,
                product.ShortDescription, pictureName, product.PictureAlt, product.PictureTitle, product.CategoryId, product.Slug
                , product.Keywords, product.MetaDescription);
            _productRepository.Create(newProduct);
            _productRepository.Save();
            return operation.Succeeded(); }


        public OperationResult Edit(EditProduct product)
        {

            var operation = new OperationResult();
            var editProduct = _productRepository.Get(product.Id);
            if (product == null)
            {
                return operation.Failed(ApplicationMessage.RecordNotFound);
            }
            if (_productRepository.Exist(x => x.Name == product.Name && x.Id != product.Id))
                return operation.Failed(ApplicationMessage.DuplicationRecords);
            var slug = product.Slug.Slugify;
            var categorySlug = _productCategoryRepository.GetSlugById(editProduct.CategoryId);

            var picturePath = $"{categorySlug}//{slug}"; ;
            var pictureName = _fileUploader.UpLoad(product.Picture, picturePath);
            editProduct.Edit(product.Name, product.Description, product.Code, product.UnitPrice,
               product.ShortDescription, pictureName, product.PictureAlt, product.PictureTitle, product.CategoryId, product.Slug
               , product.Keywords, product.MetaDescription);

            _productRepository.Save();
            return operation.Succeeded();
        }

        public EditProduct GetDetails(long id)
        {
            return _productRepository.GetDetailsById(id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _productRepository.GetAll();
        }

            public List<ProductViewModel> Search(ProductSearchModel searchProduct)
            {
                return _productRepository.Search(searchProduct).ToList();
            }
     

        public OperationResult Removed(long id)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(id);
            if (product == null)
            {
                operation.Failed(ApplicationMessage.RecordNotFound);
            }
            product.DeleteCategory();
            _productRepository.Save();
            return operation.Succeeded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var product=_productRepository.Get(id);
            if (product==null)
            {
                operation.Failed(ApplicationMessage.RecordNotFound);
            }
            product.RestoreCategory();
            _productRepository.Save();
            return operation.Succeeded();
        }

     
    }
}
