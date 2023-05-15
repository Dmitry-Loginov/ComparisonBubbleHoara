﻿using System;
using System.Diagnostics;

namespace ComparisonSorting
{
    class Program
    {
        //----------------- Быстрая сортировка ------------------------------//
        static int FindPivotIndex(int[] nums, int l, int r)
        {
            int temp;
            int end_pivot_index = l - 1;
            // Находим место pivot
            while (l < r)
            {
                if (nums[l] < nums[r])
                {
                    end_pivot_index++;
                    // Выполняем обмен
                    temp = nums[l];
                    nums[l] = nums[end_pivot_index];
                    nums[end_pivot_index] = temp;
                }
                l++;
            }

            // Ставим pivot на место
            end_pivot_index++;
            temp = nums[end_pivot_index];
            nums[end_pivot_index] = nums[r];
            nums[r] = temp;

            return end_pivot_index;
        }

        static int[] QuickSort(int[] nums, int l, int r)
        {
            // Остановка рекурсии, когда больше нечего сортировать
            if (l >= r)
                return nums;

            // Ставим pivot на место
            int pivot_index = FindPivotIndex(nums, l, r);
            nums = QuickSort(nums, l, pivot_index - 1); // Сортируем левую часть подмассива
            nums = QuickSort(nums, pivot_index + 1, r); // Сортируем правую часть подмассива

            return nums;
        }
        //----------------- Пузырьковая ------------------------------//
        static int[] BubbleSort(int[] nums)
        {
            // Объявление временной переменной
            int temp;
            // Перебор всего массива и сравнение ближайших пар
            for (int i = 0; i < nums.Length; i++)
            {
                for (int k = 0; k < nums.Length - 1; k++)
                {
                    // Если ближайшие пары разные - меняем местами 
                    if (nums[k + 1] < nums[k])
                    {
                        temp = nums[k + 1];
                        nums[k + 1] = nums[k];
                        nums[k] = temp;
                    }
                }
            }
            return nums;
        }

        static void Main(string[] args)
        {
            // Создаие объекта, засекающего время и объектов массивов
            Stopwatch time_meter = new Stopwatch();
            int[] test_nums_a;
            int[] test_nums_b;

            // Заполнение массивов
            StartedFullArrays(out test_nums_a, out test_nums_b);

            // Сортировки массивов
            long spentHoara = MarkTheTimeHoara(ref test_nums_a, time_meter);
            long spentBubble = MarkTheTimeBubble(ref test_nums_b, time_meter);

            // Вывод результатов быстрой сортировки
            Console.WriteLine("Упорядоченный массив(сортировка хоара): {0}", string.Join(", ", test_nums_a));
            Console.WriteLine("Времени потратили (в милисекундах): {0}", spentHoara);

            // Вывод результатов сортировки слиянием
            Console.WriteLine("Упорядоченный массив(сортировка пузырьком): {0}", string.Join(", ", test_nums_b));
            Console.WriteLine("Времени потратили (в милисекундах): {0}", spentBubble);

            // "Заморозка" вывода
            Console.ReadKey();
        }

        // Первоначальное заполнение элементов массива
        static void StartedFullArrays(out int[] first_array, out int[] second_array)
        {
            // Иинициалищация размера массива
            Console.Write("Введите размер массива N = ");
            int len = Convert.ToInt32(Console.ReadLine());

            // Создание массивов введенных размеров
            first_array = new int[len];
            second_array = new int[len];
            int num;
            Random rnd = new Random();
            // Инициализация массивов случайными числами
            for (var i = 0; i < first_array.Length; i++)
            {
                num = rnd.Next(0, 11);
                first_array[i] = num;
                second_array[i] = num;
            }
        }

        // Метод, сортирующий массив и засекающий время, потраченное на сортировку Хоара
        static long MarkTheTimeHoara(ref int[] nums, Stopwatch time_meter)
        {

            time_meter.Start();
            // Выполнение сортировки
            nums = QuickSort(nums, 0, nums.Length - 1);
            time_meter.Stop();

            return time_meter.ElapsedMilliseconds;
        }

        // Метод, сортирующий массив и засекающий время, потраченное на сортировку пузырьком
        static long MarkTheTimeBubble(ref int[] nums, Stopwatch time_meter)
        {

            time_meter.Start();
            // Выполнение сортировки
            nums = BubbleSort(nums);
            time_meter.Stop();

            return time_meter.ElapsedMilliseconds;
        }
    }
}