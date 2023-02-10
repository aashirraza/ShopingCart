using System.ComponentModel.DataAnnotations.Schema;

namespace SC.Data.Model
{
    public class product : BaseEntity
    {
        public product()
        {
            Stores = new Store();
        }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Catagory { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int StoreId { get; set; }
        [ForeignKey("StoreId")]
        public Store Stores { get; set; }


    }
}