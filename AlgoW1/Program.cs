using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoW1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersArray = ArrayFromFile();
            SortAndCount result = SortAndCountInversion(numbersArray, numbersArray.Length);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        private static SortAndCount SortAndCountInversion(int[] numbersArray, int length)
        {
            if (length == 0) return new SortAndCount() { numberOfInversion = 0, sortedSubArray = new int[1] };
            else            {

                SortAndCount firstResult = SortAndCountInversion(numbersArray.Take(length / 2).ToArray(), length / 2);
                SortAndCount secondResult = SortAndCountInversion(numbersArray.Skip(length / 2).ToArray(), length / 2);
                SortAndCount splitInversions = CountSplitInversions(firstResult, secondResult);
                return splitInversions;
            }
        }

        private static SortAndCount CountSplitInversions(SortAndCount firstArray, SortAndCount secondArray)
        {
            int firstLength = firstArray.sortedSubArray.Length;
            int secondLength = secondArray.sortedSubArray.Length;
            int totalInts = firstLength + secondLength;
            int firstIndex = 0;
            int secondIndex = 0;
           
            SortAndCount result = new SortAndCount();
            result.sortedSubArray = new int[firstLength + secondLength];
            for (int i = 0; i < totalInts;)
            {
                int mergedArrayIndex = 0;
                if (firstArray.sortedSubArray[firstIndex] < secondArray.sortedSubArray[secondIndex])
                {
                    result.sortedSubArray[mergedArrayIndex] = firstArray.sortedSubArray[i];
                    firstIndex++;
                                    }
                else {
                    result.sortedSubArray[mergedArrayIndex] = secondArray.sortedSubArray[secondIndex];
                    result.numberOfInversion += (firstLength - i + 1);
                    secondIndex++;
                }
                i++;
            }

            return result;

        }

        private static int[] ArrayFromFile() {
           
            string[] fileNumbersInString= File.ReadAllLines(@"C:\Users\nmakhmudova\Desktop\Stanford Algorithms\AlgoW1\IntegerArray.txt");
            int length = fileNumbersInString.Length;
            int[] dataFromFile = new int[length];
            for (int i = 0; i < fileNumbersInString.Length; i++) {
                dataFromFile[i] = Convert.ToInt32(fileNumbersInString[i]);
            }           
            return dataFromFile;
        }
    }
}
