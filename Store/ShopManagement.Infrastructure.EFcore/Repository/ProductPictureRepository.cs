

using _0_FrameWork.Domain;
using _0_FrameWork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.ProductPictureApp;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPictureAgg;
using System.Linq.Expressions;

namespace ShopManagement.Infrastructure.EFcore.Repository
{
    public class ProductPictureRepository : RepositoryBase<long, ProductPicture>,IProductPictureRepository
    {
        private readonly ShopContext _shopContext;

        public ProductPictureRepository(ShopContext shopContext):base(shopContext)
        {
            _shopContext = shopContext;
        }

        public ProductPicture GetCategoryWithProduct(long id)
        {
            return _shopContext.ProductPictures.Include(x => x.Product).ThenInclude(x => x.Category).FirstOrDefault(x => x.Id == id);

        }

        public EditProductPicture GetDetails(long id)
        {
            return _shopContext.ProductPictures.Select(x => new EditProductPicture
            {
                Id = x.Id,
                // Picture=x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ProductId = x.ProductId
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel productPictureSearchModel)
        {
            var query = _shopContext.ProductPictures.Include(x => x.Product).Select(x => new ProductPictureViewModel
            {
                Product = x.Product.Name,
                CreationDate = x.CreationDate.ToString(),
                Id = x.Id,
                Picture = x.Picture,
                ProductId = x.ProductId,
                Isremoved = x.IsRemoved
            });
            if (productPictureSearchModel.ProductId != 0)
                query = query.Where(x => x.ProductId == productPictureSearchModel.ProductId);
            return query.Where(x => !x.Isremoved).OrderByDescending(x => x.Id).ToList();

        }
    }
}
