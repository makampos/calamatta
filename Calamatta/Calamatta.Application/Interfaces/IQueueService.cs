using System.Collections.Generic;

namespace Calamatta.Application.Interfaces
{
    public interface IQueueService<T>
    {
        Queue<T> Get();
    }
}