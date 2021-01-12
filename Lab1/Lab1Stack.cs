using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1
{
    public class Lab1Stack
    {
        const int MinValue = 1;
        const int MaxValue = 10;
        const uint ValueCount = 5;

        public void Main()
        {
            var stack = InitStack();

            WriteStack(stack);

            Body(stack);
        }

        /// <summary>
        /// Тело работы со стеком по 1ой лабе
        /// </summary>
        /// <param name="stack"></param>
        private void Body(Stack<int> stack)
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
                        if (!StackIsEmpty(stack))
                            Console.WriteLine("Стек не пустой...");
                        break;
                    case 2:
                        WriteStackCount(stack);
                        break;
                    case 3:
                        AddInStack(ref stack);
                        break;
                    case 4:
                        DeleteFromStack(ref stack);
                        break;
                    case 5:
                        WriteStack(stack);
                        break;
                    case 6:
                        StackAddRange(ref stack);
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
        /// Добавление в стек несколько случайных элементов
        /// </summary>
        /// <param name="stack"></param>
        private void StackAddRange(ref Stack<int> stack)
        {
            Console.WriteLine("Сколько элементов добавить?");

            var answer = GetAnswer();
            if (answer == null)
                return;

            for(var i = 0; i < answer; i++)
            {
                stack.Push(RandomValue());
            }
        }

        /// <summary>
        /// Вывод кол-ва элементов в стеке 
        /// </summary>
        /// <param name="stack"></param>
        private void WriteStackCount(Stack<int> stack)
        {
            Console.WriteLine($"Кол-во элементов - {stack.Count}");
        }

        /// <summary>
        /// Проверка на пустой стек
        /// </summary>
        /// <param name="stack"></param>
        /// <returns></returns>
        private bool StackIsEmpty(Stack<int> stack)
        {
            if(stack == null || stack.Count() == 0)
            {
                Console.WriteLine("Стек пустой!");
                return true;
            }

            return false;
        }

        /// <summary>
        /// Удаление верхнего элемента из стека
        /// </summary>
        /// <param name="stack"></param>
        private void DeleteFromStack(ref Stack<int> stack)
        {
            if (StackIsEmpty(stack))
                return;

            stack.Pop();
        }

        /// <summary>
        /// Добавление элемента в стек
        /// </summary>
        /// <param name="stack"></param>
        private void AddInStack(ref Stack<int> stack)
        {
            var answer = GetAnswer();
            if (answer == null)
                return;

            stack.Push(answer.Value);
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
            Console.WriteLine("Что хотите сделать?\n1) Проверка на пустоту\n2) Вывод кол-ва элементов\n" 
                + "3) Добавить новый элемент в вершину стека\n4) Удаление элемента из вершины стека\n5) Вывод стека на экран\n" 
                + "6) Добавить несколько новых элементов\n0) Выход из лабы 'Стек'");
        }

        /// <summary>
        /// Вывод стека на экран
        /// </summary>
        /// <param name="stack"></param>
        private void WriteStack(Stack<int> stack)
        {
            Console.Write("Stack = ");
            foreach(var item in stack)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("");
        }

        /// <summary>
        /// Инициализация стека
        /// </summary>
        /// <returns></returns>
        private Stack<int> InitStack()
        {
            var stack = new Stack<int>((int)ValueCount);

            for (var i = 0; i < ValueCount; i++)
                stack.Push(RandomValue());

            return stack;
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
