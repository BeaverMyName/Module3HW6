using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadObserver.Abstractions
{
    public abstract class Publisher : IPublisher
    {
        public event EventHandler<QueueEventArgs> Published;

        public abstract void AddNumberToQueue(Queue<int> queue);

        public void Attach(ISubscriber subscriber)
        {
            Published += subscriber.Update;
        }

        public void Detach(ISubscriber subscriber)
        {
            Published -= subscriber.Update;
        }

        public void Publish(Queue<int> queue)
        {
            Console.WriteLine($"{GetType()} has published a queue.");
            Published?.Invoke(this, new QueueEventArgs { Queue = queue });
        }
    }
}
