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
        public override void AddNumberToQueue(Queue<int> queue)
        {
            var random = new Random().Next(1, 10);
            queue.Enqueue(random);
            Console.WriteLine($"First publisher has added a number: {random}.");
            Publish(queue);
        }
    }
}
