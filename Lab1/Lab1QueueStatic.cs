using Lab1.MyClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public class Lab1QueueStatic : Lab1Queue
    {
        /// <summary>
        /// Инициализация очереди
        /// </summary>
        /// <returns></returns>
        protected override MyQueue<int> InitQueue()
        {
            var queue = new MyQueueStatic<int>((int)ValueCount);

            for (var i = 0; i < ValueCount; i++)
                queue.Enqueue(RandomValue());

            return queue;
        }
    }
}
