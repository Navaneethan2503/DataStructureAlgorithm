using System;

namespace Recursion{
    class RecursionVsIterative{
        
        //Iterative Function - T(N) = O(N)
        public void calculateIterative(int n){
            while(n > 0){
                int k = n;
                Console.WriteLine(k);
                n = n - 1;
            }
        }

        //Recursion Function
        public void calculateRecursion(int n){
            if(n>0){
                int k = n;
                Console.WriteLine(k);
                calculateRecursion(n-1);
            }
        }

        public void EntryPointMethod(){
            RecursionVsIterative obj = new RecursionVsIterative();
            obj.calculateRecursion(4);
        }
    }
}