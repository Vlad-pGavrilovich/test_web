using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Access.Models
{
    public class DiscountGroup : BaseModel
    {
        [Required]
        public float Discount { get; set; }

        [Column("Finish_Date")]
        public DateTime? FinishDate { get; set; }

        public virtual ICollection<Product> ProductsOnDiscount { get; set; }
    }
}
