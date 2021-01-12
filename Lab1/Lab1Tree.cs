using Lab1.Trees;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public class Lab1Tree
    {
        const int Level = 2;

        public void Main()
        {
            var tree = new Tree(Level);

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
                        WriteTree(tree);
                        break;
                    case 2:
                        WriteTreeSim(tree);
                        break;
                    case 3:
                        WriteTreeSimRev(tree);
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
        /// Вывод дерева в прямом порядке
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="i"></param>
        private void WriteTree(Tree tree, int i = 0)
        {
            if (tree == null)
                return;

            string tab = new string('\t', i);

            Console.WriteLine(tab + tree.Number);

            WriteTree(tree.Left, i + 1);
            WriteTree(tree.Right, i + 1);
        }

        /// <summary>
        /// Вывод дерева в симметричном порядке
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="i"></param>
        private void WriteTreeSim(Tree tree, int i = 0)
        {
            if (tree == null)
                return;

            string tab = new string('\t', i);

            WriteTreeSim(tree.Left, i + 1);
            Console.WriteLine(tab + tree.Number);
            WriteTreeSim(tree.Right, i + 1);
        }

        /// <summary>
        /// Вывод дерева в обратно-симметричном порядке
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="i"></param>
        private void WriteTreeSimRev(Tree tree, int i = 0)
        {
            if (tree == null)
                return;

            string tab = new string('\t', i);

            WriteTreeSimRev(tree.Right, i + 1);
            Console.WriteLine(tab + tree.Number);
            WriteTreeSimRev(tree.Left, i + 1);
        }

        /// <summary>
        /// Вывод меню на экран
        /// </summary>
        private void WriteWhatWant()
        {
            Console.WriteLine("Что хотите сделать?\n1) Вывод элементов в прямом порядке\n"
                + "2) Вывод элементов в симметричном порядке\n" 
                + "3) Вывод элементов в обратно-симметричном порядке\n" 
                + "0) Выход из лабы 'Древовидные структуры'");
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
    }
}
