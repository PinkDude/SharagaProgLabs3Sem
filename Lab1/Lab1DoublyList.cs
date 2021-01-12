using Lab1.Doubly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1
{
    public class Lab1DoublyList
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
        private void Body(DoublyList<int> list)
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
                        WriteReverseDoublyList(list);
                        break;
                    case 3:
                        FindInDoublyList(list);
                        break;
                    case 4:
                        ReverseFindInDoublyList(list);
                        break;
                    case 5:
                        AddAfter(ref list);
                        break;
                    case 6:
                        AddBefore(ref list);
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
        /// Добавить после
        /// </summary>
        /// <param name="doublyList"></param>
        private void AddAfter(ref DoublyList<int> doublyList)
        {
            Console.WriteLine("После какого элемента нужно добавить?");
            var answer = GetAnswer();
            if (answer == null)
                return;

            Console.WriteLine("Какой элемент добавить?");
            var value = GetAnswer();
            if (value == null)
                return;

            doublyList.AddAfter(value.Value, answer.Value);
        }

        /// <summary>
        /// Добавить до
        /// </summary>
        /// <param name="doublyList"></param>
        private void AddBefore(ref DoublyList<int> doublyList)
        {
            Console.WriteLine("До какого элемента нужно добавить?");
            var answer = GetAnswer();
            if (answer == null)
                return;

            Console.WriteLine("Какой элемент добавить?");
            var value = GetAnswer();
            if (value == null)
                return;

            doublyList.AddBefore(value.Value, answer.Value);
        }

        /// <summary>
        /// Найти элементы
        /// </summary>
        /// <param name="doublyList"></param>
        private void FindInDoublyList(DoublyList<int> doublyList)
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
            WriteList(result);

        }

        /// <summary>
        /// Найти элементы в обраном порядке
        /// </summary>
        /// <param name="doublyList"></param>
        private void ReverseFindInDoublyList(DoublyList<int> doublyList)
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
            WriteList(result);

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
            Console.WriteLine("Что хотите сделать?\n1) Вывод элементов\n"
                + "2) Обратный вывод элементов\n3) Поиск элементов\n4) Обратный поиск элементов\n"
                + "5) Добавить после\n6) Добавить до\n0) Выход из лабы 'Двусвявзный лист'");
        }

        /// <summary>
        /// Вывод листа на экран
        /// </summary>
        /// <param name="list"></param>
        private void WriteDoublyList(DoublyList<int> doublyList)
        {
            var list = doublyList.GetList();

            Console.Write("Все элементы: ");
            WriteList(list);
        }

        /// <summary>
        /// Вывод обратного листа на экран
        /// </summary>
        /// <param name="list"></param>
        private void WriteReverseDoublyList(DoublyList<int> doublyList)
        {
            var list = doublyList.GetReversList();

            Console.Write("Все элементы в обратном порядке: ");
            WriteList(list);
        }

        /// <summary>
        /// Инициализация листа
        /// </summary>
        /// <returns></returns>
        private DoublyList<int> InitDoublyList()
        {
            var list = new DoublyList<int>();

            for (var i = 0; i < ValueCount; i++)
                list.Add(RandomValue());

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

        private void WriteList(IReadOnlyList<int> list)
        {
            foreach(var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
