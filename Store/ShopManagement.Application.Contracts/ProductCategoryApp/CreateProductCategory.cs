using _0_FrameWork.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contracts.ProductCategoryApp;

    public class CreateProductCategory
    {

    [Required(ErrorMessage =ValidationMessage.IsRequired)]
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
    [Required(ErrorMessage=ValidationMessage.IsRequired)]
        public string Keywords { get; set; }
    [Required(ErrorMessage =ValidationMessage.IsRequired)]
    public string Slug { get; set; }
    [Required(ErrorMessage =ValidationMessage.IsRequired)]
    public string MetaDescription { get; set; } 
}

