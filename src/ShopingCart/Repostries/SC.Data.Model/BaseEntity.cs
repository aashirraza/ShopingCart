using System.ComponentModel.DataAnnotations;

namespace SC.Data.Model
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; }
    }
}
