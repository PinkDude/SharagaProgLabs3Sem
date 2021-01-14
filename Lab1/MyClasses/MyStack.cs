using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab1.MyClasses
{
    public class MyStack<T> : IEnumerable<T>
    {
        protected const int DefaultSize = 10;

        protected T[] items;
        protected int count;

        public MyStack()
        {
            items = new T[DefaultSize];
        }

        public MyStack(int lenght)
        {
            items = new T[lenght];
        }

        public bool IsEmpty { get { return count == 0; } }

        public int Count { get { return count; } }

        public bool IsFull { get { return count == items.Length; } }

        /// <summary>
        /// Добавление элемента
        /// </summary>
        /// <param name="item"></param>
        public virtual void Push(T item)
        {
            if(count == items.Length)
            {
                Resize(items.Length + DefaultSize);
            }

            items[count++] = item;
        }

        /// <summary>
        /// Удаление елемента
        /// </summary>
        /// <returns></returns>
        public virtual T Pop()
        {
            if (IsEmpty)
                return default;

            T item = items[--count];

            items[count] = default;

            if(count > 0 && count < items.Length - DefaultSize)
            {
                Resize(items.Length - DefaultSize);
            }

            return item;
        }

        /// <summary>
        /// Получение последнего элемента
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            return items[count - 1];
        }

        /// <summary>
        /// Изменение размера
        /// </summary>
        /// <param name="max"></param>
        private void Resize(int max)
        {
            T[] tempItems = new T[max];
            for (int i = 0; i < count; i++)
                tempItems[i] = items[i];
            items = tempItems;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach(var item in items)
            {
                yield return item;
            }
        }
    }
}
