using System.Collections.Generic;
using Calamatta.Application.Repositories;
using Calamatta.Domain.Models;

namespace Calamatta.Infrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private static List<Team> _teams;
        
        public TeamRepository()
        {
            _teams = new List<Team>();
        }
        
        public Team Create(IEnumerable<Agent> agents, string name, int capacity)
        {
            var team = Team.Create(name, agents, capacity);
            
            _teams.Add(team);
            
            return team;
        }

        public IEnumerable<Team> GetAll()
        {
            return _teams;
        }
    }
}