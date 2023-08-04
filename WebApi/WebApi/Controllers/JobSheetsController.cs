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
    public class JobSheetsController : ControllerBase
	{
        protected readonly ISheetRepository _sheetRepository;
        protected readonly IMapper _mapper;

        public JobSheetsController(ISheetRepository sheetRepository, IMapper mapper)
		{
            _sheetRepository = sheetRepository;
            _mapper = mapper;
		}

        [HttpGet("{projectId}/{jobId}")]
        public async Task<ActionResult<IEnumerable<GetSheet>>> Get(Guid projectId, Guid jobId)
        {
            var sheets = _mapper.Map<List<Sheet>, List<GetSheet>>(await _sheetRepository.GetJobSheets(projectId, jobId));
            return Ok(sheets);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<GetSheet>> Create([FromBody] CreateSheet sheet)
        {
            Sheet newSheet = _mapper.Map<Sheet>(sheet);
            try
            {
                await _sheetRepository.Create(newSheet);
                return Created("", _mapper.Map<GetSheet>(newSheet));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

