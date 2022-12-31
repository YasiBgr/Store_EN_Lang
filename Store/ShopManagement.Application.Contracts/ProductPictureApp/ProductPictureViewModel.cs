namespace ShopManagement.Application.Contracts.ProductPictureApp
{
    public class ProductPictureViewModel
    {
        public long Id { get; set; }
        public string CreationDate { get; set; }
        public long ProductId { get; set; }
        public string Product { get; set; }
        public string Picture { get; set; }
        public bool Isremoved { get; set; }

    }
}
