using System;
namespace Calamatta.Domain.Models
{
    public class Session
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Session()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }

        public static Session Create()
        {
            return new Session();
        }
    }
}