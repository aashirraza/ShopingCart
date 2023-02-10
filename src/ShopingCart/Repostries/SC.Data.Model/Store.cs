namespace SC.Data.Model
{
    public class Store : BaseEntity
    {
        public Store()
        {
            Products = new List<product>();
        }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Catagory { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public ICollection<product> Products { get; set; }


    }
}
