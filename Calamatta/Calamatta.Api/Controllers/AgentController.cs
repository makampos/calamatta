using System;
using System.Collections;
using Calamatta.Application.Dtos;
using Calamatta.Application.Interfaces;
using Calamatta.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Calamatta.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgentController : ControllerBase
    {
        private readonly ILogger<AgentController> _logger;
        private readonly IAgentService _agentService;
        
        public AgentController(ILogger<AgentController> logger, IAgentService agentService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _agentService = agentService ?? throw new ArgumentNullException(nameof(agentService));
        }

        [HttpGet]
        public ActionResult<IEnumerable> Get()
        {
            _logger.LogInformation("Get all agents");
            
            var agents = _agentService.GetAll();
            
            return Ok(agents);
        }
        
        [HttpPost]
        public ActionResult<Agent> Create([FromBody] AgentDto agentDto)
        {
            _logger.LogInformation($"Create agent: {agentDto}");
            
            var agent = _agentService.Create(agentDto);

            return Ok(agent);
        }

        [HttpPut,Route("update-shift")]
        public ActionResult UpdateShift(Guid agentId, bool isWorking)
        {
            _logger.LogInformation($"Update an agent shift with the following data: {agentId} and {isWorking}");
            
            _agentService.UpdateShift(agentId, isWorking);
            
            return NoContent();
        }
    }
}