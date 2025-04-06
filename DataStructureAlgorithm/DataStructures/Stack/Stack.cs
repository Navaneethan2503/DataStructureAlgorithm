using System;

namespace Stack{
    class Stack{

        private int[] stack;
        private int top;

        public Stack(int size){
            stack = new int[size];
            top = 0;
        }

        public bool isEmpty(){
            return top == 0;
        }

        public int length(){
            return top;
        }

        public void Display(){
            for(int i = 0; i<top; i++){
                Console.WriteLine("---");
                Console.WriteLine(stack[i]);
            }
        }

        public bool isFull(){
            return top == stack.Length;
        }

        public void push(int element){
            if(isFull()){
                Console.WriteLine("Stack is full / OverFlow.");
                return;
            }
            stack[top] = element;
            top++;
        }

        public int peekTop(){
            if(isEmpty()){
                Console.WriteLine("Stack is Empty.");
                return -1;
            }
            return stack[top-1];
        }

        public int pop(){
            if(isEmpty()){
                Console.WriteLine("Stack is Empty.");
                return -1;
            }
            int element = stack[top-1];
            top--;
            return element;
        }

        public static void Main(){
            Console.WriteLine("Stack DataStructure...");
            Stack s = new Stack(5);
            s.push(1);
            s.push(2);
            s.push(3);
            s.Display();
            
            //Pop
            Console.WriteLine("Removed :"+s.pop());
            s.Display();

            //Peep
            Console.WriteLine("Peek is :"+ s.peekTop());
            s.Display();
        }
    }
}