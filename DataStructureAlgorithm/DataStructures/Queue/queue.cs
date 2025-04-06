using System;

namespace Queue{
    class QueueArray{

        private int[] queue;
        private int front;
        private int rear;
        private int size;

        public QueueArray(int n){
            queue = new int[n];
            front = 0;
            rear = 0;
            size = 0;
        }

        public bool isEmpty(){
            return size == 0;
        }

        public bool isFull(){
            return queue.Length == size;
        }

        public int Length(){
            return size;
        }

        public void enqueue(int element){
            if(isFull()){
                Console.WriteLine("Queue is Full.");
                return;
            }
            else{
                queue[rear] = element;
                rear++;
                size++;
            }
        }

        public int dequeue(){
            if(isEmpty()){
                Console.WriteLine("Queue is Empty.");
                return -1;
            }
            else{
                int element = queue[front];
                front++;
                size--;
                return element;
            }
        }

        public int first(){
            return queue[front];
        }

        public void Display(){
            for(int i = front; i<rear; i++){
                Console.Write(queue[i]+"-");
            }
            Console.WriteLine();
        }

        
        public static void Main(){
            Console.WriteLine("Queue Data Structure.");
            QueueArray q = new QueueArray(5);
            q.enqueue(1);
            q.enqueue(2);
            q.enqueue(3);
            q.Display();
            Console.WriteLine("Length is :"+ q.Length());

            //dequeue
            Console.WriteLine("Dequeue is :"+ q.dequeue());
            q.Display();

            q.enqueue(1);
            q.dequeue();
            q.Display();
            Console.WriteLine("First : "+ q.first());
            Console.WriteLine("Length :"+ q.Length());
        }
    }
}