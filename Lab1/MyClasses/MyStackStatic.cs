using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.MyClasses
{
    public class MyStackStatic<T> : MyStack<T>
    {
        public MyStackStatic()
        {
            items = new T[DefaultSize];
        }

        public MyStackStatic(int lenght)
        {
            items = new T[lenght];
        }

        /// <summary>
        /// Добавление элемента
        /// </summary>
        /// <param name="item"></param>
        public override void Push(T item)
        {
            if (count == items.Length)
            {
                Console.WriteLine("Стек переполнен!");
                return;
            }

            items[count++] = item;
        }

        /// <summary>
        /// Удаление елемента
        /// </summary>
        /// <returns></returns>
        public override T Pop()
        {
            if (IsEmpty)
                return default;

            T item = items[--count];

            items[count] = default;

            return item;
        }
    }
}
