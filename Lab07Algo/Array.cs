using System;
using System.IO;

namespace test_quicksort
{
    class Program
    {
        static string path = @"D:\Programming\C#\Algorithms\lab06\output";
        static int comp = 0;
        static int swap = 0;

        static void Main(string[] args)
        {
            string comps = "";
            string swaps = "";

            int n = InputInt("number of arrays");
            int[][] arrays = GenerateArrays(n);
            foreach (int[] arr in arrays)
            {
                PrintArr(arr);
            }
            Console.WriteLine();
            foreach (int[] arr in arrays)
            {
                QuickSort(arr, 0, arr.Length - 1);
                PrintArr(arr);
                Console.WriteLine($"\n\ncomp = {comp}\nswap = {swap}");

                comps += "{" + arr.Length + "," + comp + "},";
                swaps += "{" + arr.Length + "," + swap + "},";

                comp = 0;
                swap = 0;
            }
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(comps);
                sw.WriteLine(swaps);
            }
        }

        static int InputInt(string s)
        {
            Console.WriteLine(s);
            return int.Parse(Console.ReadLine());
        }

        static void PrintArr(int[] arr)
        {
            Console.WriteLine();
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
        }

        static int[][] GenerateArrays(int n)
        {
            int[][] arrays = new int[n][];
            Random rng = new Random();
            for (int i = 0; i < n; i++)
            {
                int[] arr = new int[4 + i];
                for (int j = 0; j < 4 + i; j++)
                {
                    arr[j] = rng.Next(10000);
                }
                arrays[i] = arr;
            }
            return arrays;
        }

        static void QuickSort(int[] arr, int left, int right)
        {
            comp++;
            if (left < right)
            {
                int pivot = Partition(arr, left, right);
                comp += 2;
                if (pivot > 1)
                {
                    QuickSort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    QuickSort(arr, pivot + 1, right);
                }
            }
        }

        static int Partition(int[] arr, int left, int right)
        {
            int key = arr[left];
            while (true)
            {
                while (arr[left] < key)
                {
                    left++;
                    comp++;
                }
                while (arr[right] > key)
                {
                    right--;
                    comp++;
                }
                comp += 3;
                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;
                    comp++;

                    int temp = arr[right];
                    arr[right] = arr[left];
                    arr[left] = temp;
                    swap++;
                }
                else
                {
                    return right;
                }
            }
        }
    }
}
