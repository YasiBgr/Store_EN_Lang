using _0_FrameWork.Domain;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductAgg
{
    public class Product:EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Code { get; private set; }
        public double UnitPrice { get; private set; }
        public bool Delete { get; private set; }
        public string ShortDescription { get; private set; }    
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public long CategoryId { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public ProductCategory Category { get; private set; }
        public List<ProductPicture> ProductPictures { get; private set; }


        public Product(string name, string description, string code, double unitPrice, string shortDescription,
            string picture, string pictureAlt, string pictureTitle, long categoryId, string slug,
            string keywords, string metaDescription)
        {
            Name = name;
            Description = description;
            Code = code;
            UnitPrice = unitPrice;
            ShortDescription = shortDescription;
            if (!string.IsNullOrWhiteSpace(picture))
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Delete = true;
        }

        public void Edit(string name, string description, string code, double unitPrice, string shortDescription,
            string picture, string pictureAlt, string pictureTitle, long categoryId, string slug,
            string keywords, string metaDescription)
        {
            Name = name;
            Description = description;
            Code = code;
            UnitPrice = unitPrice;
            ShortDescription = shortDescription;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
        }

        public void DeleteCategory()
        {
            this.Delete = true;
        }
        public void RestoreCategory()
        {
            this.Delete = false;
        }
    }
}
