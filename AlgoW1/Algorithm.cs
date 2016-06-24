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
            //return new SortAndCount() { numberOfInversion = 0, sortedSubArray = new int[1] };
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

                if (firstIndex + 1 <= firstArray.sortedSubArray.Length && firstArray.sortedSubArray[firstIndex] < secondArray.sortedSubArray[secondIndex])
                {

                    result.sortedSubArray[mergedArrayIndex] = firstArray.sortedSubArray[firstIndex];
                    if (firstIndex + 1 < firstLength) firstIndex++;
                    mergedArrayIndex++;
                    //if (firstIndex+1 > firstArray.sortedSubArray.Length) {
                    //    Array.Copy(secondArray.sortedSubArray, secondIndex, result.sortedSubArray, mergedArrayIndex, secondArray.sortedSubArray.Length - secondIndex - 1);
                    //    return result; 
                    //};
                }

                else
                {
                    //not sorted
                    result.sortedSubArray[mergedArrayIndex] = secondArray.sortedSubArray[secondIndex];
                    //think before incrementing
                    if (firstIndex != firstLength)
                    {
                        result.numberOfInversion += (firstLength - firstIndex);


                    }
                    if (secondIndex + 1 < secondLength) secondIndex++;
                    mergedArrayIndex++;
                    //if (secondIndex + 1 > secondArray.sortedSubArray.Length)
                    //{
                    //    Array.Copy(firstArray.sortedSubArray, firstIndex, result.sortedSubArray, mergedArrayIndex, firstArray.sortedSubArray.Length - firstIndex - 1);
                    //    return result;
                    //}

                }
                //need to check for empty array to terminate
                i++;
            }

            return result;

        }

    }
}
