using System;

namespace Searching{
    class BinarySearch{

        //Binary Search using Iterative - T(N) - O(log n) and S(N) - O(1)
        public int binarySearch(int[] array, int size, int key){
            int left = 0;
            int right = size - 1;
            while(left < right){
                int mid = (left + right)/2;
                if(array[mid] == key){
                    return mid;
                }
                else if(key < array[mid]){
                    right = mid - 1;
                }
                else if(key > array[mid]){
                    left = mid + 1;
                }
            }
            return -1;
        }

        public int binarySearchRecursive(int[] array, int key, int left, int right){
            if(left > right){
                return -1;
            }
            else{
                
                int mid = (left + right) / 2;
                if(key == array[mid]){
                    return mid;
                }
                else if(key < array[mid]){
                    return binarySearchRecursive(array, key, left, mid - 1);
                }
                else if(key > array[mid]){
                    return binarySearchRecursive(array, key, mid + 1, right);
                }
            }
            return -1;
        }

        public static void CallMethod(){
            Console.WriteLine("Binary Search :");
            BinarySearch obj = new BinarySearch();
            int[] array = [10,20,25,34,47,56,69,71,89];
            //int result = obj.binarySearch(array, array.Length, 234);

            int result = obj.binarySearchRecursive(array, 56, 0, array.Length-1);
            Console.WriteLine("Result is :"+result);
            if(result >= 0){
                Console.WriteLine("Key is Found at Position :"+ (result + 1));
            }
            else{
                Console.WriteLine("Key is not Found.");
            }
        }
    }
}