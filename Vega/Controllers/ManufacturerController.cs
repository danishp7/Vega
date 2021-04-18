using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vega.Repositories;

namespace Vega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IVegaRepository _vegaRepo;
        private readonly IManufacturerRepository _makerRepo;
        private readonly IMapper _mapper;

        public ManufacturerController(IVegaRepository vegaRepository, IManufacturerRepository manufacturerRepository, IMapper mapper)
        {
            _vegaRepo = vegaRepository;
            _makerRepo = manufacturerRepository;
            _mapper = mapper;
        }
        // get all manufacturers
        [Route("makers")]
        public async Task<IActionResult> GetManufacturers()
        {
            var manufacturers = await _makerRepo.GetAllManufacturers();
            if (manufacturers == null)
                return NotFound("No Manufacturers exist in our system...");
            return Ok(manufacturers);
        }
    }
}