using System;

namespace DoublyLinkedList{

    class Node{
        public int Data;
        public Node next;
        public Node prev;

        public Node(int e){
            Data = e;
            next = null;
            prev = null;
        }
    }
    class DoublyLinkedList{

        private Node Head ;
        private Node Tail;
        private int Size;

        public DoublyLinkedList(){
            Head = null;
            Tail = null;
            Size = 0;
        }

        public bool isEmpty() => Size == 0;

        public int Length(){
            return Size;
        }
        
        public void addLast(int e){
            Node newest = new Node(e);
            if(isEmpty()){
                Head = newest;
                Tail = newest;
            }
            Tail.next = newest;
            newest.prev = Tail;
            Tail = newest;
            Size++;
        }

        public void Display(){
            Node p = Head;
            while(p != null){
                Console.Write(p.Data+ "<=>");
                p = p.next;
            }
            Console.WriteLine();
        }

        public void addBegin(int e){
            Node newest = new Node(e);
            if(isEmpty()){
                Head = newest;
                Tail = newest;
            }
            newest.next = Head;
            Head.prev = newest;
            Head = newest;
            Size++;
        }

        public void addAny(int e, int position){
            Node newest = new Node(e);
            Node p = Head;
            int i = 0;
            while(i < position - 1){
                p = p.next;
                i++;
            }
            newest.next = p.next;
            p.next.prev = newest;
            p.next = newest;
            newest.prev = p;
            Size++;
        }

        public int removeFirst(){
            if(isEmpty()){
                Console.WriteLine("List is Empty");
                return -1;
            }
            int element = Head.Data;
            Head = Head.next;
            Head.prev = null;
            Size--;
            return element;
        }

        public int removeLast(){
            if(isEmpty()){
                Console.WriteLine("List is Empty.");
                return -1;
            }
            int element = Tail.Data;
            Tail = Tail.prev;
            Tail.next = null;
            Size--;
            return element;
        }

        public int removeAtAny(int position){
            if(position < 0 || position > Size){
                Console.WriteLine("Invalid Position.");
                return -1;
            }
            Node p = Head;
            int i = 1;
            while(i < position - 1){
                p = p.next;
                i++;
            }
            int element = p.next.Data;
            p.next = p.next.next;
            p.next.prev = p;
            Size--;
            return element;
        }

        public static void Main(){
            Console.WriteLine("Doubly Linked List.");
            DoublyLinkedList d = new DoublyLinkedList();
            d.addLast(1);
            d.addLast(2);
            d.addLast(3);
            d.Display();

            //add element at Beginning
            d.addBegin(0);
            d.Display();

            //Add at Position
            d.addAny(10,2);
            d.Display();

            //remove at first
            Console.WriteLine("Remove at First :" + d.removeFirst());
            d.Display();

            //remove at Last
            Console.WriteLine("Remove at Last :"+ d.removeLast());
            d.Display();

            //Remove at position
            Console.WriteLine("Remove at Position :" + d.removeAtAny(2));
            d.Display();
        }
    }
}