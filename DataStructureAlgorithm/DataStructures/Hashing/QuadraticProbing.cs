using System;

namespace Hashing{
    class QuadraticProbing{
        private int HashTableSize;
        private int[] hashTable;

        public QuadraticProbing(){
            HashTableSize = 10;
            hashTable = new int[HashTableSize];
        }

        private int hashCode(int element){
            return element % HashTableSize;
        }

        private int QProbe(int element){
            int i = hashCode(element);
            int j = 0;
            while(hashTable[(i+(int)Math.Pow(j,2.0))%HashTableSize] != 0){
                j = j+1;
            }
            return (i+(int)Math.Pow(j,2.0)) % HashTableSize;
        }

        public void insert(int element){
            int i = hashCode(element);
            if(hashTable[i] == 0){
                hashTable[i] = element;
            }
            else{
                i = QProbe(element);
                hashTable[i] = element;
            }
        }

        public void Display(){
            for(int i = 0; i<HashTableSize; i++){
                Console.Write(hashTable[i]+",");
            }
            Console.WriteLine();
        }

        public bool search(int key){
            int i = hashCode(key);
            int j = 0;
            while(hashTable[(i+(int)Math.Pow(j,2))%HashTableSize] != key){
                if(hashTable[(i+(int)Math.Pow(j,2))%HashTableSize] == 0){
                    return false;
                }
                j = j+1;
            }
            return true;
        }

        public static void Main(){
            Console.WriteLine("Quadratic Probing collision technique for hash function.");
            QuadraticProbing hash = new QuadraticProbing();
            hash.insert(54);
            hash.insert(78);
            hash.insert(64);
            hash.insert(92);
            hash.insert(34);
            hash.insert(86);
            hash.insert(28);
            hash.Display();

            Console.WriteLine("Search - 92 :"+ hash.search(92));
            Console.WriteLine("Search - 78 :"+ hash.search(78));
            Console.WriteLine("Search - 99 :"+ hash.search(99));
            hash.insert(99);
            hash.Display();
            Console.WriteLine("After insertion - Search - 99 :"+ hash.search(99));
        }
    }
}