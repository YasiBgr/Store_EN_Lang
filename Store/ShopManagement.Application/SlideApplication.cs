using _0_FrameWork.Application;
using ShopManagement.Application.Contracts.SlideApp;
using ShopManagement.Domain.SlideAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class SlideApplication : ISlideApplication

    {
        public readonly ISlideRepository _slideRepository;
        public readonly IFileUploader _fileUploader;

        public SlideApplication(ISlideRepository slideRepository, IFileUploader fileUploader)
        {
            _slideRepository = slideRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateSlide command)
        {
            var operation = new OperationResult();
            var picturePath = _fileUploader.UpLoad(command.Picture, "Slide");

            var slide =new Slide(picturePath,command.PictureAlt,command.PictureTitle,command.IsRemove,command.Text,command.Title,command.Heading,command.BtnText,command.Link);

            _slideRepository.Create(slide);
            _slideRepository.Save();
            return operation.Succeeded();
        }

        public OperationResult Edit(EditSlide command)
        {
            var operation = new OperationResult();
            
            var result = _slideRepository.Get(command.Id);
            if (result == null)
                operation.Failed(ApplicationMessage.RecordNotFound);

            var picturePath = _fileUploader.UpLoad(command.Picture, "Slide");
            result.Edit(picturePath, command.PictureAlt, command.PictureTitle, command.IsRemove, command.Text
                , command.Title, command.Heading, command.BtnText, command.Link);
            _slideRepository.Save();
            return operation.Succeeded();
        }

        public EditSlide GetDetails(long id)
        {
          return  _slideRepository.GetDetails(id);
        }

        public List<SlideViewModel> GetList()
        {
         return  _slideRepository.GetList();
        }

        public OperationResult Removed(long Id)
        {
            var operation = new OperationResult();
            var slide=_slideRepository.Get(Id);
            if (slide == null)
            {
                operation.Failed(ApplicationMessage.RecordNotFound);
            }
            slide.Removed();
            _slideRepository.Save();
            return operation.Succeeded();

        }

        public OperationResult Restore(long Id)
        {
            var operation = new OperationResult();
            var slide = _slideRepository.Get(Id);
            if (slide == null)
            {
                operation.Failed(ApplicationMessage.RecordNotFound);
            }
            slide.Restore();
            _slideRepository.Save();
            return operation.Succeeded();
        }
    }
}
