using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Vega.Data;
using Vega.Models;

namespace Vega.Helpers
{
    public class SeedData
    {
        public static void SeedDefaultData(VegaDbContext _ctx)
        {
            if (!_ctx.Manufacturers.Any())
            {
                List<Manufacturer> manufacturers = new List<Manufacturer>
                {
                    new Manufacturer
                    {
                        Name = "BMW"
                    },
                    new Manufacturer
                    {
                        Name = "Mercedes"
                    },
                    new Manufacturer
                    {
                        Name = "Audi"
                    },
                    new Manufacturer
                    {
                        Name = "Mitsubishi"
                    },
                    new Manufacturer
                    {
                        Name = "Lamborghini"
                    }
                };
                _ctx.Manufacturers.AddRange(manufacturers);
                _ctx.SaveChanges();

                

                //manufacturers.ForEach(delegate (Manufacturer manufacturer)
                //{
                //    if (manufacturer == bmw)
                //    {
                //        manufacturer.Models = new List<Model>
                //        {
                //            new Model
                //            {
                //                Name = "I8",
                //                ManufacturerId = manufacturer.Id
                //            },
                //            new Model
                //            {
                //                Name = "X3",
                //                ManufacturerId = manufacturer.Id
                //            },
                //            new Model
                //            {
                //                Name = "M3",
                //                ManufacturerId = manufacturer.Id
                //            }
                //        };
                //    }
                //    if (manufacturer == mercedes)
                //    {
                //        manufacturer.Models = new List<Model>
                //        {
                //            new Model
                //            {
                //                Name = "S Class",
                //                ManufacturerId = manufacturer.Id
                //            },
                //            new Model
                //            {
                //                Name = "C Class",
                //                ManufacturerId = manufacturer.Id
                //            }
                //        };
                //    }
                //    if (manufacturer == audi)
                //    {
                //        manufacturer.Models = new List<Model>
                //        {
                //            new Model
                //            {
                //                Name = "A3",
                //                ManufacturerId = manufacturer.Id
                //            },
                //            new Model
                //            {
                //                Name = "A4",
                //                ManufacturerId = manufacturer.Id
                //            }
                //        };
                //    }
                //});

                //var bmwId = _ctx.Manufacturers.Where(m => m.Name == "BMW").Select(m => m.Id).FirstOrDefault();
                //var mercedesId = _ctx.Manufacturers.Where(m => m.Name == "Mercedes").Select(m => m.Id).FirstOrDefault();
                //var audiId = _ctx.Manufacturers.Where(m => m.Name == "Audi").Select(m => m.Id).FirstOrDefault();

                var bmw = _ctx.Manufacturers.Where(m => m.Name == "BMW").FirstOrDefault();
                var mercedes = _ctx.Manufacturers.Where(m => m.Name == "Mercedes").FirstOrDefault();
                var audi = _ctx.Manufacturers.Where(m => m.Name == "Audi").FirstOrDefault();

                // now add models
                ICollection<Model> models = new Collection<Model>
                {
                    new Model
                    {
                        Name = "I8",
                        ManufacturerId = bmw.Id,
                        Manufacturer = bmw
                    },
                    new Model
                    {
                        Name = "X3",
                        ManufacturerId = bmw.Id,
                        Manufacturer = bmw
                    },
                    new Model
                    {
                        Name = "M3",
                        ManufacturerId = bmw.Id,
                        Manufacturer = bmw
                    },
                    new Model
                    {
                        Name = "A3",
                        ManufacturerId = audi.Id,
                        Manufacturer = audi
                    },
                    new Model
                    {
                        Name = "A4",
                        ManufacturerId = audi.Id,
                        Manufacturer = audi
                    },
                    new Model
                    {
                        Name = "S Class",
                        ManufacturerId = mercedes.Id,
                        Manufacturer = mercedes
                    },
                    new Model
                    {
                        Name = "C Class",
                        ManufacturerId = mercedes.Id,
                        Manufacturer = mercedes
                    }
                };

                _ctx.Models.AddRange(models);
                _ctx.SaveChanges();
            }
        }
    }
}
