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
            int[] numbersArray = new int[] { 1, 6, 3, 2, 4, 5 };
                //ArrayFromFile();
            SortAndCount result = Algorithm.SortAndCountInversion(numbersArray, numbersArray.Length);
            Console.WriteLine(result.numberOfInversion);
            Console.ReadKey();
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
