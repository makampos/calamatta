using System;
using Calamatta.Application.Dtos;
using Calamatta.Domain.Constants;
using Calamatta.Domain.Enums;
using Calamatta.Domain.Models;

namespace Calamatta.Application.Mappers.AgentMappers
{
    public static class AgentMap
    {
        public static Agent ToDomain(AgentDto agentDto)
        {
            var seniorityMultiplierToBeAssign = agentDto.Seniority switch
            {
                Seniority.Junior => SeniorityMultiplier.Junior,
                Seniority.MidLevel => SeniorityMultiplier.MidLevel,
                Seniority.Senior => SeniorityMultiplier.Senior,
                Seniority.TeamLead => SeniorityMultiplier.TeamLead,
                _ => throw new ArgumentOutOfRangeException()
            };
            
            return Agent.Create(agentDto.Name, agentDto.Seniority, seniorityMultiplierToBeAssign);
        }
    }
}