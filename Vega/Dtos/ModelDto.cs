using System.ComponentModel.DataAnnotations;

namespace Vega.Dtos
{
    public class ModelDto
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public int ManufacturerId { get; set; }
    }
}