using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public class Lab1Sort
    {
        const int MassLenght = 100;

        public void Main()
        {
            var mass = InitMass(MassLenght);

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
                        WriteMass(mass);
                        break;
                    case 2:
                        var sortMassPuz = SortPuz(in mass);
                        WriteMass(sortMassPuz);
                        break;
                    case 3:
                        var sortMassSelection = SelectionSort(in mass);
                        WriteMass(sortMassSelection);
                        break;
                    case 4:
                        var sortMassInsertion = InsertionSort(in mass);
                        WriteMass(sortMassInsertion);
                        break;
                    case 5:
                        var sortMassUpgradePuz = UpgradeSortPuz(in mass);
                        WriteMass(sortMassUpgradePuz);
                        break;
                    case 6:
                        var sortMassUpgradeSelection = UpgradeSortSelection(in mass);
                        WriteMass(sortMassUpgradeSelection);
                        break;
                    case 7:
                        var sortMassUpgradeInsertion = UpgradeSortInsertion(in mass);
                        WriteMass(sortMassUpgradeInsertion);
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

        #region UpgradeSorting

        /// <summary>
        /// Улучшенная сортировка вставками
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        private int[] UpgradeSortInsertion(in int[] mass)
        {
            var result = CopyArray(mass);

            int sravCount = 0, swapCount = 0;

            var d = result.Length / 2;
            while (d >= 1)
            {
                for (var i = d; i < result.Length; i++)
                {
                    var j = i;
                    sravCount++;
                    while ((j >= d) && (result[j - d] > result[j]))
                    {
                        Swap(ref result[j], ref result[j - d]);
                        j -= d;
                        swapCount++;
                    }
                }

                d = d / 2;
            }

            WriteCounters(sravCount, swapCount);

            return result;
        }

        /// <summary>
        /// Улучшенная сортировка выбором
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        private int[] UpgradeSortSelection(in int[] mass)
        {
            var result = CopyArray(mass);

            int sravCount = 0, swapCount = 0;

            int minindex = 0, maxindex = 0;
            for (int j = 0; j < result.Length / 2; j++)
            {
                var min = int.MaxValue; var max = 0;
                int tmp;
                for (int i = j; i < result.Length - j; i++)
                {
                    sravCount++;
                    if (min > result[i])
                    {
                        min = result[i];
                        minindex = i;
                    }
                    if (result[i] > max)
                    {
                        max = result[i];
                        maxindex = i;
                    }
                }

                tmp = result[j];
                if (j == maxindex)
                {
                    maxindex = minindex;
                }

                result[j] = min;
                result[minindex] = tmp;

                tmp = result[result.Length - j - 1];
                result[result.Length - j - 1] = max;
                result[maxindex] = tmp;

                swapCount++;
            }

            WriteCounters(sravCount, swapCount);

            return result;
        }

        /// <summary>
        /// Улучшенная сортировка пузырьком
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        private int[] UpgradeSortPuz(in int[] mass)
        {
            var result = CopyArray(mass);

            int sravCount = 0, swapCount = 0;

            for (var i = 0; i < result.Length / 2; i++)
            {
                var swapFlag = false;

                for (var j = i; j < result.Length - i - 1; j++)
                {
                    sravCount++;
                    if (result[j] > result[j + 1])
                    {
                        Swap(ref result[j], ref result[j + 1]);
                        swapFlag = true;
                        swapCount++;
                    }
                }

                for (var j = result.Length - 2 - i; j > i; j--)
                {
                    sravCount++;
                    if (result[j - 1] > result[j])
                    {
                        Swap(ref result[j - 1], ref result[j]);
                        swapFlag = true;
                        swapCount++;
                    }
                }

                if (!swapFlag)
                {
                    break;
                }
            }

            WriteCounters(sravCount, swapCount);

            return result;
        }

        #endregion

        #region SimpleSorting

        /// <summary>
        /// Сортировка вставками
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        private int[] InsertionSort(in int[] mass)
        {
            var result = CopyArray(mass);

            int sravCount = 0, swapCount = 0;

            for (int i = 1; i < result.Length; i++)
            {
                int cur = result[i];
                int j = i;
                while (j > 0 && cur < result[j - 1])
                {
                    result[j] = result[j - 1];
                    j--;
                    swapCount++;
                    sravCount++;
                }
                result[j] = cur;
            }

            WriteCounters(sravCount, swapCount);

            return result;
        }

        /// <summary>
        /// Сортировка выбором
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        private int[] SelectionSort(in int[] mass)
        {
            var result = CopyArray(mass);

            int sravCount = 0, swapCount = 0;

            int min, temp;

            int length = result.Length;

            for (int i = 0; i < length - 1; i++)
            {
                min = i;

                for (int j = i + 1; j < length; j++)
                {
                    sravCount++;

                    if (result[j] < result[min])
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    temp = result[i];
                    result[i] = result[min];
                    result[min] = temp;

                    swapCount++;
                }
            }

            WriteCounters(sravCount, swapCount);

            return result;
        }

        /// <summary>
        /// Сортировка методом пузырька
        /// </summary>
        /// <returns></returns>
        private int[] SortPuz(in int[] mass)
        {
            int sravCount = 0, swapCount = 0;

            var result = CopyArray(mass);

            for(var n = result.Length; n > 0; n--)
            {
                for(var i = 0; i < n - 1; i++)
                {
                    sravCount++;
                    if(result[i] > result[i + 1])
                    {
                        Swap(ref result[i], ref result[i + 1]);
                        swapCount++;
                    }
                }
            }

            WriteCounters(sravCount, swapCount);

            return result;
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Копирование массива
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        private int[] CopyArray(int[] mass)
        {
            int[] result = new int[mass.Length];

            Array.Copy(mass, result, mass.Length);

            return result;
        }

        /// <summary>
        /// Поменять местами значения
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private void Swap(ref int a, ref int b)
        {
            var c = a;
            a = b;
            b = c;
        }

        /// <summary>
        /// Вывод массива на экран
        /// </summary>
        /// <param name="mass"></param>
        private void WriteMass(int[] mass)
        {
            const int lineLenght = 15;

            for(var i = 0; i < mass.Length; i++)
            {
                if(i % lineLenght == 0)
                {
                    Console.WriteLine();
                }
                Console.Write(mass[i] + "\t");
            }

            Console.WriteLine();
        }

        private void WriteCounters(int sravCount, int swapCount)
        {
            Console.WriteLine($"Srav count - {sravCount}, Swap count - {swapCount}");
        }

        /// <summary>
        /// Инициализация исходно массива
        /// </summary>
        /// <param name="massLenght"></param>
        /// <returns></returns>
        private int[] InitMass(int massLenght)
        {
            var mass = new int[massLenght];

            var rnd = new Random();

            for(var i = 0; i < massLenght; i++)
            {
                mass[i] = rnd.Next(0, 100);
            }

            return mass;
        }

        #endregion

        /// <summary>
        /// Вывод меню на экран
        /// </summary>
        private void WriteWhatWant()
        {
            Console.WriteLine("Что хотите сделать?\n1) Вывод исходного массива\n"
                + "2) Сортировка обменом\n"
                + "3) Сортировка выбором\n"
                + "4) Сортировка вставками\n"
                + "5) Улучшенная сортировка обменом\n"
                + "6) Улучшенная сортировка выборкой\n"
                + "7) Улучшенная сортировка вставками\n"
                + "0) Выход из лабы 'Сортировки'");
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
