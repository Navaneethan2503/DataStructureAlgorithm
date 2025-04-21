using System;
/**
**/
namespace RedBlackTreeNamespace{
    class Node{
        public int data;
        public string color;
        public Node left;
        public Node right;
        public Node parent;

        public Node(int key){
            data = key;
            color = "Red";
            left = null;
            right = null;
            parent = null;
        }
    }
    class RedBlackTree{

        public Node root;

        public RedBlackTree(){
            root = null;
        }

        public void InOrder(Node node){
            if(node != null){
                InOrder(node.left);
                Console.WriteLine(node.data+" - Color :"+ node.color);
                InOrder(node.right);
            }
        }

        // Function to perform left rotation
        public Node RotateLeft(Node node)
        {
            Console.WriteLine("L Rotation :"+node.data+", Color: "+ node.color);
            Node x = node.right;
            Node y = x.left;
            x.left = node;
            node.right = y;
            node.parent = x;

            if (y != null)
                y.parent = node;

            return x;
        }

        // Function to perform right rotation
        public Node RotateRight(Node node)
        {
            Console.WriteLine("R Rotation :"+node.data+", Color: "+ node.color);
            Node x = node.left;
            Node y = x.right;
            x.right = node;
            node.left = y;
            node.parent = x;

            if (y != null)
                y.parent = node;

            return x;
        }

        // Public method to insert data into the tree
        public void Insert(int data)
        {
            if (root == null) {
                root = new Node(data);
                root.color = "Black";
            }
            else
                root = InsertHelp(root, data);
        }

        public Node InsertHelp(Node root, int data){
            bool f = false;

            if (root == null)
                return new Node(data);
            else if (data < root.data) {
                root.left = InsertHelp(root.left, data);
                root.left.parent = root;

                if (root != this.root) {//Checking Red Property
                    if (root.color == "Red"
                        && root.left.color == "Red")
                        f = true;
                }
            }
            else {
                root.right = InsertHelp(root.right, data);
                root.right.parent = root;

                if (root != this.root) {//Checking Red Property
                    if (root.color == "Red"
                        && root.right.color == "Red")
                        f = true;
                }
            }

            // Rotate and recolor based on flags
            if (ll) {
                //Scenario - 2 RR Rotation and Coloring
                root = RotateLeft(root);
                root.color = "Black";
                root.left.color = "Red";
                ll = false;
            }
            else if (rr) {
                //scenario 2 - LL Rotation and coloring
                root = RotateRight(root);
                root.color = "Black";
                root.right.color = "Red";
                rr = false;
            }
            else if (rl) {
                //Scenarion - 3 - RL Rotation and Coloring
                root.right = RotateRight(root.right);
                root.right.parent = root;
                root = RotateLeft(root);
                root.color = "Black";
                root.left.color = "Red";
                rl = false;
            }
            else if (lr) {
                //Scenario - 3 - LR Rotation and coloring
                root.left = RotateLeft(root.left);
                root.left.parent = root;
                root = RotateRight(root);
                root.color = "Black";
                root.right.color ="Red";
                lr = false;
            }

            // Handle RED-RED conflict
            if (f) {
                if (root.parent.right == root) {
                    //RR Rotation
                    if (root.parent.left == null
                        || root.parent.left.color == "Black") {
                        if (root.left != null
                            && root.left.color == "Red")
                            rl = true;
                        else if (root.right != null
                                && root.right.color == "Red")
                            ll = true;
                    }
                    else {
                        //Scenerio - 1 Coloring
                        root.parent.left.color = "Black";
                        root.color = "Black";
                        if (root.parent != this.root)
                            root.parent.color ="Red";
                    }
                }
                else {
                    //Left Rotation
                    if (root.parent.right == null
                        || root.parent.right.color == "Black") {
                        if (root.left != null
                            && root.left.color == "Red")
                            rr = true;
                        else if (root.right != null
                                && root.right.color == "Red")
                            lr = true;
                    }
                    else {
                        //Coloring
                        root.parent.right.color = "Black";
                        root.color = "Black";
                        if (root.parent != this.root)
                            root.parent.color = "Red";
                    }
                }
                f = false;
            }

            return root;
        }


