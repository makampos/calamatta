using System;
using System.Collections.Generic;
using Calamatta.Application.Interfaces;
using Calamatta.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Calamatta.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatSessionController : Controller
    {
        private readonly IChatSessionService _chatSessionService;
        private readonly ILogger<ChatSessionController> _logger;
        
        public ChatSessionController(IChatSessionService chatSessionService, ILogger<ChatSessionController> logger)
        {
            _chatSessionService = chatSessionService ?? throw new ArgumentNullException(nameof(chatSessionService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public ActionResult<IEnumerable<ChatSession>> Get()
        {
            _logger.LogInformation("Get all Sessions");
            
            var chatSessions = _chatSessionService.Get();
            
            return Ok(chatSessions);
        }

        [HttpDelete]
        public ActionResult FinishChat(Guid agentId)
        {
            _logger.LogInformation($"Finish chats using the following data: {agentId}");
            
            _chatSessionService.FinishChat(agentId);
            
            return Ok();
        }
    }
}