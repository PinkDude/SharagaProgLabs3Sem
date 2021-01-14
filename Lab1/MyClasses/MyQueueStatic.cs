using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.MyClasses
{
    public class MyQueueStatic<T> : MyQueue<T>
    {
        public MyQueueStatic()
        {
            items = new T[DefaultSize];
        }

        public MyQueueStatic(int lenght)
        {
            items = new T[lenght];
        }

        /// <summary>
        /// Добавление нового элемента
        /// </summary>
        /// <param name="item"></param>
        public override void Enqueue(T item)
        {
            if (count == items.Length)
            {
                Console.WriteLine("Очередь переполненна!");
                return;
            }

            items[count++] = item;
        }

        /// <summary>
        /// Удаление первого элемента
        /// </summary>
        /// <returns></returns>
        public override T Dequeue()
        {
            if (IsEmpty)
                return default;

            T item = items[0];

            items[0] = default;

            count--;

            ToLeftItems();

            return item;
        }
    }
}
