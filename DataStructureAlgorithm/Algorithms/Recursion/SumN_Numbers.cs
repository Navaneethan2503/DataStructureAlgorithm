using System;

namespace Recursion{
    class SumN_NumbersClass{

        //Using Formula Calculate Sum of N natural Numbers.
        public int Sumn(int n){
            return n * (n + 1) / 2;
        }

        //Iteration Sum of N natural Numbers.
        public int sumIteration(int n){
            int total = default;
            while(n > 0){
                total += n;
                n--;
            }
            return total;
        }

        //Sum of n natural numbers using recursion Functions.
        public int sumRecursion(int n){
            if(n == 1){
                return 1;
            }
            return sumRecursion(n - 1) + n;
        }

        public void CallMethods(){
            Console.WriteLine("Sum Using Formula :"+Sumn(4));
            Console.WriteLine("Sum Using Iteration :"+ sumIteration(4));
            Console.WriteLine("Sum Using Recursive :"+ sumRecursion(4));
        }
    }
}