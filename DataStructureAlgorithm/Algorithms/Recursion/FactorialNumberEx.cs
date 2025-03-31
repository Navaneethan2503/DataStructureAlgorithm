using System;

namespace Recursion{
    class FactorialNumber{

        //Iterative Method
        public int iterativeFactorial(int n){
            int total = 1;
            for(int i = 1; i <= n; i++){
                total *= i;
            }
            return total;
        }

        //Recursive MEthod
        public int recursiveFactorial(int n){
            if(n == 0){
                return 1;
            }
            return recursiveFactorial(n - 1) * n;
        }

        public void callRecursiveFactorial(){
            Console.WriteLine("Iterative Factorial :"+ iterativeFactorial(5));
            Console.WriteLine("Recursion Factorial :"+ recursiveFactorial(5));
        }
    }
}