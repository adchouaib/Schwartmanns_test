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
    public class ClientController : ControllerBase
    {
        protected readonly IClientRepository _clientRepository;
        protected readonly IMapper _mapper;

        public ClientController(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<GetClient>>> GetAll()
        {
            var clients = _mapper.Map<List<Client>, List<GetClient>>(await _clientRepository.GetAll());
            return Ok(clients);
        }

        [HttpGet("{id}", Name = "ClientById")]
        public async Task<ActionResult<GetClient>> Get(Guid id)
        {
            var client = _mapper.Map<GetClient>(await _clientRepository.Get(id));
            if (client != null)
                return Ok(client);
            else
                return NotFound($"client with id {id} not found");
        }

        [HttpPost("Create")]
        public async Task<ActionResult<GetClient>> Create([FromBody] CreateClient client)
        {
            try
            {
                if (client == null)
                    return BadRequest("client object is null");
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                Client newClient = _mapper.Map<Client>(client);
                await _clientRepository.Create(newClient);
                return CreatedAtRoute("ClientById", new { id = newClient.Id }, newClient );
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
