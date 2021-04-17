using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vega.Dtos
{
    public class ManufacturerDto
    {
        public string Name { get; set; }

        // relation with models i.e 1 manufacturer can have many models
        public ICollection<ModelDto> Models { get; set; }
    }
}
