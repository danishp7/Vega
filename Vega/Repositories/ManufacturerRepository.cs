using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vega.Data;
using Vega.Dtos;
using Vega.Models;

namespace Vega.Repositories
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly VegaDbContext _context;
        private readonly IMapper _mapper;

        // dependency injection
        public ManufacturerRepository(VegaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ManufacturerDto>> GetAllManufacturers()
        {
            var manufacturers = await _context.Manufacturers.Include(m => m.Models).ToListAsync();
            if (!manufacturers.Any())
                return null;

            var makers = _mapper.Map<List<ManufacturerDto>>(manufacturers);
            return makers;
        }
    }
}
