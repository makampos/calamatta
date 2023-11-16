using System;
using System.Collections.Generic;

namespace Calamatta.Domain.Models
{
    public class Team
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public IEnumerable<Agent> Agents { get; private set; }
        public int Capacity { get; private set; }

        private Team(string name, IEnumerable<Agent> agents, int capacity)
        {
            Id = Guid.NewGuid();
            Name = name;
            Agents = agents;
            Capacity = capacity;
        }

        public static Team Create(string name, IEnumerable<Agent> agents, int capacity)
        {
            return new Team(name, agents, capacity);
        }
    }
}