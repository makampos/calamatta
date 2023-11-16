using Calamatta.Application.Repositories;
using Calamatta.Domain.Models;

namespace Calamatta.Infrastructure.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        public Session Create()
        {
            return Session.Create();
        }
    }
}