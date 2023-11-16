using System.Collections.Generic;
using Calamatta.Domain.Models;

namespace Calamatta.Application.Repositories
{
    public interface ITeamRepository
    {
        Team Create(IEnumerable<Agent> agents, string name, int capacity);
        IEnumerable<Team> GetAll();
    }
}