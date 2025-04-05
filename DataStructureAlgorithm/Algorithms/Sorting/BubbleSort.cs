using System;

namespace Sorting{
    class BubbleSort{
        
        //T(N) - O(N^2) and S(N) - O(1) - Stable Sort
        public static void bubbleSort(int[] arr, int size){
            for(int pass = size - 1; pass>=0; pass--){
                for(int j = 0; j<pass; j++){
                    if(arr[j]>arr[j+1]){
                        int temp = arr[j];
                        arr[j] = arr[j+1];
                        arr[j+1] = temp;
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
            bubbleSort(arr,arr.Length);
            Print(arr,"After Sorting :");
        }
    }
}