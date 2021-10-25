using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadObserver.Abstractions
{
    public interface IPublisher
    {
        public event EventHandler<QueueEventArgs> Published;

        public void AddNumberToQueue(Queue<int> queue);
    }
}
