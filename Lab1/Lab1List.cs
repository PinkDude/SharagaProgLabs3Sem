using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1
{
    class Lab1List
    {
        const int MinValue = 1;
        const int MaxValue = 10;
        const uint ValueCount = 5;

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
        private void Body(List<int> list)
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
                        AddInList(ref list);
                        break;
                    case 3:
                        DeleteFromList(ref list);
                        break;
                    case 4:
                        WriteList(list);
                        break;
                    case 5:
                        ListAddRange(ref list);
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

        private void FindInList(List<int> list)
        {
            Console.WriteLine("Какой элемент нужно найти?");
            var answer = GetAnswer();
            if (answer == null)
                return;

            IReadOnlyList<int> result = list
                .Where(item => item == answer)
                .ToList();

            Console.Write("Найденные элементы: ");
            foreach(var item in result)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Добавление в лист несколько случайных элементов
        /// </summary>
        /// <param name="list"></param>
        private void ListAddRange(ref List<int> list)
        {
            Console.WriteLine("Сколько элементов добавить?");

            var answer = GetAnswer();
            if (answer == null)
                return;

            var newList = new List<int>((int)answer);

            for (var i = 0; i < answer; i++)
            {
                newList.Add(RandomValue());
            }

            list.AddRange(newList);
        }

        /// <summary>
        /// Проверка на пустой лист
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private bool ListIsEmpty(List<int> list)
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
        private void DeleteFromList(ref List<int> list)
        {
            if (ListIsEmpty(list))
                return;

            Console.WriteLine("Удалить по какому индексу?");

            var answer = GetAnswer();

            if (answer == null)
                return;

            list.RemoveAt(answer.Value);
        }

        /// <summary>
        /// Добавление элемента в лист
        /// </summary>
        /// <param name="list"></param>
        private void AddInList(ref List<int> list)
        {
            Console.WriteLine("Какое число добавить?");
            var answer = GetAnswer();
            if (answer == null)
                return;

            Console.WriteLine("На какую позицию добавить?");
            var position = GetAnswer();
            if (position == null)
                return;

            if (position > list.Count())
            {
                list.Add(answer.Value);
                return;
            }

            if(position < 0)
                position = 0;

            list.Insert(position.Value, answer.Value);
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
            Console.WriteLine("Что хотите сделать?\n1) Поиск элемента в списке\n"
                + "2) Добавить новый элемент в список\n3) Удаление элемента из списка\n4) Вывод списка на экран\n"
                + "5) Добавить несколько новых элементов\n0) Выход из лабы 'Список'");
        }

        /// <summary>
        /// Вывод листа на экран
        /// </summary>
        /// <param name="list"></param>
        private void WriteList(List<int> list)
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
        private List<int> InitList()
        {
            var list = new List<int>((int)ValueCount);

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
    }
}
