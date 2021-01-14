using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab1.MyClasses
{
    public class MyQueue<T> : IEnumerable<T>
    {
        protected const int DefaultSize = 10;

        protected T[] items;
        protected int count;

        public MyQueue()
        {
            items = new T[DefaultSize];
        }

        public MyQueue(int lenght)
        {
            items = new T[lenght];
        }

        /// <summary>
        /// Пустая ли очередь
        /// </summary>
        public bool IsEmpty { get { return count == 0; } }

        /// <summary>
        /// Количетсво элементов в очереди
        /// </summary>
        public int Count { get { return count; } }

        /// <summary>
        /// Заполненна ли очередь
        /// </summary>
        public bool IsFull { get { return count == items.Length; } }

        /// <summary>
        /// Добавление нового элемента
        /// </summary>
        /// <param name="item"></param>
        public virtual void Enqueue(T item)
        {
            if (count == items.Length)
            {
                Resize(items.Length + DefaultSize);
            }

            items[count++] = item;
        }

        /// <summary>
        /// Удаление первого элемента
        /// </summary>
        /// <returns></returns>
        public virtual T Dequeue()
        {
            if (IsEmpty)
                return default;

            T item = items[0];

            items[0] = default;

            count--;

            ToLeftItems();

            if (count > 0 && count < items.Length - DefaultSize)
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

        /// <summary>
        /// Сдвиг элементов влево
        /// </summary>
        protected void ToLeftItems()
        {
            var temp = new T[items.Length];

            for(var i = 0; i < count; i++)
            {
                temp[i] = items[i + 1];
            }

            for(var i = count; i < items.Length; i++)
            {
                temp[i] = default;
            }

            items = temp;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }
    }
}
