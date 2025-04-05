using System;

namespace Sorting{
    class SelectionSort{

        //T(N) - O(n^2) and S(N) - O(1) - Unstable
        public static void selectionSort(int[] array, int size){
            for(int i = 0; i<size-1; i++){
                int position = i;
                for(int j = i+1; j<size; j++){
                    if(array[j] < array[position]){
                        int temp = array[position];
                        array[position] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        public static void Print(int[] array, string mesg){
            Console.WriteLine(mesg);
            Console.WriteLine(string.Join(",",array));
        }

        public static void MethodCall(){
            int[] arr = [23,1,34,22,65,34,234,90,3];
            Print(arr,"Before Sorting :");
            selectionSort(arr,arr.Length);
            Print(arr,"After Sorting :");
        }
    }
}