using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Doubly
{
    public class DoublyListList<T> : IEnumerable<DoublyList<T>>
    {
        DoublyItem<DoublyList<T>> head;
        DoublyItem<DoublyList<T>> tail;
        int count;

        /// <summary>
        /// Кол-во элементов
        /// </summary>
        public int Count { get { return count; } }

        /// <summary>
        /// Получение списка элементов
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<IReadOnlyList<T>> GetList()
        {
            var list = new List<IReadOnlyList<T>>(Count);

            var current = head;
            while (current != null)
            {
                var insideList = current.Data?.GetList();

                list.Add(insideList);
                current = current.Next;
            }

            return list;
        }

        /// <summary>
        /// Получение обратного списка элементов
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<IReadOnlyList<T>> GetReversList()
        {
            var list = new List<IReadOnlyList<T>>(Count);

            var current = tail;
            while (current != null)
            {
                var insideList = current.Data.GetReversList();
                list.Add(insideList);
                current = current.Previous;
            }

            return list;
        }

        /// <summary>
        /// Поиск элементов
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public IReadOnlyList<DoublyItem<T>> Find(T data)
        {
            var doubleItems = new List<DoublyItem<T>>();
            var current = head;

            while (current != null)
            {
                var insideFinds = current.Data.Find(data);
                doubleItems.AddRange(insideFinds);

                current = current.Next;
            }

            return doubleItems;
        }

        /// <summary>
        /// Обратный поиск элементов
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public IReadOnlyList<DoublyItem<T>> FindReverse(T data)
        {
            var doubleItems = new List<DoublyItem<T>>();
            var current = tail;

            while (current != null)
            {
                var insideFinds = current.Data.Find(data);
                doubleItems.AddRange(insideFinds);

                current = current.Previous;
            }

            return doubleItems;
        }

        /// <summary>
        /// Добавление элемента
        /// </summary>
        /// <param name="data"></param>
        public void Add()
        {
            var node = new DoublyItem<DoublyList<T>>(new DoublyList<T>());

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }

        /// <summary>
        /// Добавление в определенный элемент
        /// </summary>
        /// <param name="index"></param>
        /// <param name="data"></param>
        public void AddIn(int index, T data)
        {
            if(index < 1 || index > count)
            {
                Console.WriteLine("Элемента с заданным индексом нет!");
                return;
            }

            var current = head;

            for(var i = index - 1; i > 0; i--)
            {
                current = current.Next;
            }

            current.Data.Add(data);
        }

        ///// <summary>
        ///// Добавить после
        ///// </summary>
        ///// <param name="data"></param>
        ///// <param name="findData"></param>
        ///// <returns></returns>
        //public bool AddAfter(T data, T findData)
        //{
        //    var current = head;

        //    while (current != null)
        //    {
        //        if (current.Data.Equals(findData))
        //        {
        //            break;
        //        }
        //        current = current.Next;
        //    }
        //    if (current != null)
        //    {
        //        var dataItem = new DoublyItem<T>(data);
        //        if (current.Next != null)
        //        {
        //            dataItem.Next = current.Next;
        //            current.Next.Previous = dataItem;
        //        }
        //        else
        //        {
        //            tail = dataItem;
        //        }

        //        current.Next = dataItem;
        //        dataItem.Previous = current;

        //        return true;
        //    }
        //    return false;
        //}

        ///// <summary>
        ///// Добавть до
        ///// </summary>
        ///// <param name="data"></param>
        ///// <param name="findData"></param>
        ///// <returns></returns>
        //public bool AddBefore(T data, T findData)
        //{
        //    var current = tail;

        //    while (current != null)
        //    {
        //        if (current.Data.Equals(findData))
        //        {
        //            break;
        //        }
        //        current = current.Previous;
        //    }
        //    if (current != null)
        //    {
        //        var dataItem = new DoublyItem<T>(data);
        //        if (current.Previous != null)
        //        {
        //            dataItem.Previous = current.Previous;
        //            current.Previous.Next = dataItem;
        //        }
        //        else
        //        {
        //            head = dataItem;
        //        }

        //        current.Previous = dataItem;
        //        dataItem.Next = current;

        //        return true;
        //    }
        //    return false;
        //}

        public IEnumerator<DoublyList<T>> GetEnumerator()
        {
            var current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public bool RemoveElement(T data, int index)
        {
            if (index < 1 || index > count)
            {
                Console.WriteLine("Элемента с заданным индексом нет!");
                return false;
            }

            var current = head;

            for (var i = index - 1; i > 0; i--)
            {
                current = current.Next;
            }

            return current.Data.Remove(data);
        }

        /// <summary>
        /// Удаление заданного элемента
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Remove(int index)
        {
            if (index < 1 || index > count)
            {
                Console.WriteLine("Элемента с заданным индексом нет!");
                return false;
            }

            var current = head;

            for (var i = index - 1; i > 0; i--)
            {
                current = current.Next;
            }

            if (current != null)
            {
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    tail = current.Previous;
                }

                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    head = current.Next;
                }
                count--;
                return true;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
