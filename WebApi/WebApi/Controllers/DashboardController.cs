using System;
using Application.Contracts;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;
		public DashboardController(IDashboardService dashboardService)
		{
            _dashboardService = dashboardService;
		}

        [HttpGet("getTotal")]
        public async Task<ActionResult<List<Stat>>> Get()
        {
            var result = await _dashboardService.getCountEntities();
            return Ok(result);
        }

        [HttpGet("getProjectPerClient")]
        public async Task<ActionResult<List<ProjectPerClient>>> GetProjectPerClient()
        {
            var result = await _dashboardService.GetProjectPerClients();
            return Ok(result);
        }
	}
}

