using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThreadObserver.Abstractions;

namespace ThreadObserver
{
    public class SecondPublisher : Publisher
    {
        private object _locker;

        public SecondPublisher(Queue<int> queue, object locker)
            : base(queue)
        {
            _locker = locker;
        }

        public override void AddNumberToQueue()
        {
            lock (_locker)
            {
                var random = new Random().Next(11, 20);
                Queue.Enqueue(random);
                Console.WriteLine($"Second publisher has added a number: {random}.");
            }
        }
    }
}
