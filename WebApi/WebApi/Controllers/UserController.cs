using System;
using Application.Contracts;
using Application.DTOs;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
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

        [Authorize]
        [HttpGet("{email}", Name = "UserById")]
        public async Task<ActionResult<GetUser>> GetById(string email)
        {
            var user = _mapper.Map<GetUser>(await _userService.GetByEmail(email));
            if (user != null)
                return Ok(user);
            else
                return NotFound($"user with id {email} not found");
        }
        [Authorize]
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
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<Boolean>> Delete([FromBody] DeleteUser deleteUser)
        {
            try
            {
                var result = await _userService.DeleteUser(deleteUser);
                return result;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("updatePassword")]
        public async Task<ActionResult<bool>> UpdatePassword([FromBody] UpdatePassword updatePassword)
        {
            try
            {
                var result = await _userService.UpdatePassword(updatePassword);
                return result;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<JwtToken>> Login([FromBody] Login login)
        {
            try
            {
                var token = await _userService.Login(login);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
