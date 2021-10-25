using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadObserver.Abstractions;

namespace ThreadObserver
{
    public class Subscriber : ISubscriber
    {
        public void Update(object sender, QueueEventArgs eventArgs)
        {
            Console.WriteLine($"I have read {eventArgs.Queue.Dequeue()} from {sender.GetType()}.");
        }
    }
}
