namespace ShopManagement.Application.Contracts.ProductApp
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Picture { get; set; }
        public string CreationDate { get; set; }
        public string code { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public string Category { get; set; }
        public bool Delete { get; set; }
        public long CategoryId { get; set; }
    }
}
