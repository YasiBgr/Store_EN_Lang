namespace ShopManagement.Application.Contracts.SlideApp
{
    public class SlideViewModel
    {
        public string Picture { get; set; }
        public long Id { get; set; }
        public string Title { get; set; }
        public string Heading { get; set; }
        public string CreationDate { get; set; }
        public bool IsRemoved { get; set; }

    }
}
