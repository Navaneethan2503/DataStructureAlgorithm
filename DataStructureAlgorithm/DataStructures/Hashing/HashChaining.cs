using System;
using LinkedList;

/**
**/
namespace Hashing{
    class HashingChaining{

        int HashTableSize;
        LinkedList.LinkedList[] hashTable;

        public HashingChaining(){
            HashTableSize = 10;
            hashTable = new LinkedList.LinkedList[HashTableSize];
            for(int i = 0; i<HashTableSize; i++){
                hashTable[i] = new LinkedList.LinkedList();
            }
        }
        
        public int HashCode(int element){
            return element % HashTableSize;
        }

        public void insert(int element){
            int hashCode = HashCode(element);
            hashTable[hashCode].insertsorted(element);
        }

        public bool search(int key){
            int hashCode = HashCode(key);
            return hashTable[hashCode].search(key) != -1;
        }

        public void Display(){
            for(int i = 0; i<HashTableSize; i++){
                hashTable[i].DisplayLinkedList();
            }
            Console.WriteLine();
        }

        public static void Main(){
            Console.WriteLine("Hashing Chaining Collision handling Schemes.");
            HashingChaining hashTable = new HashingChaining();
            hashTable.insert(54);
            hashTable.insert(78);
            hashTable.insert(64);
            hashTable.insert(92);
            hashTable.insert(34);
            hashTable.insert(86);
            hashTable.insert(28);
            hashTable.Display();

            Console.WriteLine("Search  - 34:" +hashTable.search(34));
            Console.WriteLine("Search  - 70:" +hashTable.search(70));

        }
    }
}