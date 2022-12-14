using _0_FrameWork.Domain;
using ShopManagement.Application.Contracts.ProductCategoryApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository:IRepository<long,ProductCategory>
    {
        List<ProductCategoryViewModel> Search(SearchProductCategory searchProductCategory);
        EditProductCategory GetDetails(long id);
       

    }
}
