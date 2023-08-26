using Application.DTOs;
using Application.Repositories;
using Application.Utils;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CircleController : ControllerBase
    {
        protected readonly ICircleRepository _circleRepository;
        protected readonly IMapper _mapper;

        public CircleController(ICircleRepository circleRepository, IMapper mapper)
        {
            _circleRepository = circleRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCircleProperties>> Get(Guid id)
        {
            Circle? circle = await _circleRepository.Get(id);
            if (circle != null)
                return Ok(new GetCircleProperties
                {
                    diameter = CircleCalculations.CalculateDiameter(circle.Radius),
                    circumference = CircleCalculations.CalculateCircumference(circle.Radius),
                    surfaceArea = CircleCalculations.CalculateSurfaceArea(circle.Radius)
                });
            else
                return NotFound($"circle with id {id} not found");
        }

    }
}

