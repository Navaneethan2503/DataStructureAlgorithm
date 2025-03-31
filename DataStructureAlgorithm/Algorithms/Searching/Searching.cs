using System;

namespace Searching{
    class SearchingClass{
        public static void Main(){
            Console.WriteLine("Search Algorithm :");

            Console.WriteLine("Linear Search Algorithm :");
            LinearSearch linearObj = new LinearSearch();
            int[] array = [23,1,54,92,12,64,2];
            int result = linearObj.linearSearch(array, array.Length, 12);
            result = linearObj.linearSearch(array, array.Length, 100);

            result = linearObj.linearRecursiveSearch(array,0,122);
            if(result > 0){
                Console.WriteLine("Key is Found :"+ result);
            }
            else{
                Console.WriteLine("Key is not Found.");
            }

            Console.Clear();
            BinarySearch.CallMethod();

        }
    }
}