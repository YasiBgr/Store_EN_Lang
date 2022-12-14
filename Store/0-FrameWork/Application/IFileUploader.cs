using Microsoft.AspNetCore.Http;

namespace _0_FrameWork.Application
{
    public interface IFileUploader
    {
        string UpLoad(IFormFile file, string path);
    }
}
