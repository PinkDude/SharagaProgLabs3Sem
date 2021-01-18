using Lab1.Doubly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1
{
    public class Lab1DoublyListList
    {
        const int MinValue = 1;
        const int MaxValue = 10;
        const uint ValueCount = 5;

        public void Main()
        {
            var list = InitDoublyList();

            Body(list);
        }

        /// <summary>
        /// Тело работы с листом по 1ой лабе
        /// </summary>
        /// <param name="list"></param>
        private void Body(DoublyListList<int> list)
        {
            while (true)
            {
                var exit = false;

                WriteWhatWant();

                var answer = GetAnswer();

                if (answer == null)
                    continue;

                switch (answer)
                {
                    case 1:
                        WriteDoublyList(list);
                        break;
                    case 2:
                        FindInDoublyList(list);
                        break;
                    case 3:
                        AddNewList(ref list);
                        break;
                    case 4:
                        AddElementInList(ref list);
                        break;
                    case 5:
                        DeleteElement(ref list);
                        break;
                    case 6:
                        Delete(ref list);
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Такого значения нет! Попробуй еще раз...");
                        break;
                }

                if (exit)
                    break;
            }
        }

        /// <summary>
        /// Добавление нового списка
        /// </summary>
        private void AddNewList(ref DoublyListList<int> doublyList)
        {
            doublyList.Add();
        }

        /// <summary>
        /// Добавление элемента в заданный список
        /// </summary>
        /// <param name="doublyList"></param>
        private void AddElementInList(ref DoublyListList<int> doublyList)
        {
            Console.WriteLine("В какой список добавить?");
            var position = GetAnswer();
            if (position == null)
                return;

            Console.WriteLine("Какой элемент нужно добавить?");
            var answer = GetAnswer();
            if (answer == null)
                return;

            doublyList.AddIn(position.Value, answer.Value);
        }

        /// <summary>
        /// Удаление элемента
        /// </summary>
        /// <param name="doublyList"></param>
        private void Delete(ref DoublyListList<int> doublyList)
        {
            Console.WriteLine("Какой список нужно удалить?");
            var answer = GetAnswer();
            if (answer == null)
                return;

            doublyList.Remove(answer.Value);
        }

        private void DeleteElement(ref DoublyListList<int> doublyList)
        {
            Console.WriteLine("В каком списке нужно удалить?");
            var position = GetAnswer();
            if (position == null)
                return;

            Console.WriteLine("Какой элемент удалить?");
            var answer = GetAnswer();
            if (answer == null)
                return;

            doublyList.RemoveElement(answer.Value, position.Value);
        }

        ///// <summary>
        ///// Добавить после
        ///// </summary>
        ///// <param name="doublyList"></param>
        //private void AddAfter(ref DoublyListList<int> doublyList)
        //{
        //    Console.WriteLine("После какого элемента нужно добавить?");
        //    var answer = GetAnswer();
        //    if (answer == null)
        //        return;

        //    Console.WriteLine("Какой элемент добавить?");
        //    var value = GetAnswer();
        //    if (value == null)
        //        return;

        //    doublyList.AddAfter(value.Value, answer.Value);
        //}

        ///// <summary>
        ///// Добавить до
        ///// </summary>
        ///// <param name="doublyList"></param>
        //private void AddBefore(ref DoublyListList<int> doublyList)
        //{
        //    Console.WriteLine("До какого элемента нужно добавить?");
        //    var answer = GetAnswer();
        //    if (answer == null)
        //        return;

        //    Console.WriteLine("Какой элемент добавить?");
        //    var value = GetAnswer();
        //    if (value == null)
        //        return;

        //    doublyList.AddBefore(value.Value, answer.Value);
        //}

        /// <summary>
        /// Найти элементы
        /// </summary>
        /// <param name="doublyList"></param>
        private void FindInDoublyList(DoublyListList<int> doublyList)
        {
            Console.WriteLine("Какой элемент нужно найти?");
            var answer = GetAnswer();
            if (answer == null)
                return;

            IReadOnlyList<int> result = doublyList
                .Find(answer.Value)
                .Select(item => item.Data)
                .ToList();

            Console.Write("Найденные элементы: ");
            WriteElements(result);

        }

        /// <summary>
        /// Найти элементы в обраном порядке
        /// </summary>
        /// <param name="doublyList"></param>
        private void ReverseFindInDoublyList(DoublyListList<int> doublyList)
        {
            Console.WriteLine("Какой элемент нужно найти?");
            var answer = GetAnswer();
            if (answer == null)
                return;

            IReadOnlyList<int> result = doublyList
                .FindReverse(answer.Value)
                .Select(item => item.Data)
                .ToList();

            Console.Write("Найденные элементы: ");
            WriteElements(result);

        }

        /// <summary>
        /// Получение ответа из консоли
        /// </summary>
        /// <returns></returns>
        private int? GetAnswer()
        {
            int result;

            Console.Write("Введите число - ");

            var answer = Console.ReadLine();

            var success = Int32.TryParse(answer, out result);

            if (!success)
            {
                Console.WriteLine("Нужно число!");
                return null;
            }

            return result;
        }

        /// <summary>
        /// Вывод меню на экран
        /// </summary>
        private void WriteWhatWant()
        {
            Console.WriteLine("Что хотите сделать?\n1) Вывод элементов\n" + 
                "2) Поиск заданного элемента\n" +
                "3) Добавить новый список\n" +
                "4) Добавление элемента в заданный список\n" +
                "5) Удаление заданного элемента\n" +
                "6) Удаление заданного списка\n" +
                "0) Выход из лабы 'Двусвявзный лист'");
        }

        /// <summary>
        /// Вывод листа на экран
        /// </summary>
        /// <param name="list"></param>
        private void WriteDoublyList(DoublyListList<int> doublyList)
        {
            var list = doublyList.GetList();

            Console.WriteLine("Все элементы: ");
            WriteList(list);
        }

        /// <summary>
        /// Вывод обратного листа на экран
        /// </summary>
        /// <param name="list"></param>
        private void WriteReverseDoublyList(DoublyListList<int> doublyList)
        {
            var list = doublyList.GetReversList();

            Console.Write("Все элементы в обратном порядке: ");
            WriteList(list);
        }

        /// <summary>
        /// Инициализация листа
        /// </summary>
        /// <returns></returns>
        private DoublyListList<int> InitDoublyList()
        {
            var list = new DoublyListList<int>();

            for (var i = 0; i < ValueCount; i++)
                list.Add();

            return list;
        }

        /// <summary>
        /// Возвращает случайное число
        /// </summary>
        /// <returns></returns>
        private int RandomValue()
        {
            var rand = new Random();
            return rand.Next(MinValue, MaxValue);
        }

        private void WriteList(IReadOnlyList<IReadOnlyList<int>> list)
        {
            var i = 1;
            foreach (var item in list)
            {
                Console.WriteLine($"{i} список:");

                if (item == null || !item.Any())
                {
                    Console.Write("Список пуст");
                }
                else
                {

                    foreach (var element in item)
                    {
                        Console.Write(element + " ");
                    }
                }
                Console.WriteLine();
                i++;
            }
            Console.WriteLine();
        }

        private void WriteElements(IReadOnlyList<int> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
