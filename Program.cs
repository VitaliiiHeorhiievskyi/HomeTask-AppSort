using System;

namespace AppSort
{
    internal static class Program
    {
        private static void Main()
        {
            User[] arr =
            {
                new("Vlad", 12, 43),
                new("Vitalii", 11, 60),
                new("Oleg", 88, 65),
                new("Bodya", 34, 23),
                new("Vanya", 64, 77)
            };

            var arrSortByName = Sorter<User>.QuickSort(arr,
                (x1, x2) => string.Compare(x1.Name, x2.Name, StringComparison.Ordinal) < 0); //SortByName QuickSort
            Console.WriteLine("Sort by name:");
            foreach (var item in arrSortByName) Console.WriteLine(item);

            var arrSortByAge = Sorter<User>.HeapSort(arr, (x1, x2) => x1.Age > x2.Age); //SortByAge   HeapSort
            Console.WriteLine("\nSort by age:");
            foreach (var item in arrSortByAge) Console.WriteLine(item);

            var arrSortByWeight =
                Sorter<User>.HeapSort(arr, (x1, x2) => x1.Weight > x2.Weight,
                    x1 => x1.Weight > 50); //SortByWeight; Weight>50
            Console.WriteLine("\nSort by weight:");
            foreach (var item in arrSortByWeight) Console.WriteLine(item);
        }
    }
}