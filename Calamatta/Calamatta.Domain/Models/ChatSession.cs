using System;
using System.Collections.Generic;

namespace Calamatta.Domain.Models
{
    public class ChatSession
    {
        public Guid Id { get; private set; }
        public Agent Agent { get; private set; }
        public IEnumerable<Session> Sessions { get; private set; }
        private ChatSession(Agent agent, IEnumerable<Session> sessions)
        {
            Id = Guid.NewGuid();
            Agent = agent;
            Sessions = sessions;
        }

        public static ChatSession Create(Agent agent, IEnumerable<Session> sessions)
        {
            return new ChatSession(agent, sessions);
        }
    }
}