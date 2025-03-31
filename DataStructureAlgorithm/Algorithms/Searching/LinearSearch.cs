using System;

namespace Searching{
    class LinearSearch{

        //Linear Search - T(N) = O(N) and S(N) - O(1)
        public int linearSearch(int[] array, int size, int key){
            int index = 0;
            while(index < size){
                if(array[index] == key){
                    return index;
                }
                index++;
            }
            return -1;
        }

        //Linear Search Using Recursive Function - T(n)-O(n) and S(n) - O(1)
        public int linearRecursiveSearch(int[] array, int index, int key){
            if(array[index] == key){
                return index;
            }
            if(index +1 >= array.Length){
                return -1;
            }
            return linearRecursiveSearch(array,index+1,key);
            
        }
    }
}