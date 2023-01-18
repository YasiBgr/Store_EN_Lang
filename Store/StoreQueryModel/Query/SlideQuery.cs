using ShopManagement.Infrastructure.EFcore;
using StoreQueryModel.Contract.Slide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreQueryModel.Query
{
    public class SlideQuery : ISlideQuery
    {
        private readonly ShopContext shopContext;

        public SlideQuery(ShopContext shopContext)
        {
            this.shopContext = shopContext;
        }

        public List<SlideQueryModel> GetListSlide()
        {
            return shopContext.Slides.Where(x => x.IsRemove == false)
                .Select(x => new SlideQueryModel
                { 
                    BtnText = x.BtnText,
                    Heading=x.Heading,
                    Link=x.Link,
                    Picture=x.Picture,
                    PictureAlt=x.PictureAlt,
                    PictureTitle=x.PictureTitle,
                    Text=x.Text,
                    Title = x.Title
                }).ToList();
                
        }
    }
}
