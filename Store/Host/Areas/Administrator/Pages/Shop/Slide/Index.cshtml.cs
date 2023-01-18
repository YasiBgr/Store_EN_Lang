using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.SlideApp;

namespace Host.Areas.Administrator.Pages.Shop.Slide
{
    public class IndexModel : PageModel
    {

        private readonly ISlideApplication _SlideApplication;

        public IndexModel(ISlideApplication slideApplication)
        {
            _SlideApplication = slideApplication;
        }

        [TempData]
        public string Message { get; set; }
        public List<SlideViewModel> Slide;

      

        public void OnGet()
        {
            Slide = _SlideApplication.GetList();
        }

        public IActionResult OnRemove(long id)
        {
            var result = _SlideApplication.Removed(id);
            if (result.IsSucceeded)
                return RedirectToPage("./Index");
            Message = result.Massage;
            return RedirectToPage("./Index");

        }
        public IActionResult OnGetRestore(long Id)
        {
            var result = _SlideApplication.Restore(Id);
            if (result.IsSucceeded)
                return RedirectToPage("./Index");
            Message = result.Massage;
            return RedirectToPage("./Index");

        }
    }
}