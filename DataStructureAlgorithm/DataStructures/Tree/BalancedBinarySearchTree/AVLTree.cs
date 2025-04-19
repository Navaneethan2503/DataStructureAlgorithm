using System;

namespace BalancedTree{
    class Node{
        public int Key;
        public Node left;
        public Node right;
        public int height;

        public Node(int key){
            Key = key;
            left = null;
            right = null;
            height = 1;
        }
    }

    class AVLTree{
        public Node root;

        public AVLTree(){
            root = null;
        }

        private int Get_Height(Node tnode){
            if(tnode == null){
                return 0;
            }
            return tnode.height;
        }

        private int Get_Balance(Node tnode){
            if(tnode == null){
                return 0;
            }
            return Get_Height(tnode.left) - Get_Height(tnode.right);
        }

        public Node insertNode(Node troot, int key){
            //Standard Insertion
            if(troot == null){
                troot = new Node(key);
                return troot;
            }
            if(key < troot.Key){
                troot.left = insertNode(troot.left,key);
            }
            else if (key > troot.Key){
                troot.right = insertNode(troot.right,key);
            }
            else{
                return troot;
            }
            //Update Height
            troot.height = Math.Max(Get_Height(troot.left), Get_Height(troot.right)) + 1;

            //Balance Check
            int Balance = Get_Balance(troot);
            Console.WriteLine("Key - "+troot.Key+ ", Balance :"+ Balance+ " , Height: "+ troot.height);

            //Check For LL Rotation 
            if(Balance > 1 && key < troot.left.Key){
                return RRRotation(troot);
            }

            //Check for RR Rotation
            if( Balance < -1 && key > troot.right.Key){
                return LLRotation(troot);
            }

            //Check for LR Rotation
            if(Balance > 1 && key > troot.left.Key){
                return LRRotation(troot);
            }

            //Check for RL Rotation
            if(Balance < -1 && key < troot.right.Key){
                return RLRotation(troot);
            }
            
            return troot;
        }

        public Node RLRotation(Node troot){
            Console.WriteLine("RL Rotation for :"+troot.Key);
            troot.right = RRRotation(troot.right);
            return LLRotation(troot);
        }

        public Node LRRotation(Node troot){
            Console.WriteLine("LR Rotation for :"+troot.Key);
            troot.left = LLRotation(troot.left);
            return RRRotation(troot);
        }

        public Node RRRotation(Node troot){
            Console.WriteLine("RR Rotation for :"+troot.Key);
            Node xl = troot.left;
            Node temp = xl.right;
            //anti Clock wise Rotation
            xl.right = troot;
            troot.left = temp;

            //Update Height
            troot.height = Math.Max(Get_Height(troot.left), Get_Height(troot.right))+1;
            xl.height = Math.Max(Get_Height(xl.left), Get_Height(xl.right)) + 1;

            return xl;
        }

        public Node LLRotation(Node troot){
            Console.WriteLine("LL Rotation for :"+troot.Key);
            Node y = troot.right;
            Node temp = y.left;

            //Rotation on clock wise
            y.left = troot;
            troot.right = temp;

            //Update Height
            troot.height = Math.Max(Get_Height(troot.left), Get_Height(troot.right)) + 1;
            y.height = Math.Max(Get_Height(y.left), Get_Height(y.right)) + 1;

            return y;//y is a root now
        }

        public void PreOrder(Node troot){
            if(troot != null){
                Console.Write(troot.Key+",");
                PreOrder(troot.left);
                PreOrder(troot.right);
            }
        }

        public Node GetMinValueOfNode(Node troot){
            Node current = troot;
            while(current != null){
                current = current.left; //Traverse left most left node to get min value.
            }
            return current;
        }

        public Node deletion(Node troot, int key){

            //Standard BST Deletion using Recursion
            if(troot == null){
                return troot;
            }
            else if(key < troot.Key){
                troot.left = deletion(troot.left,key);
            }
            else if(key > troot.Key){
                troot.right = deletion(troot.right, key);
            }
            else{
                if(troot.left == null){
                    return troot.right;
                }
                if(troot.right == null){
                    return troot.left;
                }
                Node temp = GetMinValueOfNode(troot.right);
                troot.Key = temp.Key;
                troot.right = deletion(troot.right, temp.Key);
            }
            //Deletion Completed

            //Update Height
            troot.height = 1 + Math.Max(Get_Height(troot.left),Get_Height(troot.right));

            //Check Balance
            int Balance = Get_Balance(troot);

            //Check Each Rotation Signature and Perform appropiate Operation

            //LL Rotaion
            if(Balance > 1 && Get_Balance(troot.left) >= 0){
                return RRRotation(troot);
            }

            //LR Rotation
            if(Balance > 1 && Get_Balance(troot.right) < 0){
                troot.left = LLRotation(troot.left);
                return RRRotation(troot);
            }

            //RR Rotation
            if(Balance < -1 && Get_Balance(troot.right) <= 0){
                return RRRotation(troot);
            }

            //RL Rotation
            if(Balance < -1 && Get_Balance(troot.right) > 0){
                troot.right = RRRotation(troot.right);
                return LLRotation(troot);
            }

            return troot;
        }

        public static void Main(){
            Console.WriteLine("AVL Tree.");
            AVLTree tree  = new AVLTree();
            tree.root = tree.insertNode(tree.root,35);
            tree.root = tree.insertNode(tree.root,20);
            tree.root = tree.insertNode(tree.root,10);
            tree.root = tree.insertNode(tree.root,64);
            tree.root = tree.insertNode(tree.root,45);
            tree.PreOrder(tree.root);
            Console.WriteLine();

            //Deletion
            Console.WriteLine("Deletion :");
            tree.root = tree.deletion(tree.root,35);
            tree.PreOrder(tree.root);
        }




    }

    
}