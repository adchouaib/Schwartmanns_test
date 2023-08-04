using System;
using Application.DTOs;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProjectJobsController : ControllerBase
	{
        protected readonly IJobRepository _jobRepository;
        protected readonly IMapper _mapper;

        public ProjectJobsController(IJobRepository jobRepository, IMapper mapper)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<GetJob>>> Get(Guid id)
        {
            var jobs = _mapper.Map<List<Job>, List<GetJob>>(await _jobRepository.GetProjectJobs(id));
            return Ok(jobs);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<GetJob>> Create([FromBody] CreateJob job)
        {
            Job newJob = _mapper.Map<Job>(job);
            try
            {
                await _jobRepository.Create(newJob);
                return Created("", _mapper.Map<GetJob>(newJob));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

