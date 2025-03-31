using System;

namespace Recursion{
    class RecursionClass{

        public static void Main(){
            Console.WriteLine("Recursion Function");

            RecursionVsIterative obj = new RecursionVsIterative();
            obj.EntryPointMethod();

            Console.WriteLine("Type Of Rcursion");
            TypesOfRecursion recursionObj = new TypesOfRecursion();
            Console.WriteLine("Tail Recursion :");
            recursionObj.tailRecursion(4);

            Console.WriteLine("Head Recursion :");
            recursionObj.headRecursion(4);

            Console.WriteLine("Tree Recursion :");
            recursionObj.treeRecursion(3);

            Console.WriteLine("Examples :");
            SumN_NumbersClass sum = new SumN_NumbersClass();
            sum.CallMethods();

            FactorialNumber facObj = new FactorialNumber();
            facObj.callRecursiveFactorial();
        }
    }
}