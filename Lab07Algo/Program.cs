using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algor7
{
    class Program
    {
        public static void Quick_Sort(int[] array, int start, int end)
        {
            int i = start; int j = end; int x = array[(start + end) / 2];
            int temp = 0;
            if (start < end)
                do
                {
                    while (array[i] < x)
                    {
                        i++;
                    }
                    while (x < array[j])
                    {
                        j--;
                    }

                    if (i <= j)
                    {
                        temp = array[j]; // swap
                        array[j] = array[i];
                        array[i] = temp;
                        i++;
                        j--;
                    }


                }
                while (i <= j);
            /* Console.WriteLine(x);
             foreach (var item in array)
             {
                 Console.Write(" " + item);
             }
             Console.WriteLine();*/
            if (start < j)
                Quick_Sort(array, start, j);
            if (i < end)
                Quick_Sort(array, i, end);
            // return marker;
        }
        public static int Linear(int[] A, int key)
        {
            int[] B = new int[A.Length + 1];
            for (int l = 0; l < A.Length; l++)
            {
                B[l] = A[l];
            }
            B[A.Length] = key;
            //int l = A.Length;
            //B[] = key; 
            int i = -1;
            do
            {
                i++;
                Console.WriteLine("number iteration=" + i + ";" + "index=" + i);
            }
            while (B[i] != key);
            return i;
        }
        public static int Linear2(List<int> A, int key)
        {
            List<int> B = new List<int>(A.Count + 1);
            for (int l = 0; l < A.Count; l++)
            {
                B.Add(A[l]);
            }
            B.Add(key); int i = -1;
            do
            {
                i++;
            }
            while (B[i] != key);
            return i;
        }
        public static int Binary(int[] A, int L, int R, int key)
        {
            //int m = (L + R) / 2;
            int i = 1;
            while (L <= R)
            {
                //індекс середнього елементу
                var middle = (L + R) / 2;
                Console.WriteLine("number iteration=" + i + ";" + "index=" + middle);
                i++;
                if (key == A[middle])
                {
                    return middle;

                }
                else if (key < A[middle])
                {
                    R = middle - 1;
                }
                else
                {
                    L = middle + 1;
                }
            }
            return -1;

        }
        public static List<int> One(int[] A)
        {
            // int[] B = new int[A.Length];
            List<int> B = new List<int>(A);
            for (int j = 0; j < A.Length; j++)
            {
                for (int i = 0; i < A.Length; i++)
                {
                    if (i != j)
                        if (A[i] == A[j])
                        {
                            B.Remove(A[j]);
                        }
                }
            }
            return B;
        }
        static List<int> Logic(List<int> C, List<int> D)
        {
            int k = 0;
            if (C.Count > D.Count)
            {
                k = C.Count;
            }
            else k = D.Count;
            List<int> E = new List<int>(k);
            for (int i = 0; i < D.Count; i++)
            {
                for (int j = 0; j < C.Count; j++)
                {
                    if (D[i] == C[j])
                    {
                        E.Add(D[i]);
                    }
                }
            }
            return E;
        }
        static void Main(string[] args)
        {
            //const int n = 6; const int k = 3;
            int[] A = new int[5] { 5, 9, 3, 4, 8 };
            int[] B = new int[5] { 9, 7, 4, 4, 2 };
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write(A[i] + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < B.Length; i++)
            {
                Console.Write(B[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Linear: A; key=5");
            int b = Linear(A, 5);
            Console.WriteLine();
            Quick_Sort(A, 0, A.Length - 1);
            Console.WriteLine("Binary:A,key=5");
            int c = Binary(A, 0, A.Length - 1, 5);
            if (c == -1)
            {
                Console.WriteLine("not found");
            }
            else
                Console.WriteLine(A[c]);
            // int s=Binary(A, 0, A.Length - 1, 8);
            //Console.WriteLine(s);
            List<int> C = One(B);
            List<int> D = One(A);
            Console.WriteLine("one in B");
            if (C.Count == 0)
            {
                Console.WriteLine("not found");
            }
            for (int i = 0; i < C.Count; i++)
            {

                Console.Write(C[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("One in A");
            if (D.Count == 0)
            {
                Console.WriteLine("not found");
            }
            for (int i = 0; i < D.Count; i++)
            {

                Console.Write(D[i] + " ");
            }
            Console.WriteLine();

            List<int> E = Logic(C, D);
            Console.WriteLine("Result");
            for (int i = 0; i < E.Count; i++)
            {
                Console.Write(E[i] + " ");
            }



            Console.ReadKey();
        }
    }
}
