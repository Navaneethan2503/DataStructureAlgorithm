using System;

namespace CircularLinkedList{
    class Node{
        public int Data;
        public Node next;

        public Node(int element){
            Data = element;
            next = null;
        }
    }

    class CircularLinkedList{
        private Node Head ;
        private Node Tail;
        private int Size;

        public CircularLinkedList(){
            Head = null;
            Tail = null;
            Size = 0;
        }

        public bool isEmpty() => Size == 0;

        public int Length(){
            return Size;
        }

        public void Display(){
            Node p = Head;
            int i = 0;
            while(i < Length()){
                Console.Write(p.Data+"->");
                p = p.next;
                i++;
            }
            Console.WriteLine();
        }

        public void addLast(int element){
            Node newest = new Node(element);
            if(isEmpty()){
                Head = newest;
                newest.next = newest;
            }
            else{
                newest.next = Tail.next;
                Tail.next = newest;
            }
            Tail = newest;
            Size++;
        }

        public void addFirst(int element){
            Node newest = new Node(element);
            if(isEmpty()){
                Head = newest;
                newest.next = newest;
                Tail = newest;
            }
            else{
                newest.next = Head;
                Tail.next = newest;
                Head = newest;
            }
            Size++;
        }

        public void addAny(int element, int position){
            if(position < 0 || position > Size){
                Console.WriteLine("Invalid Position");
                return;
            }
            Node newest = new Node(element);
            Node p = Head;
            int i = 1;
            while(i < position-1){
                p = p.next;
                i++;
            }
            newest.next = p.next;
            p.next = newest;
            Size++;
        }


        public int removeFirst(){
            if(isEmpty()){
                Console.WriteLine("Circular List is Empty.");
                return -1;
            }
            int e = Head.Data;
            Tail.next = Head.next;
            Head = Head.next;
            if(isEmpty()){
                Tail = null;
                Head = null;
            }
            Size--;
            return e;
        }

        public int removeEnd(){
            if(isEmpty()){
                Console.WriteLine("Circular Linked List is Empty.");
                return -1;
            }
            Node p = Head;
            int i = 0;
            while(i < Length() - 1){
                p = p.next;
                i++;
            }
            Tail = p;
            p = p.next;
            int element = p.Data;
            Tail.next = Head;
            Size--;
            return element;
        }

        public int removeAny(int position){
            Node p = Head;
            int i = 0;
            while(i < position -1){
                p = p.next;
                i++;
            }
            int element = p.next.Data;
            p.next = p.next.next;
            Size--;
            return element;
        }


        public static void Main(){
            Console.WriteLine("Circular Linked List !...");
            CircularLinkedList c = new CircularLinkedList();
            c.addLast(1);
            c.addLast(2);
            c.addLast(3);
            c.Display();

            //Add First
            c.addFirst(0);
            c.Display();

            //Add any
            c.addAny(20,2);
            c.Display();

            //remove at first
            Console.WriteLine("Removed Element is :"+c.removeFirst());
            c.Display();

            //Remove at End
            Console.WriteLine("Remove at End is : "+ c.removeEnd());
            c.Display();

            //Remove Any
            Console.WriteLine("Remove any at Position is :"+ c.removeAny(1));
            c.Display();
        }
    }
}