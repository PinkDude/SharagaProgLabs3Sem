using Lab1.MyClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1
{
    public class Lab1List
    {
        protected const int MinValue = 1;
        protected const int MaxValue = 10;
        protected const uint ValueCount = 5;

        public void Main()
        {
            var list = InitList();

            WriteList(list);

            Body(list);
        }

        /// <summary>
        /// Тело работы с листом по 1ой лабе
        /// </summary>
        /// <param name="list"></param>
        private void Body(MyList<int> list)
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
                        FindInList(list);
                        break;
                    case 2:
                        AddInListBefore(ref list);
                        break;
                    case 3:
                        AddInListAfter(ref list);
                        break;
                    case 4:
                        DeleteFromList(ref list);
                        break;
                    case 5:
                        WriteList(list);
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

        private void FindInList(MyList<int> list)
        {
            Console.WriteLine("Какой элемент нужно найти?");
            var answer = GetAnswer();
            if (answer == null)
                return;

            IReadOnlyList<int> result = list.GetIndexesOf(answer.Value);

            Console.Write("Индексы найденных элементов: ");
            foreach(var item in result)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Проверка на пустой лист
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private bool ListIsEmpty(MyList<int> list)
        {
            if (list == null || list.Count() == 0)
            {
                Console.WriteLine("Список пустой!");
                return true;
            }

            return false;
        }

        /// <summary>
        /// Удаление элемента из листа
        /// </summary>
        /// <param name="list"></param>
        private void DeleteFromList(ref MyList<int> list)
        {
            if (ListIsEmpty(list))
                return;

            Console.WriteLine("Какое число удалить?");

            var answer = GetAnswer();

            if (answer == null)
                return;

            list.Remove(answer.Value);
        }

        /// <summary>
        /// Добавление элемента в лист до заднного
        /// </summary>
        /// <param name="list"></param>
        private void AddInListBefore(ref MyList<int> list)
        {
            Console.WriteLine("Какое число добавить?");
            var answer = GetAnswer();
            if (answer == null)
                return;

            Console.WriteLine("До каким числом?");
            var target = GetAnswer();
            if (target == null)
                return;

            list.AddBefore(answer.Value, target.Value);
        }

        /// <summary>
        /// Добавление элемента в лист после заданного
        /// </summary>
        /// <param name="list"></param>
        private void AddInListAfter(ref MyList<int> list)
        {
            Console.WriteLine("Какое число добавить?");
            var answer = GetAnswer();
            if (answer == null)
                return;

            Console.WriteLine("После какого числа?");
            var target = GetAnswer();
            if (target == null)
                return;

            list.AddAfter(answer.Value, target.Value);
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
            Console.WriteLine("Что хотите сделать?\n1) Поиск элемента в списке\n" +
                "2) Добавить новый элемент в список до\n" +
                "3) Добавить новый элемент в список после\n" +
                "4) Удаление элемента из списка\n" +
                "5) Вывод списка на экран\n" +
                "0) Выход из лабы 'Список'");
        }

        /// <summary>
        /// Вывод листа на экран
        /// </summary>
        /// <param name="list"></param>
        private void WriteList(MyList<int> list)
        {
            Console.Write("List = ");
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("");
        }

        /// <summary>
        /// Инициализация листа
        /// </summary>
        /// <returns></returns>
        protected virtual MyList<int> InitList()
        {
            var list = new MyList<int>((int)ValueCount);

            for (var i = 0; i < ValueCount; i++)
                list.Add(RandomValue());

            return list;
        }

        /// <summary>
        /// Возвращает случайное число
        /// </summary>
        /// <returns></returns>
        protected int RandomValue()
        {
            var rand = new Random();
            return rand.Next(MinValue, MaxValue);
        }
    }
}
