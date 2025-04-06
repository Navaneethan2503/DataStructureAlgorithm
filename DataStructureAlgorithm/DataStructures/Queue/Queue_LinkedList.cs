using System;

namespace Queue{
    class Node{
        public int Data;

        public Node next;

        public Node(int element){
            Data = element;
            next = null;
        }
    }


    class Queue_LinkedList{

        private Node Front;
        private Node Rear;
        private int size;

        public Queue_LinkedList(){
            Front = null;
            Rear = null;
            size = 0;
        }

        public bool isEmpty(){
            return size == 0;
        }

        public int Length(){
            return size;
        }

        public void Display(){
            Node p = Front;
            while(p != null){
                Console.Write(p.Data+"-");
                p = p.next;
            }
            Console.WriteLine();
        }

        public void enqueue(int element){
            Node newest = new Node(element);

            if(isEmpty()){
                Front = newest;
            }
            else{
                Rear.next = newest;
            }
            Rear = newest;
            size++;
        }

        public int dequeue(){
            if(isEmpty()){
                Console.WriteLine("Queue is Empty.");
                return -1;
            }
            int element = Front.Data;
            Front = Front.next;
            size--;
            if(isEmpty()){
                Rear = null;
            }
            return element;
        }

        public int First(){
            if(isEmpty()){
                Console.WriteLine("Queue is Empty.");
                return -1;
            }
            return Front.Data;
        }


        public static void Main(){
            Console.WriteLine("Queue using Linked List ...");
            Queue_LinkedList q = new Queue_LinkedList();
            q.enqueue(1);
            q.enqueue(2);
            q.enqueue(3);
            q.Display();
            Console.WriteLine("Lenght :"+ q.Length());

            //Dequeue
            Console.WriteLine("Dequeue is :"+ q.dequeue());
            q.Display();
            Console.WriteLine("Lenght :"+ q.Length());

            //Peek
            Console.WriteLine("First :"+ q.First());
        }
    }
}