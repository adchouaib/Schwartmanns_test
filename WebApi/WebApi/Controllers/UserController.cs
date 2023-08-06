using System;
using Application.Contracts;
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
        protected readonly IUserService _userService;
        protected readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<GetUser>>> GetAll()
        {
            var users = _mapper.Map<List<User>, List<GetUser>>(await _userService.GetAll());
            return Ok(users);
        }

        //[HttpGet("{id}", Name = "UserById")]
        //public async Task<ActionResult<GetUser>> GetById(Guid id)
        //{
        //    var user = _mapper.Map<GetUser>(await _userService.GetById(id));
        //    if (user != null)
        //        return Ok(user);
        //    else
        //        return NotFound($"user with id {id} not found");
        //}

        [HttpGet("{email}", Name = "UserById")]
        public async Task<ActionResult<GetUser>> GetById(string email)
        {
            var user = _mapper.Map<GetUser>(await _userService.GetByEmail(email));
            if (user != null)
                return Ok(user);
            else
                return NotFound($"user with id {email} not found");
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

                await _userService.CreateUser(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<JwtToken>> Login([FromBody]Login login)
        {
            try
            {
                var token = await _userService.Login(login);
                return Ok(token);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
