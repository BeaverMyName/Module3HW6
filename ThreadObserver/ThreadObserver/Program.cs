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
            var firstPublisher = new FirstPublisher();
            var secondPublisher = new SecondPublisher();
            var subscriber = new Subscriber();
            var queue = new Queue<int>();

            firstPublisher.Attach(subscriber);
            secondPublisher.Attach(subscriber);

            var firstThread = new Thread(() =>
            {
                for (var i = 0; i < 10; i++)
                {
                    lock (locker)
                    {
                        firstPublisher.AddNumberToQueue(queue);
                    }

                    Thread.Sleep(500);
                }
            });

            var secondThread = new Thread(() =>
            {
                for (var i = 0; i < 10; i++)
                {
                    lock (locker)
                    {
                        secondPublisher.AddNumberToQueue(queue);
                    }

                    Thread.Sleep(500);
                }
            });

            firstThread.Start();
            secondThread.Start();
        }
    }
}
