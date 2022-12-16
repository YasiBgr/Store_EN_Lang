using Microsoft.AspNetCore.Http;
using ShopManagement.Application.Contracts.ProductCategoryApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.ProductApp
{
    public class CreateProduct
    {
        public string Name { get;set; }
        public string Description { get;set; }
        public string Code { get;set; }
        public double UnitPrice { get;set; }
        public bool Delete { get;set; }
        public string ShortDescription { get;set; }
        public IFormFile Picture { get;set; }
        public string PictureAlt { get;set; }
        public string PictureTitle { get;set; }
        public long CategoryId { get;set; }
        public string Slug { get;set; }
        public string Keywords { get;set; }
        public List<ProductCategoryViewModel> Category { get; set; }

        public string MetaDescription { get;set; }
    }
}
