using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vega.Dtos;
using Vega.Models;

namespace Vega.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Manufacturer, ManufacturerDto>().ReverseMap();
            CreateMap<Model, ModelDto>().ReverseMap();
        }
    }
}
