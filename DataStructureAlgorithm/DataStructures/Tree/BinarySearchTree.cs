using System;
/**
**/
namespace Tree{
    class Node{
        public int element;
        public Node left;
        public Node right;

        public Node(int e){
            element = e;
            left = null;
            right = null;
        }
    }

    public class QNode
    {
        public Object element;
        public QNode next;
        public QNode(Object e)
        {
            element = e;
            next = null;
        }
    }
    
    class Queue{
        private QNode Front;
        private QNode Tail;
        private int size;

        public Queue(){
            Front = null;
            Tail = null;
            size = 0;
        }

        public bool IsEmpty(){
            return size == 0;
        }

        public void Enqueue(Object e){
            QNode newest = new QNode(e);
            if(IsEmpty()){
                Front = newest;
            }
            else{
                Tail.next = newest;
            }
            Tail = newest;
            size++;
        }

        public Object Dequeue(){
            if(IsEmpty()){
                return null;
            }
            Object res = Front.element;
            Front = Front.next;
            size--;
            if(IsEmpty()){
                Tail = null;
            }
            return res;
        }
    }
    class BinarySearchTree{

        public Node root;

        public BinarySearchTree(){
            root = null;
        }

        //T(N) - O(h)
        public void InsertNode(Node troot, int e){
            Node temp = troot;
            while(troot != null){
                temp = troot;
                if(troot.element == e){
                    return;//Not Allowed Duplicate
                }
                if(e < troot.element){
                    troot = troot.left;
                }
                else if (e > troot.element){
                    troot = troot.right;
                }
            }
            Node newest = new Node(e);
            if(root != null){
                if(e < temp.element){
                    temp.left = newest;
                }
                else{
                    temp.right = newest;
                }
            }
            else{
                root = newest;
            }
        }

        //T(N) - O(H)
        public Node InsertRecursive(Node troot, int e){
            if(troot != null){
                if(troot.element != null){
                    if(e < troot.element){
                        troot.left = InsertRecursive(troot.left,e);
                    }
                    else if(e > troot.element){
                        troot.right = InsertRecursive(troot.right,e);
                    }
                }
            }
            else{
                Node newest = new Node(e);
                troot = newest;
            }
            return troot;
        }

        //T(N) - O(N)
        public void InOrder(Node troot){
            if(troot != null){
                InOrder(troot.left);
                Console.Write(troot.element+" ");
                InOrder(troot.right);
            }
        }

        //T(N) - O(N)
        public void PreOrder(Node troot){
            if(troot != null){
                Console.Write(troot.element+" ");
                PreOrder(troot.left);
                PreOrder(troot.right);
            }
        }

        //T(N) - O(N)
        public void PostOrder(Node troot){
            if(troot != null){
                PostOrder(troot.left);
                PostOrder(troot.right);
                Console.Write(troot.element+" ");
            }
        }

        //O(t) - O(n)
        public void LevelOrder(){
            Queue q = new Queue();
            Node troot = root;
            Console.Write(troot.element+" ");
            q.Enqueue(troot);
            while(!q.IsEmpty()){
                troot = (Node)q.Dequeue();
                if(troot.left != null){
                    Console.Write(troot.left.element+" ");
                    q.Enqueue(troot.left);
                }
                if(troot.right != null){
                    Console.Write(troot.right.element+" ");
                    q.Enqueue(troot.right);
                }
            }
        }

        //Iterative Search - O(T) - O(h)
        public bool SearchKey(int e){
            Node troot = root;
            while(troot != null){
                if(troot.element == e){
                    return true;
                }
                else if(e < troot.element){
                    troot = troot.left;
                }
                else if(e > troot.element){
                    troot = troot.right;
                }
            }
            return false;
        }

        //Recursive Search - T(n) - O(h)
        public bool RecursiveSearch(Node troot, int key){
            if(troot != null){
                if(troot.element == key){
                    return true;
                }
                else if(key < troot.element){
                    return RecursiveSearch(troot.left, key);
                }
                else if(key > troot.element){
                    return RecursiveSearch(troot.right, key);
                }
            }
            return false;
        }

        public bool delete(int e)
        {
            Node n = root;
            Node p = null;
            while(n != null && n.element != e){
                p = n;
                if(e < n.element){
                    n = n.left;
                }
                else{
                    n = n.right;
                }
            }
            //check for not found
            if(n == null){
                return false;
            }
            //Node Posibilities if deletion node have both left and right sub tree
            if(n.left != null && n.right != null){
                //Find largest Element from left sub tree of right most element.
                Node t = n.left;
                Node pt = n;
                while(t.right != null){
                    pt = t;
                    t = t.right;
                }
                n.element = t.element;
                n = t;
                p = pt;
            }
            //check for posibility of any one sub tree left or right exist
            Node c = null;
            if(n.left != null){
                c = n.left;
            }
            else{
                c = n.right;
            }

            //Process for deletion;
            if(n == root){
                root = c;
            }
            else{
                if(n == p.left){
                    p.left = c;
                }
                else{
                    p.right = c;
                }
            }
            return true;
        }

        public int Count(Node troot){
            if(troot != null){
                int x = Count(troot.left);
                int y = Count(troot.right);
                return x + y + 1;
            }
            return 0;
        }

        public int height(Node troot){
            if(troot != null){
                int x = height(troot.left);
                int y = height(troot.right);
                if(x > y){
                    return x+1;
                }
                else{
                    return y+1;
                }
            }
            return 0;
        }

        public static void Main(){
            Console.WriteLine("Binary Search Tree");
            BinarySearchTree bst = new BinarySearchTree();
            bst.root  = bst.InsertRecursive(bst.root, 50);
            bst.InsertRecursive(bst.root, 30);
            bst.InsertRecursive(bst.root, 80);
            bst.InsertRecursive(bst.root, 10);
            bst.InsertRecursive(bst.root, 40);
            bst.InsertRecursive(bst.root, 60);
            bst.InsertRecursive(bst.root, 90);
            Console.WriteLine("In-Order Traversal :" );
            bst.InOrder(bst.root);
            Console.WriteLine();
            Console.WriteLine("Pre-Order Traversal :" );
            bst.PreOrder(bst.root);
            Console.WriteLine();
            Console.WriteLine("Post-Order Traversal :" );
            bst.PostOrder(bst.root);
            Console.WriteLine();
            Console.WriteLine("Level-Order Traversal :" );
            bst.LevelOrder();
            Console.WriteLine("Search Key : 90 :"+ bst.SearchKey(90));
            Console.WriteLine("Search using Recursive : 80 - "+ bst.RecursiveSearch(bst.root, 80));
            Console.WriteLine("Search using Recursive : 100 - "+ bst.RecursiveSearch(bst.root, 100));

            //delete 
            Console.WriteLine("Delete 80 : "+ bst.delete(80));
            bst.LevelOrder();
            Console.WriteLine("Delete 100 : "+ bst.delete(100));
            bst.LevelOrder();
            Console.WriteLine("Delete 60 : "+ bst.delete(60));
            bst.LevelOrder();
            Console.WriteLine();

            //Count
            Console.WriteLine("Count No. of Nodes in BST is :"+bst.Count(bst.root));

            //Height
            Console.WriteLine("Height of BST is :"+bst.height(bst.root));
        }
    }
}