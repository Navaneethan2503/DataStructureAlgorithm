using System;

namespace Sorting{
    class shellsort{

        //T(N) - O(n log N) and 
        public static void shellSort(int[] arr, int size){
            int gap = size / 2;
            while(gap > 0){
                int i = gap;
                while(i<size){
                    int gValue = arr[i];
                    int j = i - gap;
                    while(j >= 0 && arr[j]> gValue){
                        arr[j+gap] = arr[j];
                        j = j - gap;
                    }
                    arr[j+gap] = gValue; 
                    i++;
                }
                gap = gap / 2;
            }
        }

        public static void Print(int[] array, string mesg){
            Console.WriteLine(mesg);
            Console.WriteLine(string.Join(",",array));
        }

        public static void MethodCall(){
            int[] arr = [23,1,34,22,65,34,234,90,3];
            Print(arr,"Before Sorting :");
            shellSort(arr,arr.Length);
            Print(arr,"After Sorting :");
        }
    }
}