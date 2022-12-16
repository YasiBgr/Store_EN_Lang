using _0_FrameWork.Domain;
using ShopManagement.Application.Contracts.ProductApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductAgg
{
    public interface IProductRepository:IRepository<long, Product>
    {
        List<ProductViewModel>Search(ProductSearchModel model);
        EditProduct GetDetailsById(long id);
        List<ProductViewModel> GetAll();
        Product GetProductCategory(long id);
    
    }
}
