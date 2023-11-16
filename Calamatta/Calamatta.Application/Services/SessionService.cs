using System;
using Calamatta.Application.Interfaces;
using Calamatta.Application.Repositories;
using Calamatta.Domain.Models;

namespace Calamatta.Application.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;
        
        public SessionService(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository ?? throw new ArgumentNullException(nameof(sessionRepository));
            
        }
        public Session Create()
        {
            return _sessionRepository.Create();
        }
    }
}