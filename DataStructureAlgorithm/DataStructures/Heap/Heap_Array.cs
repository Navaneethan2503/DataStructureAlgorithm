using System;

namespace HeapArray{
    class Heap{
        private int[] data;
        private int csize;
        private int maxsize;

        public Heap(){
            maxsize = 10;
            data = new int[maxsize];
            csize = 0;
            for(int i = 0; i<maxsize; i++){
                data[i] = -1;
            }
        }

        public bool isEmpty(){
            return csize == 0;
        }

        public bool isFull(){
            return csize == maxsize;
        }

        public int GetCurrentSize(){
            return csize;
        }

        public void Display(){
            for(int i = 0; i<maxsize; i++){
                Console.Write(data[i]+",");
            }
            Console.WriteLine();
        }

        public void insert(int e){
            if(isFull()){
                Console.WriteLine("No Space, Heap is Full.");
                return;
            }
            csize = csize + 1;
            int hi = csize;
            while(hi>1 && e > data[hi/2]){
                data[hi] = data[hi/2];
                hi = hi / 2;
            }
            data[hi] = e;
        }

        public int GetMax(){
            if(isEmpty()){
                Console.WriteLine("Heap is Empty.");
                return -1;
            }
            return data[1];
        }

        public int deleteMax(){
            if(isEmpty()){
                Console.WriteLine("Heap is Empty.");
                return -1;
            }
            int e = data[1];
            data[1] = data[csize];
            data[csize] = -1;
            csize = csize - 1;
            int i = 1, j = i * 2;
            while(j <= csize){
                if(data[j] < data[j+1]){
                    j = j + 1;
                }
                if(data[i]<data[j]){
                    int temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                    i = j;
                    j = i*2;
                }
                else{
                    break;
                }
            }
            return e;
        }

        public static void Main(){
            Console.WriteLine("Heap Data Structure.");
            Heap heap = new Heap();
            heap.insert(25);
            heap.insert(14);
            heap.insert(2);
            heap.insert(20);
            heap.insert(10);
            heap.insert(40);
            heap.Display();

            //Deletion
            Console.WriteLine("Delete Max at Heap :");
            Console.WriteLine("Deleted :"+heap.deleteMax());
            heap.Display();
        }
    }
}