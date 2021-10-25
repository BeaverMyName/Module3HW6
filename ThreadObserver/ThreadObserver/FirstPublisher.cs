using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThreadObserver.Abstractions;

namespace ThreadObserver
{
    public class FirstPublisher : Publisher
    {
        private object _locker;

        public FirstPublisher(Queue<int> queue, object locker)
            : base(queue)
        {
            _locker = locker;
        }

        public override void AddNumberToQueue()
        {
            lock (_locker)
            {
                var random = new Random().Next(1, 10);
                Queue.Enqueue(random);
                Console.WriteLine($"First publisher has added a number: {random}.");
            }
        }
    }
}
