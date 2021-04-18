using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vega.Dtos
{
    public class ManufacturerDto
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        // relation with models i.e 1 manufacturer can have many models
        public ICollection<ModelDto> Models { get; set; }
    }
}
