using System;

namespace Sorting{
    class InsertionSort{

        //T(N) - O(n^2) and S(N) - O(1) - Stable Sort
        public static void insertionSort(int[] arr, int size){
            for(int i = 1; i < size; i++){
                int temp = arr[i];
                int position = i;
                while(position > 0 && arr[position-1]>temp){
                    arr[position] = arr[position - 1];
                    position = position - 1;
                }
                arr[position] = temp;
            }
        }

        public static void Print(int[] array, string mesg){
            Console.WriteLine(mesg);
            Console.WriteLine(string.Join(",",array));
        }

        public static void MethodCall(){
            int[] arr = [23,1,34,22,65,34,234,90,3];
            Print(arr,"Before Sorting :");
            insertionSort(arr,arr.Length);
            Print(arr,"After Sorting :");
        }
    }
}