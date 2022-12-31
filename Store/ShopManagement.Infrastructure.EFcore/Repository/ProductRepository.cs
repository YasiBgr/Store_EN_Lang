using _0_FrameWork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.ProductApp;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFcore.Repository
{
    public class ProductRepository : RepositoryBase<long, Product>, IProductRepository
    {
        public readonly ShopContext _shopContext;

        public ProductRepository(ShopContext shopContext):base(shopContext)
        {
            _shopContext = shopContext;
        }

        public List<ProductViewModel> GetAll()
        {
           return _shopContext.Products.Select(
               
               x=>new ProductViewModel
               {
                   Name = x.Name,
                   Id = x.Id,
                   Delete = x.Delete,
                   
               }).Where(x=>!x.Delete).ToList();
        }

        public EditProduct GetDetailsById(long id)
        {
            return _shopContext.Products.Select( x => new EditProduct
            {
                Id = x.Id,
                Name = x.Name,
                CategoryId = x.CategoryId,
                Code = x.Code,
                Description = x.Description,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                Slug = x.Slug
            }).FirstOrDefault(x=>x.Id == id);


        }

        public Product GetProductCategory(long id)
        {
            return _shopContext.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductViewModel> Search(ProductSearchModel search)
        {
            var query = _shopContext.Products.Select(x => new ProductViewModel()
            {
                Category = x.Category.Name,
                CategoryId = x.CategoryId,
                Picture = x.Picture,
                Name = x.Name,
                code = x.Code,
                Delete = x.Delete,
                Id = x.Id,
                UnitPrice = x.UnitPrice,
                CreationDate = x.CreationDate.ToString()
            });

            if (!string.IsNullOrWhiteSpace(search.Name))
                query = query.Where(x => x.Name.Contains(search.Name));
            if (search.CategoryID != 0)
                query = query.Where(x => x.CategoryId == search.CategoryID);
            if (!string.IsNullOrWhiteSpace(search.Code))
                query = query.Where(x => x.code.Contains(search.Code));
            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
