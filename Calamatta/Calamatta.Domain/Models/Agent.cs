using System;
using Calamatta.Domain.Enums;

namespace Calamatta.Domain.Models
{
    public class Agent
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Seniority Seniority { get; private set; }
        public float SeniorityMultiplier { get; private set; }

        public bool IsWorking { get; private set; }
        private Agent(string name, Seniority seniority, float seniorityMultiplier)
        {
            Id = Guid.NewGuid();
            Name = name;
            Seniority = seniority;
            SeniorityMultiplier = seniorityMultiplier;
            IsWorking = true;
        }
        public static Agent Create(string name, Seniority seniority, float seniorityMultiplier) 
            => new Agent(name, seniority, seniorityMultiplier);

        public void EndShift(bool isWorking)
        {
            IsWorking = isWorking;
        }
    }
}