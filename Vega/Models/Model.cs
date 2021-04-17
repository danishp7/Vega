using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vega.Models
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // relation with models i.e 1 manufacturer can have many models
        public Manufacturer Manufacturer { get; set; }
        public int ManufacturerId { get; set; }
    }
}
