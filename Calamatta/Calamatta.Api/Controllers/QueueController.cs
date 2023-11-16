using System;
using Calamatta.Application.Interfaces;
using Calamatta.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Calamatta.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QueueController : ControllerBase
    {
        private readonly IQueueService<Session> _queueService;
        private readonly ILogger<QueueController> _logger;
        
        public QueueController(IQueueService<Session> queueService, ILogger<QueueController> logger)
        {
            _queueService = queueService ?? throw new ArgumentNullException(nameof(queueService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPut,Route("dequeue")]
        public ActionResult Dequeue()
        {
            _logger.LogInformation("Dequeue...");
            
            var queue = _queueService.Get();
            
            queue.Dequeue();
            
            return NoContent();
        }

        [HttpGet, Route("count")]
        public ActionResult<int> Count()
        {
            var queue = _queueService.Get();
            
            var count = queue.Count;
            
            _logger.LogInformation($"Queue Count: {count}");
            
            return Ok(count);
        }
        
    }
}