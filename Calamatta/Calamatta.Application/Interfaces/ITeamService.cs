using System;
using System.Collections.Generic;
using Calamatta.Domain.Models;

namespace Calamatta.Application.Interfaces
{
    public interface ITeamService
    {
        Team Create(IEnumerable<Guid> agents, string name);
        IEnumerable<Team> Get();
    }
}