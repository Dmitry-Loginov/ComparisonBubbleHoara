using System;
using System.Diagnostics;

namespace ComparisonBubbleHoara
{
    class Program
    {
        //----------------- Быстрая сортировка ------------------------------//
        static int FindPivotIndex(ref int[] nums, int l, int r)
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

        static void QuickSort(ref int[] nums, int l, int r)
        {
            // Остановка рекурсии, когда больше нечего сортировать
            if (l >= r)
                return;

            // Ставим pivot на место
            int pivot_index = FindPivotIndex(ref nums, l, r);
            QuickSort(ref nums, l, pivot_index - 1); // Сортируем левую часть подмассива
            QuickSort(ref nums, pivot_index + 1, r); // Сортируем правую часть подмассива
        }
        //----------------- Пузырьковая ------------------------------//
        static void BubbleSort(ref int[] nums)
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
            string test_len = Console.ReadLine();
            while (!int.TryParse(test_len, out var _number))
            {
                Console.WriteLine("Введено некорректное значение. Пожалуйста, введите коррентное целое число");
                test_len = Console.ReadLine();
            }
            int len = int.Parse(test_len);

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
            QuickSort(ref nums, 0, nums.Length - 1);
            time_meter.Stop();

            return time_meter.ElapsedMilliseconds;
        }

        // Метод, сортирующий массив и засекающий время, потраченное на сортировку пузырьком
        static long MarkTheTimeBubble(ref int[] nums, Stopwatch time_meter)
        {

            time_meter.Start();
            // Выполнение сортировки
            BubbleSort(ref nums);
            time_meter.Stop();

            return time_meter.ElapsedMilliseconds;
        }
    }
}
