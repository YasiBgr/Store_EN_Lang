using Microsoft.AspNetCore.Mvc;
using StoreQueryModel.Contract.Slide;

namespace Host.ViewComponents
{
    public class SlideViewComponent:ViewComponent
    {
        private readonly ISlideQuery slideQuery;

        public SlideViewComponent(ISlideQuery slideQuery)
        {
            this.slideQuery = slideQuery;
        }

        public IViewComponentResult Invoke()
        {
            var slides = slideQuery.GetListSlide();
            return View(slides);
        }
    }
}
