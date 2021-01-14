using Lab1.MyClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1
{
    public class Lab1Queue
    {
        protected const int MinValue = 1;
        protected const int MaxValue = 10;
        protected const uint ValueCount = 5;

        public void Main()
        {
            var queue = InitQueue();

            WriteQueue(queue);

            Body(queue);
        }

        /// <summary>
        /// Тело работы со стеком по 1ой лабе
        /// </summary>
        /// <param name="queue"></param>
        private void Body(MyQueue<int> queue)
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
                        if (!QueueIsEmpty(queue))
                            Console.WriteLine("Очередь не пустая...");
                        break;
                    case 2:
                        CheckQueueFull(queue);
                        break;
                    case 3:
                        AddInQueue(ref queue);
                        break;
                    case 4:
                        DeleteFromQueue(ref queue);
                        break;
                    case 5:
                        WriteQueue(queue);
                        break;
                    case 6:
                        QueueAddRange(ref queue);
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
        /// Добавление в очередь несколько случайных элементов
        /// </summary>
        /// <param name="queue"></param>
        private void QueueAddRange(ref MyQueue<int> queue)
        {
            Console.WriteLine("Сколько элементов добавить?");

            var answer = GetAnswer();
            if (answer == null)
                return;

            for (var i = 0; i < answer; i++)
            {
                queue.Enqueue(RandomValue());
            }
        }

        /// <summary>
        /// Проверка на заполненность
        /// </summary>
        /// <param name="queue"></param>
        private void CheckQueueFull(MyQueue<int> queue)
        {
            if (queue.IsFull)
            {
                Console.WriteLine("Очередь заполнена!");
            }
            else
            {
                Console.WriteLine("Очередь не заполнена...");
            }
        }

        /// <summary>
        /// Проверка на пустую очередь
        /// </summary>
        /// <param name="queue"></param>
        /// <returns></returns>
        private bool QueueIsEmpty(MyQueue<int> queue)
        {
            if (queue == null || queue.Count == 0)
            {
                Console.WriteLine("Очередь пустая!");
                return true;
            }

            return false;
        }

        /// <summary>
        /// Удаление элемента из очереди
        /// </summary>
        /// <param name="queue"></param>
        private void DeleteFromQueue(ref MyQueue<int> queue)
        {
            if (QueueIsEmpty(queue))
                return;

            queue.Dequeue();
        }

        /// <summary>
        /// Добавление элемента в очередь
        /// </summary>
        /// <param name="queue"></param>
        private void AddInQueue(ref MyQueue<int> queue)
        {
            var answer = GetAnswer();
            if (answer == null)
                return;

            queue.Enqueue(answer.Value);
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
            Console.WriteLine("Что хотите сделать?\n1) Проверка на пустоту\n2) Проверка на заполненность\n"
                + "3) Добавить новый элемент в очередь\n4) Удаление элемента из очереди\n5) Вывод очереди на экран\n"
                + "6) Добавить несколько новых элементов\n0) Выход из лабы 'Очередь'");
        }

        /// <summary>
        /// Вывод очереди на экран
        /// </summary>
        /// <param name="queue"></param>
        private void WriteQueue(MyQueue<int> queue)
        {
            Console.Write("Queue = ");
            foreach (var item in queue)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("");
        }

        /// <summary>
        /// Инициализация очереди
        /// </summary>
        /// <returns></returns>
        protected virtual MyQueue<int> InitQueue()
        {
            var queue = new MyQueue<int>((int)ValueCount);

            for (var i = 0; i < ValueCount; i++)
                queue.Enqueue(RandomValue());

            return queue;
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