        // Flags for rotation types
        bool ll = false;
        bool rr = false;
        bool lr = false;
        bool rl = false;

        // Function to perform deletion
        public void DeleteNode(int data)
        {
            deleteNodeHelper(this.root,data);
        }

        public void deleteNodeHelper(Node node, int key){
            Node z = new Node(0);
            Node x, y;
            while(node != null){
                if(node.data == key){
                    z = node;
                }
                if(key < node.data){
                    node = node.left;
                }
                else{
                    node = node.right;
                }
            }
            if(z == null){
                Console.WriteLine("Node not Found");
                return;
            }
            y = z;
            string yOriginalColor = y.color;
            if(z.left == null){
                x = z.right;
                rbTransplant(z,z.right);
            }
            else if(z.right == null){
                x = z.left;
                rbTransplant(z,z.left);
            }
            else{
                y = GetMinValueOfNode(z.right);
                yOriginalColor = y.color;
                x = y.right;
                if(x != null){
                    if(y.parent == z){
                        x.parent = y;
                    }
                    else{
                        rbTransplant(y,y.right);
                        y.right = z.right;
                        y.right.parent = y;
                    }
                }
                rbTransplant(z,y);
                y.left = z.left;
                y.left.parent = y;
                y.color = z.color;
            }
            if(yOriginalColor == "Red"){
                fixDelete(x);
            }
        }

        private void rbTransplant(Node u, Node v){
            if(u.parent == null){
                root = v;
            }
            else if(u == u.parent.left){
                u.parent.left = v;
            }
            else{
                u.parent.right = v;
            }
            if(u != null && v != null){
                v.parent = u.parent;
            }
        }

        private void fixDelete(Node x){
            Node s;
            Console.WriteLine("fixDelete Came.");
            while(x != null && x != root && x.color == "Red")
            {
                    if(x == x.parent.left){
                        s = x.parent.right;
                    if(s.color == "Black"){
                        s.color = "Red";
                        x.parent.color = "Black";
                        RotateLeft(x.parent);
                        s = x.parent.right;
                    }

                    if(s.left.color == "Red" && s.right.color == "Red"){
                        s.color = "Black";
                        x = x.parent;
                    }
                    else
                    {
                        if(s.right.color == "Red"){
                            s.left.color = "Red";
                            s.color = "Black";
                            RotateRight(s);
                            s = x.parent.right;
                        }
                        s.color = x.parent.color;
                        x.parent.color = "Red";
                        s.right.color = "Red";
                        RotateLeft(x.parent);
                        x = root;
                    }
                }
                else{
                    s = x.parent.left;
                    if(s.color == "Black"){
                        s.color = "Red";
                        x.parent.color = "Black";
                        RotateRight(x.parent);
                        s = x.parent.left;
                    }

                    if(s.right.color == "Red" && s.left.color == "Red"){
                        s.color = "Black";
                        x = x.parent;
                    }
                    else{
                        if(s.left.color == "Red"){
                            s.right.color = "Red";
                            s.color = "Black";
                            RotateLeft(s);
                            s = x.parent.left;
                        }
                        s.color = x.parent.color;
                        x.parent.color = "Red";
                        s.left.color = "Red";
                        RotateRight(x.parent);
                        x = root;
                    }
                }
                
            }
            //x.color = "Red";
        }


        public Node GetMinValueOfNode(Node troot){
            Node current = troot;
            while(current.left != null){
                current = current.left; //Traverse left most left node to get min value.
            }
            return current;
        }

        public static void Main(){
            Console.WriteLine("Red Black Tree");
            RedBlackTree tree = new RedBlackTree();
            tree.Insert(32);
            tree.Insert(25);
            tree.Insert(40);
            tree.Insert(10);
            tree.Insert(64);
            tree.Insert(70);
            tree.Insert(35);
            tree.InOrder(tree.root);
            Console.WriteLine();

             Console.WriteLine("Delete 64 :");
            tree.DeleteNode(64);
            tree.InOrder(tree.root);
            Console.WriteLine();

            Console.WriteLine("Delete 32 :");
            tree.DeleteNode(32);
            tree.InOrder(tree.root);
            Console.WriteLine();

        }
    }
}
