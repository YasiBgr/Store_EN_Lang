using _0_FrameWork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.ProductApp
{
    public interface IProductApplication
    {
        OperationResult Create(CreateProduct product);
        OperationResult Edit(EditProduct product);
        EditProduct GetDetails(long id);
        List<ProductViewModel> GetProducts();
        List<ProductViewModel> Search(ProductSearchModel searchProduct);
        OperationResult Removed(long id);
        OperationResult Restore(long id);
    }
}
