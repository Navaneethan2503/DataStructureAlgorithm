using System;

namespace Sorting{
    class CountSortClass{

        public static void CountSort(int[] array, int size){
            int max = array.Max();
            int[] carray = new int[max+1];
            for(int a = 0; a<array.Length; a++){
                carray[array[a]] = carray[array[a]] + 1;
            }
            int i = 0 , j = 0;
            while(i<max+1){
                if(carray[i]>0){
                    array[j++] = i;
                    carray[i] = carray[i] - 1;
                }
                else{
                    i = i + 1;
                }
            }
        }
        public static void Main(){
            Console.WriteLine("Count Sorting Algorithm.");
            int[] a = [63,250,835,947,651,28];
            Console.WriteLine("Original Unsorted Array : "+ string.Join(',',a));
            CountSort(a, a.Length);
            Console.WriteLine("Sorted Array : "+ string.Join(',',a));

        }
    }
}