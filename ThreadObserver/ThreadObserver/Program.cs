using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadObserver
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var locker = new object();
            var queue = new Queue<int>();
            var firstPublisher = new FirstPublisher(queue, locker);
            var secondPublisher = new SecondPublisher(queue, locker);
            var subscriber = new Subscriber(queue, locker);

            var firstThread = new Thread(() =>
            {
                for (var i = 0; i < 10; i++)
                {
                    firstPublisher.AddNumberToQueue();

                    Thread.Sleep(500);
                }
            });

            var secondThread = new Thread(() =>
            {
                for (var i = 0; i < 10; i++)
                {
                    secondPublisher.AddNumberToQueue();

                    Thread.Sleep(1000);
                }
            });

            var thirdThread = new Thread(() =>
            {
                Thread.Sleep(100);

                while (queue.Count > 0)
                {
                    subscriber.Update();

                    Thread.Sleep(1200);
                }
            });

            firstThread.Start();
            secondThread.Start();
            thirdThread.Start();
        }
    }
}
