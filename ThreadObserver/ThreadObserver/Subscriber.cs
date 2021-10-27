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
        private Queue<int> _queue;
        private object _locker;

        public Subscriber(Queue<int> queue, object locker)
        {
            _queue = queue;
            _locker = locker;
        }

        public void Update()
        {
            if (_queue.Count == 0)
            {
                return;
            }

            lock (_locker)
            {
                Console.WriteLine($"I have read {_queue.Dequeue()}");
            }
        }
    }
}
