using _0_FrameWork.Application;

namespace ShopManagement.Application.Contracts.SlideApp
{
    public interface ISlideApplication
    {
        OperationResult Create(CreateSlide command);
        OperationResult Edit(EditSlide command);
        OperationResult Removed(long Id);
        OperationResult Restore(long Id);
        List<SlideViewModel> GetList();
        EditSlide GetDetails(long id);
    }
}
