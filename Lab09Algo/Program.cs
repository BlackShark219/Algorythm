using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algor9
{
    class Node
    {
        public Node left;
        public Node right;
        public Node parent;
        public int value;
        public Node()
        {

        }
        public Node(int key)
        {
            this.value = key;
        }
        static void AddTo(Node a)
        {
            //insert(a.right)
        }
        //public override bool Equals(Node obj)
        //{
        //    return  (this.value == obj.value) ;
        //}
    }

    class Program
    {
        static public void inorderTraversal(Node x)
        {
            if (x != null)
            {
                inorderTraversal(x.left);
                Console.Write(x.value + " ");
                inorderTraversal(x.right);
            }
        }
        static public void preorderTraversal(Node x)
        {
            if (x != null)
            {
                Console.Write(x.value + " ");
                preorderTraversal(x.left);
                preorderTraversal(x.right);
            }
        }
        static public void postorderTraversal(Node x)
        {
            if (x != null)
            {
                postorderTraversal(x.left);
                postorderTraversal(x.right);
                Console.Write(x.value + " ");

            }
        }
        static public bool search(Node x, int key)
        {
            if (x == null) return false;
            else
            if (key == x.value) return true;
            if (key < x.value) return search(x.left, key); else return search(x.right, key);
        }
        //static public bool search1(Node x, int key)
        //{
        //    if (x == null) return false;
        //    else
        //    if (key == x.value) return true;
        //    if (key < x.value) return search(x.left, key); else return search(x.right, key);
        //}

        //static void Searcher(List<int>a , int j)
        //{
        //    int z = 0;
        //    Node b = build(a);
        //    for (int o=0;o<b.value; o++)
        //    if (search1(ref b, j) == true) z++;
        //}

        static void search1(ref Node x, int j, List<int> a)
        {
            build(a);
            int z = 0;
            if (j < x.value)
            {
                for (int o = 0; o < a.Count; o++)
                    if (a[o] == j) z++;
                Console.WriteLine("Входить у дерево ");
                Console.WriteLine(z);

            }
            else Console.WriteLine("Задана чифра або число не входить у ліве піддерево");

        }
        static public Node insert(Node x, Node ins)
        {
            if (x == null)
            {
                x = ins;
                return x;
            }
            if (x.value > ins.value)
                if (x.left == null)
                {
                    x.left = ins;
                    x.left.parent = x;
                    return x.left;
                }
                else return insert(x.left, ins);
            else
                if (x.right == null)
            {
                x.right = ins;
                x.right.parent = x;
                return x.right;
            }
            else return insert(x.right, ins);
        }
        static public void Add(Node a, Node b)//додаєм праве піддерево з а у b
        {

        }
        static public Node build(List<int> a)
        {
            Node b = new Node(a[0]);
            a.Remove(a[0]);
            List<int> min = new List<int>();
            List<int> max = new List<int>();

            foreach (int i in a)
                if (i < b.value) min.Add(i); else max.Add(i);
            if (min.Count > 0) b.left = build(min);
            if (max.Count > 0) b.right = build(max);
            return b;
        }
        static public Node minimum(Node root)
        {
            if (root.left == null) return root; else return minimum(root.left);
        }
        /* static public Node maximum(Node root)
         {
             if (root.right == null) return root; else return maximum(root.right);

         }*/
        static public Node delete(Node root, int key)
        {
            if (root == null) return root;
            if (key < root.value) root.left = delete(root.left, key);
            else if (key > root.value) root.right = delete(root.right, key);
            else
                if (root.right != null)
            {
                root.value = minimum(root.right).value;
                root.right = delete(root.right, root.value);
            }
            else root = root.left;//if (root.left != null) root = root.left; else root = root.right;
            return root;
        }
        static public Node delete_all(Node root)
        {

            if (root == null) return root;
            delete_all(root.left);
            delete_all(root.right);
            root.left = null;
            root.right = null;
            root = null;
            return root;

        }
        static public int canRead()
        {
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {

                return -1;
            }
        }
        static void Renum(ref Node b, ref int i)
        {
            if (b == null) { throw new ArgumentException("There is no binary tree"); }
            if (b.left != null)
            {
                Renum(ref b.left, ref i);
            }
            if (b.right != null)
            {
                Renum(ref b.right, ref i);
            }
            b.value = i;
            i++;
        }
        static void insertTree(Node a, Node b)
        {
            if (b != null)
            {
                insertTree(a, b.left);
                insert(a, b);
                insertTree(a, b.right);
            }
        }
        static void Main(string[] args)
        {
            //int n = int.Parse(Console.ReadLine());
            int x = 0;
            List<int> a = new List<int>();
            while ((x = canRead()) != -1)
            {
                a.Add(x);

            }
            Node b = build(a);
            Console.WriteLine();
            Console.Write("inorder tranversal: ");
            inorderTraversal(b);
            Console.WriteLine();
            Console.Write("preorder tranversal: ");
            preorderTraversal(b);
            Console.WriteLine();
            Console.Write("postorder tTranversal: ");
            postorderTraversal(b);
            Console.WriteLine();

            Console.Write("delete vertex = ");

            delete(b, canRead());
            Console.Write("inorder tranversal: ");
            inorderTraversal(b);
            Console.WriteLine();
            Console.Write("preorder tranversal: ");
            preorderTraversal(b);
            Console.WriteLine();
            Console.Write("postorder tranversal: ");
            postorderTraversal(b);
            Console.WriteLine();
            Console.Write("insert number = ");
            insert(b, new Node(canRead()));
            Console.Write("inorder tranversal: ");
            inorderTraversal(b);
            Console.WriteLine();
            Console.Write("preorder tranversal: ");
            preorderTraversal(b);
            Console.WriteLine();
            Console.Write("postorder tranversal: ");
            postorderTraversal(b);
            Console.WriteLine();
            Console.Write("find vertex = ");
            if (search(b, canRead())) Console.WriteLine("is"); else Console.WriteLine("isn't");
            Console.WriteLine("Delete tree");
            delete_all(b);
            List<int> nova = new List<int>();
            Node n = build(nova);
            List<int> cin = new List<int>();
            while ((x = canRead()) != -1)
            {
                cin.Add(x);

            }

            Console.Write("inorder tranversal: ");
            List<int> now = new List<int>();
            now.AddRange(a);
            for (int i = 1; i < cin.Count; i++)
            {
                Console.WriteLine("1");
                if (cin[i] > cin[0])
                    now.Add(cin[i]);
            }
            Console.WriteLine();
            /*List<int> vs = new List<int>();
            for (int i=0; i<cin.Count;i++)
            {
                cin.Add(now[i]);
            }*/
            Console.WriteLine(now.Count);
            Node nic = build(now);

            Console.Write("inorder tranversal: ");
            inorderTraversal(nic);
            Console.WriteLine();
            Console.Write("preorder tranversal: ");
            preorderTraversal(nic);
            Console.WriteLine();
            Console.Write("postorder tranversal: ");
            postorderTraversal(nic);
            /* Console.WriteLine("input Number to find how many it is in left");
             search1(ref b, canRead(), a);
               Console.WriteLine(minimum(b).value + " " + maximum(b).value);
             Console.WriteLine(minimum(b).value == maximum(b).value);

             Console.WriteLine("Delete tree");
             delete_all(b);
             Console.WriteLine("Empty tree's traversal ");
             inorderTraversal(b);
             Console.WriteLine("\n=======================");

             int k = 1;
              Renum(ref b, ref k);
              inorderTraversal(b);

             Console.ReadLine();*/
            Console.ReadKey();
        }
    }
}
