using System;

namespace Stack_LinkedList{

    class Node{
        public int Data;
        public Node next;

        public Node(int d){
            Data = d;
            next = null;
        }
    }
    class Stack_LinkedList{

        private Node Top;

        //private Node Tail;

        private int size;

        public Stack_LinkedList(){
            Top = null;

            //Tail = null;

            size = 0;
        }

        public bool isEmpty(){
            return Top == null;
        }

        public void Display(){
            Node p = Top;
            while(p != null){
                Console.Write(p.Data+"->");
                p = p.next;
            }
            Console.WriteLine();
        }

        public int Length(){
            return size;
        }

        public void push(int e){
            Node newest = new Node(e);
            if(isEmpty()){
                Top = newest;
                //Tail = newest;
            }
            else{
                newest.next = Top;
                Top = newest;
            }
            size++;
        }

        public int pop(){
            if(isEmpty()){
                Console.WriteLine("Stack is Empty.");
                return -1;
            }
            int element = Top.Data;
            Top = Top.next;
            size--;
            return element;
        }

        public int peek(){
            if(isEmpty()){
                Console.WriteLine("Stack is Empty.");
                return -1;
            }
            return Top.Data;
        }



        public static void Main(){
            Console.WriteLine("Stack Using Linked List.");
            Stack_LinkedList s = new Stack_LinkedList();
            s.push(1);
            s.push(2);
            s.push(3);
            s.push(4);
            s.Display();

            //Pop
            Console.WriteLine("Pop :"+ s.pop());
            s.Display();

            //peek
            Console.WriteLine("peek : "+ s.peek());

            s.push(4);
            s.push(5);
            s.Display();

            Console.WriteLine("Peek :"+ s.peek());
            Console.WriteLine("pop :"+ s.pop());
            s.Display();
        }
    }
}