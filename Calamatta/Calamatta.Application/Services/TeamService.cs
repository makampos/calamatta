using System;
using System.Collections.Generic;
using System.Linq;
using Calamatta.Application.Interfaces;
using Calamatta.Application.Repositories;
using Calamatta.Domain.Constants;
using Calamatta.Domain.Models;

namespace Calamatta.Application.Services
{
    public class TeamService : ITeamService
    {
        private readonly IAgentService _agentService;
        private readonly ITeamRepository _teamRepository;

        public TeamService(IAgentService agentService, ITeamRepository teamRepository)
        {
            _agentService = agentService ?? throw new ArgumentNullException(nameof(agentService));
            _teamRepository = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));
        }

        public Team Create(IEnumerable<Guid> agentsIds, string name)
        {
            var agents = agentsIds.Select(id => _agentService.Get(id)).Where(agent => agent != null).ToList();

            var totalTeamCapacity = CalculateCapacity(agents);
            
            return _teamRepository.Create(agents, name, totalTeamCapacity);
        }

        public IEnumerable<Team> Get()
        {
            return _teamRepository.GetAll();
        }

        private int CalculateCapacity(IEnumerable<Agent> agents)
        {
            var capacity = agents.GroupBy(x => x.Seniority)
                .OrderByDescending(y => y.Key)
                .Select(group => group.Count() * MaximumConcurrency.Max * group.Select(x => x.SeniorityMultiplier).First())
                .Select(totalOfEachCapacityBySeniority => (int)totalOfEachCapacityBySeniority)
                .Sum();

            var totalTeamCapacity = capacity * MaximumQueueLenght.Max;

            return (int)totalTeamCapacity;
        }
    }
}