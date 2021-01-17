using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab1.MyClasses
{
    public class MyList<T> : IEnumerable<T>
    {
        protected const int DefaultSize = 10;

        protected T[] items;
        protected int count;

        public MyList()
        {
            items = new T[DefaultSize];
        }

        public MyList(int lenght)
        {
            items = new T[lenght];
        }

        /// <summary>
        /// Пустая ли очередь
        /// </summary>
        public bool IsEmpty { get { return count == 0; } }

        /// <summary>
        /// Количетсво элементов в списке
        /// </summary>
        public int Count { get { return count; } }

        /// <summary>
        /// Добавление нового элемента
        /// </summary>
        /// <param name="item"></param>
        public virtual void Add(T item)
        {
            if (count == items.Length)
            {
                Resize(items.Length + DefaultSize);
            }

            items[count++] = item;
        }

        /// <summary>
        /// Добавить до
        /// </summary>
        /// <param name="item"></param>
        /// <param name="target"></param>
        public void AddBefore(T item, T target)
        {
            for (var i = 0; i < count; i++)
            {
                if (items[i].Equals(target))
                {
                    Insert(item, i);
                    return;
                }
            }
        }

        /// <summary>
        /// Добавить после
        /// </summary>
        /// <param name="item"></param>
        /// <param name="target"></param>
        public virtual void AddAfter(T item, T target)
        {
            for (var i = count - 1; i >= 0; i--)
            {
                if (items[i].Equals(target))
                {
                    Insert(item, i + 1);
                    return;
                }
            }
        }

        /// <summary>
        /// Добавление элемента по индексу
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index"></param>
        public virtual void Insert(T item, int index = 0)
        {
            if (index < 0)
            {
                Console.WriteLine("Индекс не может быть отрицательным!");
                return;
            }

            if (count == items.Length)
            {
                Resize(items.Length + DefaultSize);
            }

            if (index >= count)
            {
                index = count;
            }

            ToRightItems(index);

            items[index] = item;

            count++;
        }

        /// <summary>
        /// Удаление элемента
        /// </summary>
        /// <returns></returns>
        public virtual void Remove(T item)
        {
            if (IsEmpty)
                return;

            var indexes = GetIndexesOf(item);

            foreach (var index in indexes)
            {
                items[index] = default;

                count--;

                ToLeftItems(index);
            }

            if (count > 0 && count < items.Length - DefaultSize)
            {
                Resize(items.Length - DefaultSize);
            }
        }

        public IReadOnlyList<int> GetIndexesOf(T item)
        {
            var indexes = new List<int>();
            for (var i = 0; i < count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(items[i], item))
                {
                    indexes.Add(i);
                }
            }

            indexes.Reverse();

            return indexes;
        }

        /// <summary>
        /// Сдвиг элементов вправо
        /// </summary>
        /// <param name="index"></param>
        protected void ToRightItems(int index)
        {
            for (var i = count; i > index; i--)
            {
                items[i] = items[i - 1];
            }

            items[index] = default;
        }

        /// <summary>
        /// Сдвиг элементов влево
        /// </summary>
        protected void ToLeftItems(int index)
        {
            var temp = new T[items.Length];

            for (var i = 0; i < index; i++)
            {
                temp[i] = items[i];
            }

            for (var i = index; i < count; i++)
            {

                temp[i] = items[i + 1];
            }

            for (var i = count; i < items.Length; i++)
            {
                temp[i] = default;
            }

            items = temp;
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
            foreach (var item in items)
            {
                yield return item;
            }
        }
    }
}
