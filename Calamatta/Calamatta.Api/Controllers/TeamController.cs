using System;
using System.Collections.Generic;
using System.Linq;
using Calamatta.Application.Interfaces;
using Calamatta.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Calamatta.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ILogger<TeamController> _logger;
        private readonly ITeamService _teamService;
        
        public TeamController(ILogger<TeamController> logger, ITeamService teamService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _teamService = teamService ?? throw new ArgumentNullException(nameof(teamService));
        }

        [HttpPost]
        public ActionResult<Team> 
            Create([FromBody] IEnumerable<Guid> agentIds, string name)
        {
            
            _logger.LogInformation($"Create the team with the following data :{name}" +
                                   $" and {string.Join("-", agentIds.Select(x => x.ToString()))}");
            
            var team = _teamService.Create(agentIds, name);
            
            return Ok(team);
        }
    }
}