using System;

namespace Recursion{
    class TypesOfRecursion{

        //Tail Recursion
        public void tailRecursion(int n){
            if(n > 0){
                int k = n*n;
                Console.WriteLine(k);
                tailRecursion(n-1);
            }
        }

        //Head Recursion
        public void headRecursion(int n){
            if(n > 0){
                headRecursion(n-1);
                int k = n*n;
                Console.WriteLine(k);
            }
        }

        //Tree Recursion
        public void treeRecursion(int n){
            if(n > 0){
                treeRecursion(n - 1);
                int k = n*n;
                Console.WriteLine(k);
                treeRecursion(n - 1);
            }
        }

    }
}