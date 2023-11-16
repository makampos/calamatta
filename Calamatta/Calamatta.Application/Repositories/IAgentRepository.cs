using System;
using System.Collections.Generic;
using Calamatta.Domain.Models;

namespace Calamatta.Application.Repositories
{
    public interface IAgentRepository
    {
        Agent Get(Guid id);
        IEnumerable<Agent> GetAll();
        Agent Create(Agent agent);

        void AddToList(Agent agent);
    }
}