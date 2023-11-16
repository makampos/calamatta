using System;
using System.Collections.Generic;
using Calamatta.Application.Dtos;
using Calamatta.Domain.Models;

namespace Calamatta.Application.Interfaces
{
    public interface IAgentService
    {
        Agent Get(Guid id);
        Agent Create(AgentDto agent);
        IEnumerable<Agent> GetAll();

        void UpdateShift(Guid agentId, bool isWorking);
    }
}