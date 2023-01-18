using _0_FrameWork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.SlideApp;
using ShopManagement.Domain.SlideAgg;

namespace ShopManagement.Infrastructure.EFcore.Repository
{
    public class SlideRepository : RepositoryBase<long, Slide>, ISlideRepository
    {
        public readonly ShopContext _ShopContext;

        public SlideRepository(ShopContext shopContext) : base(shopContext)
        {
            _ShopContext = shopContext;
        }

        public EditSlide GetDetails(long id)
        {
            return _ShopContext.Slides.Select(x => new EditSlide
            {
                Id = id,
                BtnText = x.BtnText,
                Heading = x.Heading,
                IsRemove = x.IsRemove,
                Link = x.Link,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Text = x.Text,
                Title = x.Title
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<SlideViewModel> GetList()
        {
          return _ShopContext.Slides.Select(x=>new SlideViewModel
          {
              Id = x.Id,
              Title = x.Title,
              CreationDate=x.CreationDate.ToString(),
              Heading=x.Heading,
              IsRemoved=x.IsRemove,
              Picture =x.Picture
          }).OrderByDescending(x=>x.Id).ToList();
        }
    }
}