using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoW1
{
    public static class Algorithm
    {
        public static SortAndCount SortAndCountInversion(int[] numbersArray, int length)
        {
            if (length == 0) return null;
            else if (length == 1)
            {
                return new SortAndCount() { sortedSubArray = numbersArray, numberOfInversion = 0 };
            }
            else
            {
                int[] firstHalf = numbersArray.Take(length / 2).ToArray();
                int[] secondHalf = numbersArray.Skip(length / 2).ToArray();
                SortAndCount firstResult = SortAndCountInversion(firstHalf, firstHalf.Length);
                SortAndCount secondResult = SortAndCountInversion(secondHalf, secondHalf.Length);
                SortAndCount splitInversions = CountSplitInversions(firstResult, secondResult);
                return splitInversions;
            }
        }

        public static SortAndCount CountSplitInversions(SortAndCount firstArray, SortAndCount secondArray)
        {
            if (firstArray == null || secondArray == null) return null;
            int firstLength = firstArray.sortedSubArray.Length;
            int secondLength = secondArray.sortedSubArray.Length;
            int totalInts = firstLength + secondLength;
            int firstIndex = 0;
            int secondIndex = 0;
            int mergedArrayIndex = 0;

            SortAndCount result = new SortAndCount();
            //add inversion counts
            result.numberOfInversion = firstArray.numberOfInversion + secondArray.numberOfInversion;
            result.sortedSubArray = new int[firstLength + secondLength];
            for (int i = 0; i < totalInts;)
            {

                if (firstIndex + 1 <= firstArray.sortedSubArray.Length) {
                    if (secondIndex + 1 <= secondArray.sortedSubArray.Length) {
                        if (firstArray.sortedSubArray[firstIndex] < secondArray.sortedSubArray[secondIndex])
                        {
                            result.sortedSubArray[mergedArrayIndex] = firstArray.sortedSubArray[firstIndex];
                            firstIndex++;
                            mergedArrayIndex++;
                        }
                        else {
                            result.sortedSubArray[mergedArrayIndex] = secondArray.sortedSubArray[secondIndex];
                            result.numberOfInversion += (firstLength - firstIndex);
                            secondIndex++;
                            mergedArrayIndex++;
                        } }
                    else
                    {
                        result.sortedSubArray[mergedArrayIndex] = firstArray.sortedSubArray[firstIndex];
                        firstIndex++;
                        mergedArrayIndex++;
                    }
                }
                else {
                    result.sortedSubArray[mergedArrayIndex] = secondArray.sortedSubArray[secondIndex];
                    secondIndex++;
                    mergedArrayIndex++;

                }
                        
                i++;
            }

            return result;

        }

    }
}
