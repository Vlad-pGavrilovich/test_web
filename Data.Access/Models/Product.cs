using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Access.Models
{
    public class Product : BaseModel
    {
        [Required]
        public string Name { get; set; }

        public PriceDetail PriceDetail { get; set; }

        public string Description { get; set; }

        [Required]
        [Column("Category_ID")]
        public long CategoryId { get; set; }

        [Required]
        [Column("Country_ID")]
        public long CountryId { get; set; }

        [Column("Discount_Group_ID")]
        public int? DiscountGroupId { get; set; }

        public virtual Category Category { get; set; }

        public virtual Country Country { get; set; }

        public virtual DiscountGroup Discount { get; set; }
    }
}
