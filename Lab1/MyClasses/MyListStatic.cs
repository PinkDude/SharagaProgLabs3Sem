using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.MyClasses
{
    public class MyListStatic<T> : MyList<T>
    {
        public MyListStatic()
        {
            items = new T[DefaultSize];
        }

        public MyListStatic(int lenght)
        {
            items = new T[lenght];
        }

        /// <summary>
        /// Добавление элемента
        /// </summary>
        /// <param name="item"></param>
        public override void Add(T item)
        {
            if (count == items.Length)
            {
                Console.WriteLine("Список переполнен!");
                return;
            }

            items[count++] = item;
        }

        /// <summary>
        /// Добавить после
        /// </summary>
        /// <param name="item"></param>
        /// <param name="target"></param>
        public override void AddAfter(T item, T target)
        {
            if (IsEmpty)
            {
                Add(item);
            }

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
        public override void Insert(T item, int index = 0)
        {
            if (index < 0)
            {
                Console.WriteLine("Индекс не может быть отрицательным!");
                return;
            }

            if (count == items.Length)
            {
                Console.WriteLine("Список переполнен!");
                return;
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
        public override void Remove(T item)
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
        }
    }
}
