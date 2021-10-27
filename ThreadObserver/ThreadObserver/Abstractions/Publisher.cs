using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadObserver.Abstractions
{
    public abstract class Publisher : IPublisher
    {
        public Publisher(Queue<int> queue)
        {
            Queue = queue;
        }

        protected Queue<int> Queue { get; }

        public abstract void AddNumberToQueue();
    }
}
