using System.Collections.Generic;
using Calamatta.Application.Interfaces;

namespace Calamatta.Application.Services
{
    public class QueueService<T> : IQueueService<T> where T : class
    {
        private static Queue<T> _queue;

        public QueueService()
        {
            _queue = new Queue<T>();
        }
        public Queue<T> Get()
        {
            return _queue;
        }
    }
}