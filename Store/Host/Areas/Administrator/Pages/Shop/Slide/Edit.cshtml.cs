using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.SlideApp;

namespace Host.Areas.Administrator.Pages.Shop.Slide
{
    public class EditModel : PageModel
    {
        private readonly ISlideApplication _slide;
        public EditSlide EditSlide;
        public EditModel(ISlideApplication slide)
        {
            _slide = slide;
        }

        public void OnGet(long id)
        {
            EditSlide = _slide.GetDetails(id);

        }

        public IActionResult OnPost(EditSlide editSlide)
        {
            var editedSlide = _slide.Edit(editSlide);
            return RedirectToPage("./Index");
        }
    }
}
