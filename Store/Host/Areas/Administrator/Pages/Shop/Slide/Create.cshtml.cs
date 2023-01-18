using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.SlideApp;

namespace Host.Areas.Administrator.Pages.Shop.Slide
{
    public class CreateModel : PageModel
    {

        public CreateSlide CreateSlide;
        private readonly ISlideApplication slideApplication;

        public CreateModel(ISlideApplication slideApplication)
        {
            this.slideApplication = slideApplication;
        }
        [HttpGet]
        public void OnGet()
        {
        }
        [HttpPost]
        public IActionResult OnPost(CreateSlide createSlide)
        {
            var create = slideApplication.Create(createSlide);
            return RedirectToPage("./Index");
        }
    }
}
