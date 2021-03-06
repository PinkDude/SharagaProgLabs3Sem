﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var exit = false;
            while (true)
            {
                Console.WriteLine("Выберите программу:");
                Console.WriteLine("1) Стек\n2) Очередь\n3) Лист\n4) Двусвязный лист\n" 
                    + "5) Древовидные структуры\n" 
                    + "6) Сортировки\n"
                    + "7) Статический стек\n"
                    + "8) Статическая очередь\n"
                    + "9) Статический лист\n"
                    + "10) Двунаправленный списк в списке\n"
                    + "0) Выход");

                var answer = GetAnswer();

                if (answer == null)
                    continue;

                switch (answer)
                {
                    case 1:
                        GetStack();
                        break;
                    case 2:
                        GetQueue();
                        break;
                    case 3:
                        GetList();
                        break;
                    case 4:
                        GetDoublyList();
                        break;
                    case 5:
                        GetTree();
                        break;
                    case 6:
                        GetSort();
                        break;
                    case 7:
                        GetStackStatic();
                        break;
                    case 8:
                        GetQueueStatic();
                        break;
                    case 9:
                        GetListStatic();
                        break;
                    case 10:
                        GetDoublyListList();
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Такого значения нет!");
                        break;
                }

                if (exit)
                    break;
            }
        }

        static void GetDoublyListList()
        {
            var sort = new Lab1DoublyListList();

            sort.Main();
        }

        static void GetListStatic()
        {
            var sort = new Lab1ListStatic();

            sort.Main();
        }

        static void GetStackStatic()
        {
            var sort = new Lab1StackStatic();

            sort.Main();
        }

        static void GetQueueStatic()
        {
            var tree = new Lab1QueueStatic();

            tree.Main();
        }

        static void GetSort()
        {
            var sort = new Lab1Sort();

            sort.Main();
        }

        static void GetTree()
        {
            var tree = new Lab1Tree();

            tree.Main();
        }

        static int? GetAnswer()
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

        static void GetDoublyList()
        {
            var doublyList = new Lab1DoublyList();

            doublyList.Main();
        }

        static void GetList()
        {
            var list = new Lab1List();

            list.Main();
        }

        static void GetStack()
        {
            var stack = new Lab1Stack();

            stack.Main();
        }

        static void GetQueue()
        {
            var queue = new Lab1Queue();

            queue.Main();
        }
    }
}
