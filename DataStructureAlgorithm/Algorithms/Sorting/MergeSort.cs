using System;
/**
**/
namespace Sorting{
    class MergeSort{

        //Over all Total Complexity is T(N) - O(n * log n);

        //T(N) - log n 
        public static void mergeSort(int[] A, int left, int right){
            if(left < right){
                int mid = (right+left) / 2;
                //recursively divide left half array till reaches 1 element.
                mergeSort(A,left,mid);
                //recursively divide right half array till reaches 1 element. 
                mergeSort(A,mid+1,right);
                //start merging only all elements divided till 1 element and start merging elements recursively.
                merge(A,left,mid,right);
            }
        }

        //T(N) for Merge is O(N);
        public static void merge(int[] A, int left, int mid, int right){
            int i = left;
            int j = mid + 1;
            int k = left;
            int[] B = new int[right+1];
            while(i<=mid && j<=right){
                if(A[i]<A[j]){
                    B[k] = A[i];
                    i++;
                }
                else{
                    B[k] = A[j];
                    j++;
                }
                k++;
            }
            //if any of the array have excess element then loop each array and insert into B.
            while(i<=mid){
                B[k] = A[i];
                i++;
                k++;
            }
            while(j<=right){
                B[k] = A[j];
                j++;
                k++;
            }

            //Copy the B array to A;
            for(int x = left; x<=right; x++){
                A[x] = B[x];
            }
        }

        public static void Print(int[] array, string mesg){
            Console.WriteLine(mesg);
            Console.WriteLine(string.Join(",",array));
        }

        public static void MethodCall(){
            int[] arr = [3,5,8,9,6,2];
            Print(arr,"Before Sorting :");
            //Length Count Should be in Zero Based Index. 
            mergeSort(arr,0 , 5);
            Print(arr,"After Sorting :");
        }

        
        public static void MergeEntryPoint(){
            Console.WriteLine("Merge Sort ...");
            MethodCall();
        }
    }
}