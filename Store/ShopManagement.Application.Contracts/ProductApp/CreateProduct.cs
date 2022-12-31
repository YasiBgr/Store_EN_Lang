using _0_FrameWork.Application;
using Microsoft.AspNetCore.Http;
using ShopManagement.Application.Contracts.ProductCategoryApp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.ProductApp
{
    public class CreateProduct
    {
        [Required(ErrorMessage =ValidationMessage.IsRequired)]
        public string Name { get;set; }


        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Description { get;set; }


        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Code { get;set; }

        public double UnitPrice { get;set; }
        public bool Delete { get;set; }


        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string ShortDescription { get;set; }
        public IFormFile Picture { get;set; }
        public string PictureAlt { get;set; }
        public string PictureTitle { get;set; }


        [Range(1,100000,ErrorMessage = ValidationMessage.IsRequired)]
        public long CategoryId { get;set; }


        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Slug { get;set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Keywords { get;set; }
        public List<ProductCategoryViewModel> Category { get; set; }


        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string MetaDescription { get;set; }
    }
}
