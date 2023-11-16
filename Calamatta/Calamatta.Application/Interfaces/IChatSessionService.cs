using System;
using System.Collections.Generic;
using Calamatta.Domain.Models;

namespace Calamatta.Application.Interfaces
{
    public interface IChatSessionService
    {
        void Create(ChatSession chatSession);
        IEnumerable<ChatSession> Get();
        void FinishChat(Guid agentId);
    }
}