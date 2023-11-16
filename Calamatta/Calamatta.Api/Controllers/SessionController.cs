using System;
using Calamatta.Application.Interfaces;
using Calamatta.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Calamatta.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly ILogger<SessionController> _logger;
        private readonly ISessionService _sessionService;
        private readonly IQueueService<Session> _queueService;
        
        public SessionController(ILogger<SessionController> logger, ISessionService sessionService,
            IQueueService<Session> queueService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _sessionService = sessionService ?? throw new ArgumentNullException(nameof(sessionService));
            _queueService = queueService ?? throw new ArgumentNullException(nameof(queueService));;
        }
        
        [HttpPost]
        public ActionResult<Session> Create()
        {
            _logger.LogInformation("Create Session");
            
            var queue = _queueService.Get();
            
            var session = _sessionService.Create();
            
            queue.Enqueue(session);
            
            _logger.LogInformation($"Queue Session {session.Id}");
                
            return Ok(session);
        }
    }
}