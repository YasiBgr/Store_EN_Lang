using _0_FrameWork.Domain;
using _0_FrameWork.Infrastructure;
using ShopManagement.Application.Contracts.ProductCategoryApp;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFcore.Repository
{
    public class ProductCategoryRepository : RepositoryBase<long, ProductCategory>, IProductCategoryRepository
    {
        private readonly ShopContext _context;

        public ProductCategoryRepository(ShopContext context) : base(context)
        {
            _context = context;
        }
      
        public EditProductCategory GetDetails(long id)
        {
            return _context.ProductCategories.Select(x => new EditProductCategory()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductCategoryViewModel> Search(SearchProductCategory searchProductCategory)
        {
            var query = _context.ProductCategories.Select(x => new ProductCategoryViewModel()
            {

                Id = x.Id,
                CreationDate = x.CreationDate.ToString(),
                Name = x.Name,
                Picture = x.Picture

            });
            if (!string.IsNullOrWhiteSpace(searchProductCategory.Name))
                query = query.Where(x => x.Name.Contains(searchProductCategory.Name));
            return query.OrderByDescending(x=>x.Id).ToList();
                   
         }
    }
}