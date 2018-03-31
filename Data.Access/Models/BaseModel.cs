using System.ComponentModel.DataAnnotations;

namespace Data.Access.Models
{
    public class BaseModel
    {
        [Key]
        public long Id { get; set; }
    }
}
