using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vega.Models;

namespace Vega.Repositories
{
    public interface IManufacturerRepository
    {
        Task<List<Manufacturer>> GetAllManufacturers();
    }
}
