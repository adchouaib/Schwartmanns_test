using Application.DTOs;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        protected readonly IProjectRepository _projectRepository;
        protected readonly IMapper _mapper;
        public ProjectController(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<GetProject>>> GetAll()
        {
            var projects = _mapper.Map<List<Project>, List<GetProject>>(await _projectRepository.GetProjectWithClientAndUser());
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetProject>> GetAll(Guid id)
        {
            var project = _mapper.Map<GetProject>(await _projectRepository.Get(id));
            if (project != null)
                return Ok(project);
            else
                return NotFound($"project with id {id} not found");
        }

        [HttpPost("Create")]
        public async Task<ActionResult<GetProject>> Create([FromBody] CreateProject project)
        {
            Project newProject = _mapper.Map<Project>(project);
            try
            {
                await _projectRepository.Create(newProject);
                return Created("", _mapper.Map<GetProject>(newProject));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var project = await _projectRepository.Get(id);
                if (project != null)
                {
                    await _projectRepository.Delete(project);
                    return Ok($"project with id {id} not found is deleted");
                }
                else
                {
                    return NotFound($"project with id {id} not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}


