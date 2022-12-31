using _0_FrameWork.Application;
using ShopManagement.Application.Contracts.ProductPictureApp;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _productPictureRepository;
        private readonly IProductRepository _productRepository;
        private readonly IFileUploader _fileUploader;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository, IProductRepository productRepository, IFileUploader fileUploader)
        {
            _productPictureRepository = productPictureRepository;
            _productRepository = productRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateProductPicture model)
        {
            var opperation = new OperationResult();
            var product=_productRepository.GetProductCategory(model.ProductId);
            var path = $"{product.Category.Slug}//{product.Slug}";
            var picturePath = _fileUploader.UpLoad(model.Picture, path);
            var productPicture = new ProductPicture(model.ProductId, picturePath, model.PictureAlt, model.PictureTitle);
            _productPictureRepository.Create(productPicture);
            _productPictureRepository.Save();
            return opperation.Succeeded();
        }

        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var productPicure=_productPictureRepository.Get(id);
            if (productPicure == null)
                operation.Failed(ApplicationMessage.RecordNotFound);
            productPicure.Removed();
            _productPictureRepository.Save();
            return operation.Succeeded();
        }

        public OperationResult Edit(EditProductPicture model)
        {
            var opperation = new OperationResult();
            var product = _productPictureRepository.GetCategoryWithProduct(model.ProductId);
            var path = $"{product.Product.Slug}//{product.Product.Slug}";
            var picturePath = _fileUploader.UpLoad(model.Picture, path);
            product.Edit(model.ProductId, picturePath, model.PictureAlt, model.PictureTitle);
           
            _productPictureRepository.Save();
            return opperation.Succeeded();
        }

        public EditProductPicture GetDetails(long id)
        {
          return  _productPictureRepository.GetDetails(id);
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var productPicure = _productPictureRepository.Get(id);
            if (productPicure == null)
                operation.Failed(ApplicationMessage.RecordNotFound);
            productPicure.Restore();
            _productPictureRepository.Save();
            return operation.Succeeded();
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel model)
        {
            return _productPictureRepository.Search(model);   
        }
    }
}
