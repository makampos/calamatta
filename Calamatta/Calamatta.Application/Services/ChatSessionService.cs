using System;
using System.Collections.Generic;
using Calamatta.Application.Interfaces;
using Calamatta.Domain.Models;
using Microsoft.Extensions.Logging;

namespace Calamatta.Application.Services
{
    public class ChatSessionService : IChatSessionService
    {
        private static List<ChatSession> _chatSessions;
        private readonly ILogger<ChatSessionService> _logger;
        
        public ChatSessionService(ILogger<ChatSessionService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _chatSessions = new List<ChatSession>();
        }
        
        public void Create(ChatSession chatSession)
        {
            _chatSessions.Add(chatSession);
        }

        public IEnumerable<ChatSession> Get()
        {
            return _chatSessions;
        }

        public void FinishChat(Guid agentId)
        {
            var chats = _chatSessions.RemoveAll(x => x.Agent.Id == agentId);
            
            _logger.LogInformation($"A total of {chats} was removed from the target agent");
        }
    }
}