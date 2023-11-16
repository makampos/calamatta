using System;
using System.Collections.Generic;
using System.Linq;
using Calamatta.Application.Repositories;
using Calamatta.Domain.Models;

namespace Calamatta.Infrastructure.Repositories
{
    public class AgentRepository : IAgentRepository
    {
        private static List<Agent> _agents;
        
        public AgentRepository()
        {
            _agents = new List<Agent>();
        }

        public Agent Get(Guid id)
        {
            var agent = _agents.Find(x => x.Id == id);
            return agent;
        }

        public IEnumerable<Agent> GetAll()
        {
            return _agents.ToList();
        }

        public Agent Create(Agent agent)
        {
            return agent;
        }

        public void AddToList(Agent agent)
        {
            _agents.Add(agent);
        }
    }
}