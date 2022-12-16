namespace ShopManagement.Application.Contracts.ProductCategoryApp
{
    public class ProductCategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string CreationDate { get; set; }
        public long ProductsCount { get; set; }
        public bool Delete { get; set; }
    }
}
