using System;
using Application.DTOs;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobSheetController : ControllerBase
	{
        protected readonly ISheetRepository _sheetRepository;
        protected readonly ICircleRepository _circleRepository;
        protected readonly ILinesRepository _linesRepository;
        protected readonly IMapper _mapper;

        public JobSheetController(ISheetRepository sheetRepository, ICircleRepository circleRepository, ILinesRepository linesRepository, IMapper mapper)
        {
            _sheetRepository = sheetRepository;
            _circleRepository = circleRepository;
            _linesRepository = linesRepository;
            _mapper = mapper;
        }

        [HttpGet("{projectId}/{jobId}/{sheetId}")]
        public async Task<ActionResult<GetSheetComponents>> GetAll(Guid projectId, Guid jobId, Guid sheetId)
        {
            var sheet = _mapper.Map<GetSheetComponents>(await _sheetRepository.GetSheetWithComponents(projectId, jobId, sheetId));
            if (sheet != null)
                return Ok(sheet);
            else
                return NotFound($"sheet with id {sheetId} not found");
        }

        [HttpPost("CreateCircle")]
        public async Task<ActionResult<CreateCircle>> Create([FromBody] CreateCircle circle)
        {
            Circle newCircle = _mapper.Map<Circle>(circle);
            try
            {
                await _circleRepository.Create(newCircle);
                return Created("", _mapper.Map<GetCircle>(newCircle));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("CreateLines")]
        public async Task<ActionResult<CreateLines>> Create([FromBody] CreateLines line)
        {
            Lines newLine = _mapper.Map<Lines>(line);
            try
            {
                await _linesRepository.Create(newLine);
                return Created("", _mapper.Map<GetLines>(newLine));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

