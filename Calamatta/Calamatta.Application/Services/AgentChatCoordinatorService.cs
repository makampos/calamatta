using System;
using System.Collections.Generic;
using System.Linq;
using Calamatta.Application.Interfaces;
using Calamatta.Domain.Constants;
using Calamatta.Domain.Models;

namespace Calamatta.Application.Services
{
    public class AgentChatCoordinatorService : IAgentChatCoordinatorService
    {
        private readonly ITeamService _teamService;
        private readonly IQueueService<Session> _queueService;
        private readonly IChatSessionService _chatSessionService;
        
        public AgentChatCoordinatorService(ITeamService teamService,
            IQueueService<Session> queueService, IChatSessionService chatSessionService)
        {
            _teamService = teamService ?? throw new ArgumentNullException(nameof(teamService));
            _queueService = queueService ?? throw new ArgumentException(nameof(queueService));
            _chatSessionService = chatSessionService ?? throw new ArgumentNullException(nameof(chatSessionService));
        }
        
        public void AssignChat(int chatRequest)
        {
            var queue = _queueService.Get();
            
            var teams = _teamService.Get();

            if (!queue.Any()) return;

            foreach (var team in teams)
            {       
                foreach (var group in team.Agents.GroupBy(x => x.Seniority)
                             .OrderBy(x => x.Key))
                {
                    foreach (var agent in group.Where(x => x.IsWorking))
                    {
                        var individualCapacity = 1 * MaximumConcurrency.Max * agent.SeniorityMultiplier;

                        var idc = (int)individualCapacity;

                        var sessions = DequeueSession(idc, queue);

                        if (sessions.Count() != 0)
                        {
                            Assign(agent, sessions);
                        }
                    }
                }
            }
        }

        private IEnumerable<Session> DequeueSession(int individualCapacity,
            Queue<Session> queue)
        {
            var sessions = new List<Session>();

            for (var i = 0; i < individualCapacity; i++)
            {
                if (!queue.Any())
                {
                    break;
                }
                
                sessions.Add(queue.Dequeue());
            }
            
            return sessions;
        }

        private void Assign(Agent agent, IEnumerable<Session> sessions)
        {
            var chatSessions = ChatSession.Create(agent, sessions);
                        
            _chatSessionService.Create(chatSessions);
        }
    }
}