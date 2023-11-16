using Calamatta.Domain.Enums;

namespace Calamatta.Application.Dtos
{
    public class AgentDto
    {
        public string Name { get; set; }
        public Seniority Seniority { get; set; }
        
        private AgentDto(string name, Seniority seniority)
        {
            Name = name;
            Seniority = seniority;
        }

        public AgentDto()
        {
            
        }

        public static AgentDto Create(string name, Seniority seniority)
        {
            return new AgentDto(name, seniority);
        }
    }
}