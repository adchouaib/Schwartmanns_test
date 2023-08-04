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
    public class UserController : ControllerBase
    {
        protected readonly IUserRepository _userRepository;
        protected readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<GetUser>>> GetAll()
        {
            var users = _mapper.Map<List<User>, List<GetUser>>(await _userRepository.GetAll());
            return Ok(users);
        }

        [HttpGet("{id}", Name = "UserById")]
        public async Task<ActionResult<GetUser>> Get(Guid id)
        {
            var user = _mapper.Map<GetUser>(await _userRepository.Get(id));
            if (user != null)
                return Ok(user);
            else
                return NotFound($"user with id {id} not found");
        }

        [HttpPost("Create")]
        public async Task<ActionResult<GetUser>> Create([FromBody] CreateUser user)
        {
            try
            {
                if (user == null)
                    return BadRequest("user object is null");
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                User newUser = _mapper.Map<User>(user);
                await _userRepository.Create(newUser);
                return CreatedAtRoute("UserById", new { id = newUser.Id }, newUser);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
