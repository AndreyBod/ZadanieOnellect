using System.Collections.Generic;
using System.Linq;

namespace TestovoeZadanieOnellect
{
    static class SortAlgorithms
    {
        /// <summary>
        /// Количество доступных видов сортировки
        /// </summary>
        public static int CountAlgorithms = 4;
        /// <summary>
        /// Сортировка методом "пузырька"
        /// </summary>
        /// <param name="numbers">Список чисел</param>
        public static void Bubble(List<int> numbers)
        {
            int count = numbers.Count();
            for (int i = 0; i< count; i++)
            {
                for (int j = 0; j < count-i-1; j++)
                {
                    if (numbers[j]>numbers[j+1])
                    {
                        Swap(numbers, j, j+1);
                    }
                }
            }
        }
        /// <summary>
        /// Сортировка медодом "Выбора"
        /// </summary>
        /// <param name="numbers">Список чисел</param>
        public static void Choice(List<int> numbers)
        {
            int count = numbers.Count();
            for (int i = 0; i< count; i++)
            {
                int indexMinElement = i;
                for (int j = i + 1; j < count; j++)
                {
                    if (numbers[j] < numbers[indexMinElement])
                    {
                        indexMinElement = j;
                    }
                }

                if (indexMinElement != i)
                {
                    Swap(numbers, i, indexMinElement);
                }

            }
        }
        /// <summary>
        /// Шейкерная сортировка
        /// </summary>
        /// <param name="numbers">Список чисел</param>
        public static void Shaiker(List<int> numbers)
        {
            int left = 0;
            int right = numbers.Count-1;
            while (left<=right)
            {
                for (int i = 0; i < right; i++)
                {
                    if (numbers[i]> numbers[i+1])
                    {
                        Swap(numbers, i, i+1);
                    }
                }
                right--;
                for (int i = right; i> left; i--)
                {
                    if (numbers[i]< numbers[i-1])
                    {
                        Swap(numbers, i, i-1);
                    }
                }
                left++;
            }
        }
        /// <summary>
        /// быстрая сортировка
        /// </summary>
        /// <param name="array">список чисел</param>
        /// <param name="minIndex">индекс первого элемента интервала</param>
        /// <param name="maxIndex">индекс последнего элемента интервала</param>
        public static void Quick(List<int> array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return;
            }

            int pivotIndex = Partition(array, minIndex, maxIndex);
            Quick(array, minIndex, pivotIndex - 1);
            Quick(array, pivotIndex + 1, maxIndex);

            
        }
        /// <summary>
        /// Выбор опорного элемента
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="minIndex"></param>
        /// <param name="maxIndex"></param>
        /// <returns></returns>
        static int Partition(List<int> numbers, int minIndex, int maxIndex)
        {
            int pivot = minIndex - 1;
            for (int i = minIndex; i < maxIndex; i++)
            {
                if (numbers[i] < numbers[maxIndex])
                {
                    pivot++;
                    Swap(numbers, pivot, i);
                }
            }
           
            pivot++;
            Swap(numbers, pivot, maxIndex);
            return pivot;
        }

        /// <summary>
        /// Меняет 2 элемента местами
        /// </summary>
        /// <param name="num"> список чисел</param>
        /// <param name="x">индекс первого элемента</param>
        /// <param name="y">индекс 2 элемента</param>
        static void Swap(List<int> num, int x, int y)
        {
            if (x < num.Count && x >= 0 && y < num.Count && y >= 0)
            {
                int temp = num[x];
                num[x] = num[y];
                num[y] = temp;
            }
            
        }















    }
}
