using System.IO;
using System;
using System.Collections.Generic;
class QuickSort
{
    static void swap(double[] numberArray, int index1, int index2)
    {
        double temp = 0;
        temp = numberArray[index1];
        numberArray[index1] = numberArray[index2];
        numberArray[index2] = temp;
    }
    /**
     * This method return median or mid number between first mid and last element of array.
     * Array will be logical sub array depending on left & right. 
	 * left is start of sub array and right is end of sub array
     * @param numberArray
     */
    static double getMedianPivot(double[] numberArray, int left, int right)
    {
        int mid = ((left + right) / 2);
        /** middle number of array is less than left number of array 
		 *  then swap middle and left number
		 */
        if (numberArray[mid] < numberArray[left])
        {
            swap(numberArray, left, mid);
        }
        /** rightmost number of array is less than left number of array 
		 *  then swap right and left number
		 */
        if (numberArray[right] < numberArray[left])
        {
            swap(numberArray, left, right);
        }
        /**
		* now right number is less than mid then swap number which 
		* shifts median of three numbers into mid position
		*/
        if (numberArray[right] < numberArray[mid])
        {
            swap(numberArray, mid, right);
        }
        /**
		* Shift Median or pivot from mid to rightmost position
		* i.e. out of partitioning index
		*/
        swap(numberArray, mid, right);
        /**return pivot number value which is right most now.**/
        return numberArray[right];
    }
    static void recQuickSort(double[] numberArray)
    {
        recQuickSortProcess(numberArray, 0, numberArray.Length - 1);
    }
    static void recQuickSortProcess(double[] numberArray, int left, int right)
    {
        if (left < right)
        {
            int newPivotIndex = partition(numberArray, left, right);
            /**
			*  divide sub array in recursion from left to mid or newPivotIndex-1 and
			*  newPivotIndex+1 to right i.e. two sub array break at pivot; 
			*  here newPivotIndex is index where left elements are lesser or = than pivot
      		*  and right elements are greater or = than pivot
			*/
            recQuickSortProcess(numberArray, left, newPivotIndex - 1);
            recQuickSortProcess(numberArray, newPivotIndex + 1, right);
        }
    }
    static int partition(double[] numberArray, int left, int right)
    {
        double pivot = getMedianPivot(numberArray, left, right);

        /*Console.WriteLine("\nArray Before Partition and after Pivot:");
		printArray(numberArray);
		Console.WriteLine("If Left="+left+", Right="+right+" as array Then pivot="+pivot);*/

        /**
		* Initialize low = left i.e. start index of array or logical sub-array
		* Initialize high = right-1 i.e. end index of array or logical sub array;
      	* becuase right is pivot element so start from right-1;
		*/
        int low = left;
        int high = right - 1;
        while (low < high)
        {
            /**
			 * Left elements are less than pivot then move continue towards right side of array
			 */
            while (numberArray[low] < pivot)
            {
                low++;
            }
            /**
			* Right elements are greater than pivot then move continue towards left side of array
			*/
            while (numberArray[high] > pivot)
            {
                high--;
            }
            /** 
			* Swap elements when any left element is greater than pivot or  
			* any right element is less than pivot.
			*/
            if (low < high)
            {
                swap(numberArray, low, high);
                low++;
                high--;
            }
        }
        /**
		*  Swap right most pivot to its right position i.e. at low, then 
		*  left elements are lesser and right elements are greater than pivot.
		*/
        swap(numberArray, low, right);

        /*Console.WriteLine("Array After Partition:");
		printArray(numberArray);
	    Console.WriteLine("\n new Pivot Index="+low);*/

        return low;
    }

    static List<double> Mode(double[] numberArray)
    {
        double[] sorted = new double[numberArray.Length];
        numberArray.CopyTo(sorted, 0);

        List<double> results = new List<double>();
        int max = 0;
        double current = sorted[0];
        int num = 0;
        foreach (double i in sorted)
        {
            if (i == current) num++;
            else
            {
                if (num > max)
                {
                    results = new List<double>() { current };
                    max = num;
                }
                else if (num == max)
                {
                    results.Add(current);
                }
                num = 1;
                current = i;
            }
        }

        return results;
    }



    //static double Mode(double[] numberArray)
    //{
    //    if (numberArray.Length == 0)
    //        throw new ArgumentException("Маccив не может быть пустым");

    //    Dictionary<double, int> dict = new Dictionary<double, int>();
    //    foreach (double elem in numberArray)
    //    {
    //        if (dict.ContainsKey(elem))
    //            dict[elem]++;
    //        else
    //            dict[elem] = 1;
    //    }
    //    List<double> result = new List<double>();
    //    int maxCount = 0;
    //    foreach(double elem in dict.Keys)
    //    {
    //        if (dict[elem] > maxCount)
    //        {
    //            maxCount = dict[elem];
    //            result.Add(maxCount);
    //        }
    //    }
    //    return result;
    //}

    static void printArray(double[] numberArray)
    {
        for (int indx = 0; indx < numberArray.Length; indx++)
        {
            String separator = (indx < numberArray.Length - 1) ? ", " : "";
            Console.Write(numberArray[indx] + separator);
        }
        Console.WriteLine();
    }
    static void Main()
    {
        Console.WriteLine("\n***** Quick Sorting *****\n");
        double[] numberArray = { 5.0, 8.0, 7.0, -1.0, 2.0, 3.0, 55.51, 55.50, 5.0, 3.0 };
        Console.WriteLine("\n*** Recursive Quick Sort ***\n");
        Console.WriteLine("\nBefore Sorting-->:\n");
        printArray(numberArray);
        recQuickSort(numberArray);
        Console.WriteLine("\nAfter Sorting-->:\n");
        printArray(numberArray);
        Console.WriteLine("\nAfter Finding Mode-->:\n");
        Console.WriteLine(Mode(numberArray));
        Console.ReadKey();
    }
}