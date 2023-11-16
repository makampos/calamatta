using System;
using System.Collections.Generic;
using Calamatta.Application.Dtos;
using Calamatta.Application.Interfaces;
using Calamatta.Application.Repositories;
using Calamatta.Domain.Models;

namespace Calamatta.Application.Services
{
    public class AgentService : IAgentService
    {
        private readonly IAgentRepository _agentRepository;

        public AgentService(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository ?? throw new ArgumentNullException(nameof(agentRepository));
        }

        public Agent Get(Guid id)
        {
            return _agentRepository.Get(id);
        }

        public Agent Create(AgentDto agentDto)
        {
            var agent = Mappers.AgentMappers.AgentMap.ToDomain(agentDto);
            
            _agentRepository.AddToList(agent);
            
            return _agentRepository.Create(agent);
        }

        public IEnumerable<Agent> GetAll()
        {
            return _agentRepository.GetAll();
        }

        public void UpdateShift(Guid agentId, bool isWorking)
        {
            var agent = _agentRepository.Get(agentId);
            
            agent.EndShift(isWorking);
        }
    }
}