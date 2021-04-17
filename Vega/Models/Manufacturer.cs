using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Vega.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // relation with models i.e 1 manufacturer can have many models
        public ICollection<Model> Models { get; set; }
        public Manufacturer()
        {
            Models = new Collection<Model>(); // its manufacturer class responsibility to initialize model's collectiom
        }
    }
}
