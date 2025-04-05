using System;

namespace Sorting{
    class SortingClass{
        public static void Main(){
            Console.WriteLine("Sorting ...");

            Console.WriteLine("Selection Sort :");
            SelectionSort.MethodCall();

            Console.WriteLine("Insertion Sort :");
            InsertionSort.MethodCall();

            Console.WriteLine("Bubble Sort :");
            BubbleSort.MethodCall();

            Console.WriteLine("Shell Sort :");
            shellsort.MethodCall();

            Console.WriteLine("Merge Sort :");
            MergeSort.MergeEntryPoint();

            Console.WriteLine("Quick Sort :");
            QuickSort.QuickSortEntryMethod();
        }
    }
}