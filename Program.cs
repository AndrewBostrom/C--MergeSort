using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputList = new List<int>();
            Console.WriteLine("Enter ints to be sorted, enter string to quit: ");

            while (true)
            {
                int i;
                string num = Console.ReadLine();
                if (Int32.TryParse(num, out i))
                {
                    inputList.Add(i);
                }
                else
                {
                    Console.WriteLine();
                    break;
                }
            }

            int[] inputArray = inputList.ToArray();

            PrintArray(inputArray);
            Sort(inputArray);
            PrintArray(inputArray);
            Console.ReadLine();

        }
        static void Sort(int[] inputArray)
        {
            if (inputArray.Length <= 1)
            {
                return;
            }
            int midpoint = (inputArray.Length / 2);
            int[] leftArray = new int[midpoint];
            int[] rightArray = new int[inputArray.Length - midpoint];

            for (int i = 0; i < midpoint; i++)
            {
                leftArray[i] = inputArray[i];
            }
            for (int i = 0; i < (inputArray.Length - midpoint); i++)
            {
                rightArray[i] = inputArray[midpoint + i];
            }

            Sort(leftArray);
            Sort(rightArray);
            Merge(leftArray, rightArray, inputArray);
        }
        static void Merge(int[] leftArray, int[] rightArray, int[] outputArray)
        {
            int leftStart = 0;
            int rightStart = 0;

            for (int outputIndex = 0; outputIndex < outputArray.Length; outputIndex++)
            {
                if (leftStart >= leftArray.Length)
                {
                    outputArray[outputIndex] = rightArray[rightStart++];
                }

                else if (rightStart >= rightArray.Length)
                {
                    outputArray[outputIndex] = leftArray[leftStart++];
                }

                else if (leftArray[leftStart] <= rightArray[rightStart])
                {
                    outputArray[outputIndex] = leftArray[leftStart++];
                }

                else
                {
                    outputArray[outputIndex] = rightArray[rightStart++];
                }
            }
        }
        static void PrintArray(int[] inputArray)
        {
            foreach (int i in inputArray)
            {
                if (inputArray[inputArray.Length - 1] == i)
                {
                    Console.Write(i);
                }
                else
                {
                    Console.Write(i + ", ");
                }
            }
            Console.WriteLine();
        }
    }
}
