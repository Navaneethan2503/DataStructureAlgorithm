using System;

namespace Sorting{
    class QuickSort{

        //T(N) Worst Case - O(n^2), Best and Avergae Case - O(n * log n) 
        //S(N) - O(log N)
        public static void quickSort(int[] A, int left, int right){
            if(left < right){
                int partition = Partition(A,left,right);
                quickSort(A,left,partition-1);
                quickSort(A,partition+1,right);
            }
        }


        public static int Partition(int[] A, int low, int high){
            int pivot = low;
            int i = low + 1;
            int j = high;
            do{
                while(i<=j && A[i]<=A[pivot]){
                    i++;
                }
                while(i<=j && A[j] > A[pivot]){
                    j--;
                }
                if(i <= j){
                    swap(A,i,j);
                }
                
            }
            while(i<j);
            swap(A,j,pivot);
            return j;
        }

        public static void swap(int[] A, int i, int j){
            int temp = A[i];
            A[i] = A[j];
            A[j] = temp;
        }

        public static void Print(int[] array, string mesg){
            Console.WriteLine(mesg);
            Console.WriteLine(string.Join(",",array));
        }


        public static void QuickSortEntryMethod(){
            Console.WriteLine("Quick Sort ..");
            int[] arr = [23,1,34,22,65,34,234,90,3];
            Print(arr,"Before Sorting :");
            quickSort(arr,0,arr.Length-1);
            Print(arr,"After Sorting :");
        }
    }
}