using System;
using System.Linq;

namespace AppSort
{
    public static class Sorter<T>
    {
        private static Func<T, T, bool> _compare;

        public static T[] HeapSort(T[] array, Func<T, T, bool> compare, Func<T, bool> isComlete = null)
        {
            _compare = compare;

            if (isComlete != null) array = array.Where(isComlete).ToArray();

            var n = array.Length;

            for (var i = n / 2 - 1; i >= 0; i--)
                Heapify(array, n, i);

            for (var i = n - 1; i >= 0; i--)
            {
                Swap(ref array[0], ref array[i]);

                Heapify(array, i, 0);
            }

            return array;
        }

        public static T[] QuickSort(T[] array, Func<T, T, bool> compare, Func<T, bool> isComlete = null)
        {
            _compare = compare;
            if (isComlete != null) array = array.Where(isComlete).ToArray();

            return QuickSort(array, 0, array.Length - 1);
        }

        private static void Heapify(T[] arr, int n, int i)
        {
            var largest = i;
            var l = 2 * i + 1;
            var r = 2 * i + 2;

            if (l < n && _compare(arr[l], arr[largest]))
                largest = l;

            if (r < n && _compare(arr[r], arr[largest]))
                largest = r;

            if (largest == i) return;

            Swap(ref arr[i], ref arr[largest]);

            Heapify(arr, n, largest);
        }

        private static int Partition(T[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
                if (_compare(array[i], array[maxIndex]))
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }

        private static T[] QuickSort(T[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex) return array;

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        private static void Swap(ref T x, ref T y)
        {
            (x, y) = (y, x);
        }
    }
}