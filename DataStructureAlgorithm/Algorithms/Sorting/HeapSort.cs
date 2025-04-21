using System;
using HeapArray;
namespace Sorting{
    class HeapSortClass{

        public static void HeapSort(int[] A, int n){
            Heap heap = new Heap();
            for(int i = 0; i<n; i++){
                heap.insert(A[i]);
            }
            int k = n - 1;
            for(int i = 0; i<n; i++){
                A[k] = heap.deleteMax();
                k = k - 1;
            }
        }

        public static void Display(int[] A, int n){
            for(int i = 0; i<n; i++){
                Console.Write(A[i]+",");
            }
            Console.WriteLine();
        }

        public static void Main(){
            Console.WriteLine("Heap Sort");
            int[] a = [63,250,835,947,651,28];
            Console.WriteLine("Original Array: ");
            Display(a, a.Length);
            
            //Sorting Operation
            Console.WriteLine("Sorted Array: ");
            HeapSort(a, a.Length);
            Display(a, a.Length);


        }
    }
}