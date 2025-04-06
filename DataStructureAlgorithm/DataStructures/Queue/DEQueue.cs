using System;
//DEQueue is same as Linked List.
namespace Queue{
    class DEQueue{
        private Node Front ;
        private Node Tail;
        private int Size;

        public DEQueue(){
            Front = null;
            Tail = null;
            Size = 0;
        }

        public void addElementAtLast(int element){
            Node newest = new Node(element);
            if(isEmpty()){
                Front = newest;
            }
            else{
                Tail.next = newest;
            }
            Tail = newest;
            Size++;
        }

        public bool isEmpty() => Size == 0;

        public int Length(){
            return Size;
        }

        public void DisplayDEQueue(){
            Node p = Front;
            while(p != null){
                Console.Write(p.Data+"----->");
                p = p.next;
            }
            Console.WriteLine();
        }

        public void AddElementAtBegining(int element){
            Node newest = new Node(element);
            if(isEmpty()){
                Front = newest;
                Tail = newest;
            }
            else{
                newest.next = Front;
                Front = newest;
            }
            Size++;
        }

        public void addElementBetweenDEQueue(int element, int position){
            if(position < 0 || position > Size ){
                Console.WriteLine("Invalid Position.");
                return;
            }

            Node newest = new Node(element);
            Node p = Front;
            int count = 1;
            while(count < position -1){
                p = p.next;
                count++;
            }
            newest.next = p.next;
            p.next = newest;
            Size++;
        }

        public int removeAtBegin(){
            if(isEmpty()){
                Console.WriteLine("List is Empty");
                return -1;
            }
            int e = Front.Data;
            Front = Front.next;
            if(isEmpty()){
                Tail = null;
            }
            Size--;
            return e;
        }


        //Remove at End of Linked List
        public int removeAtEnd(){
            int element = 0;
            if(isEmpty()){
                Console.WriteLine("List is Empty.");
                return -1;
            }
            Node p = Front;
            int i = 1;
            while(i < Size-1){
                p = p.next;
                i++;
            }
            Tail = p;
            p = p.next;
            element = p.Data;
            Tail.next = null;
            Size--;
            return element;
        }

        //Remove at any Position
        public int removeAtposition(int position){
            int element = 0;
            if(position < 0 && position > Size){
                Console.WriteLine("Invalid Position.");
                return -1;
            }
            Node p = Front;
            int i = 1;
            while(i < position -1){
                p = p.next;
                i++;
            }
            element = p.next.Data;
            p.next = p.next.next;
            Size--;
            return element;
        }

        public int search(int key){
            Node p = Front;
            int i = 0;
            while(p != null){
                if(p.Data == key){
                    Console.WriteLine("Element Found.");
                    return i;
                }
                p = p.next;
                i++;
            }
            return -1;
        }

        public static void Main(){
            DEQueue l = new DEQueue();
            l.addElementAtLast(1);
            l.addElementAtLast(2);
            l.addElementAtLast(3);
            l.addElementAtLast(4);
            l.DisplayDEQueue();
            Console.WriteLine("Size of Linked List IS :"+ l.Length());
            Console.WriteLine("Insert Element at Beginding :");
            l.AddElementAtBegining(10);
            l.DisplayDEQueue();
            Console.WriteLine("Size of Linked List IS :"+ l.Length());

            //Insert element at position between list
            Console.WriteLine("Insert Element at Between Linked List :");
            l.addElementBetweenDEQueue(20,2);
            l.DisplayDEQueue();
            Console.WriteLine("Size of Linked List IS :"+ l.Length());

            //Remove at beginning
            Console.WriteLine("Remove at First :"+l.removeAtBegin());
            l.DisplayDEQueue();
            Console.WriteLine("Size of Linked List IS :"+ l.Length());

            //Remove at End
            Console.WriteLine("Remove at End :"+ l.removeAtEnd());
            l.DisplayDEQueue();
            Console.WriteLine("Size of Linked List IS :"+ l.Length());

            //Remove at Position
            Console.WriteLine("Remove at Position :"+ l.removeAtposition(3));
            l.DisplayDEQueue();
            Console.WriteLine("Size of Linked List IS :"+ l.Length());
            Console.WriteLine("Remove at Position :"+ l.removeAtposition(3));
            l.DisplayDEQueue();
            Console.WriteLine("Size of Linked List IS :"+ l.Length());

            //Search 
            Console.WriteLine("Seach Element :");
            l.AddElementAtBegining(5);
            l.AddElementAtBegining(6);
            l.DisplayDEQueue();
            Console.WriteLine("Size of Linked List IS :"+ l.Length());
            Console.WriteLine("Search Element 20 :"+ l.search(20));
            Console.WriteLine("Search Element 5 :"+ l.search(5));
            Console.WriteLine("Search Element 100 :"+ l.search(100));
        }
    }
}
