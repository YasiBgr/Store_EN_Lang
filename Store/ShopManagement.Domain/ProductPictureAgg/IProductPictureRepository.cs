using _0_FrameWork.Domain;
using ShopManagement.Application.Contracts.ProductPictureApp;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public interface IProductPictureRepository:IRepository<long,ProductPicture>
    {
        EditProductPicture GetDetails(long id);
        ProductPicture GetCategoryWithProduct(long id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel productPictureSearchModel);

    }
}
