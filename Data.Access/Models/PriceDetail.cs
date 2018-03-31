using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Access.Models
{
    [ComplexType]
    public class PriceDetail
    {
        [Required]
        public float Price { get; set; }

        [Required]
        public ProductPriceType ProductPriceType { get; set; }
    }
}
