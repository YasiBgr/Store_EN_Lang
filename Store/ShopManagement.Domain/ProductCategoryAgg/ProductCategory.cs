using _0_FrameWork.Domain;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public class ProductCategory : EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Keywords { get; private set; }
        public string Slug { get; private set; }
        public string MetaDescription { get; private set; }

        public bool Delete { get; private set; }
    
        public List<Product> products { get; private set; }

        public ProductCategory(string name, string description, string picture, string pictureAlt, string pictureTitle, string keywords, string slug, string metaDescription)
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Keywords = keywords;
            Slug = slug;
            MetaDescription = metaDescription;
            Delete = false;
        }

        public void Edit(string name, string description, string picture, string pictureAlt, string pictureTitle, string keywords, string slug, string metaDescription)
        {
            Name = name;
            Description = description;
                 if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Keywords = keywords;
            Slug = slug;
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
