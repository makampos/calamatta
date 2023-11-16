using System;
using Calamatta.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Calamatta.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgentChatCoordinatorController : ControllerBase
    {
        private readonly ILogger<AgentChatCoordinatorController> _logger;
        private readonly IAgentChatCoordinatorService _agentChatCoordinatorService;
        
        public AgentChatCoordinatorController(ILogger<AgentChatCoordinatorController> logger,
            IAgentChatCoordinatorService agentChatCoordinatorService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _agentChatCoordinatorService = agentChatCoordinatorService ??
                                           throw new ArgumentNullException(nameof(agentChatCoordinatorService));
        }

        [HttpPost]
        public ActionResult AssignChat([FromBody] int chatRequest)
        {
            _logger.LogInformation($"Request {chatRequest} chats");
            
            _agentChatCoordinatorService.AssignChat(chatRequest);
            
           return Ok();
        }
    }
}