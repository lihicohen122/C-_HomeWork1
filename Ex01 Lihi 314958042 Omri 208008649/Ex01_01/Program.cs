using System;
using System.Text;

namespace Ex01_01
{
    public class Program
    {
        public const int k_ArraySize = 4;

        public static void Main()
        {
            startApp();
            Console.ReadLine();
        }

        private static void startApp()
        {
            
            (string[] binaryNumberStringArray, int[] decimalNumberArray) = getUserInput();
            printResults(decimalNumberArray, binaryNumberStringArray);
        }

        private static (string[], int[]) getUserInput()
        {

            Console.WriteLine("Please enter four binary numbers, each exactly seven bits long.");

            int[] decimalNumberArray = new int[k_ArraySize];
            string[] binaryNumberStringArray = new string[k_ArraySize];
            int currentIteration = 0;

            while(currentIteration < k_ArraySize)
            {
                string currentInput = Console.ReadLine();
                bool isValidInput = checkInput(currentInput);

                if(isValidInput)
                {
                    binaryNumberStringArray[currentIteration] = currentInput;
                    decimalNumberArray[currentIteration] = convertToDecimal(currentInput);
                    currentIteration++;
                }
                else
                {
                    Console.WriteLine("Invalid input! Try again.");
                }

            }

            return (binaryNumberStringArray, decimalNumberArray);
        }

        private static bool checkInput(string i_BinaryString)
        {
            bool isValidLength = checkInputLength(i_BinaryString);
            bool isValidCharacters = checkInputCharacters(i_BinaryString);
            return isValidCharacters && isValidLength;
        }

        private static bool checkInputCharacters(string i_BinaryString)
        {
            bool isBinary = true;

            foreach(char bitCharacter in i_BinaryString)
            {
                if(bitCharacter != '0' && bitCharacter != '1')
                {
                    isBinary = false;
                    break; 
                }
            }

            return isBinary;
        }

        private static bool checkInputLength(string i_BinaryString)
        {
            bool isValidLength = true;

            int currentLength = i_BinaryString.Length;
            if(currentLength != 7)
            {
                isValidLength = false;
            }

            return isValidLength;
        }

        private static int convertToDecimal(string i_BinaryString)
        {
            int currentOutput = 0;
            int length = i_BinaryString.Length;

            for(int i = 0; i < length; i++)
            {
                int bitValue = i_BinaryString[i] - '0';
                currentOutput += bitValue * (int)Math.Pow(2, length - 1 - i); 
            }

            return currentOutput;
        }

        private static void printResults(int[] i_DecimalNumberArray, string[] i_BinaryNumberStringArray)
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine(printDescendingArray(i_DecimalNumberArray));
            output.AppendLine(calculateAndPrintAverage(i_DecimalNumberArray));
            output.AppendLine(longestSequenceOfOnes(i_BinaryNumberStringArray));
            output.AppendLine(countNumberOfFlips(i_BinaryNumberStringArray));
            output.AppendLine(numberWithMostOnes(i_BinaryNumberStringArray));
            output.AppendLine(totalNumberOfOnes(i_BinaryNumberStringArray));
            Console.WriteLine(output.ToString());
        }

        private static string printDescendingArray(int[] i_DecimalNumberArray)
        {
            sortInDescendingOrder(i_DecimalNumberArray, 0, i_DecimalNumberArray.Length - 1);
            StringBuilder result = new StringBuilder("Sorted array (descending order):");

            foreach(int number in i_DecimalNumberArray)
            {
                result.Append($" {number}");
            }

            return result.ToString();
        }

        private static void sortInDescendingOrder(int[] i_DecimalNumberArray, int i_Left, int i_Right)
        {
            if(i_Left < i_Right)
            {
                int middleOfArray = (i_Left + i_Right) / 2;

                sortInDescendingOrder(i_DecimalNumberArray, i_Left, middleOfArray);
                sortInDescendingOrder(i_DecimalNumberArray, middleOfArray + 1, i_Right);
                merge(i_DecimalNumberArray, i_Left, middleOfArray, i_Right);
            }
        }

        private static void merge(int[] i_DecimalNumberArray, int i_Left, int i_Middle, int i_Right)
        {
            int leftLength = i_Middle - i_Left + 1;
            int rightLength = i_Right - i_Middle;
            int[] leftArray = new int[leftLength];
            int[] rightArray = new int[rightLength];

            for(int i = 0; i < leftLength; i++)
            {
                leftArray[i] = i_DecimalNumberArray[i_Left + i];
            }
            for(int j = 0; j < rightLength; j++)
            {
                rightArray[j] = i_DecimalNumberArray[i_Middle + 1 + j];
            }

            int leftIndex = 0;
            int rightIndex = 0;
            int mergedIndex = i_Left;

            while(leftIndex < leftLength && rightIndex < rightLength)
            {
                int max = Math.Max(leftArray[leftIndex], rightArray[rightIndex]);

                if(max == leftArray[leftIndex])
                {
                    i_DecimalNumberArray[mergedIndex++] = leftArray[leftIndex++];
                }
                else
                {
                    i_DecimalNumberArray[mergedIndex++] = rightArray[rightIndex++];
                }
            }

            while(leftIndex < leftLength)
            {
                i_DecimalNumberArray[mergedIndex++] = leftArray[leftIndex++];
            }

            while(rightIndex < rightLength)
            {
                i_DecimalNumberArray[mergedIndex++] = rightArray[rightIndex++];
            }
        }

        private static string calculateAndPrintAverage(int[] i_DecimalNumberArray)
        {
            float sum = 0;

            foreach(int number in i_DecimalNumberArray)
            {
                sum += number;
            }

            float average = sum / i_DecimalNumberArray.Length;

            return $"Average: {average}";
        }

        private static string longestSequenceOfOnes(string[] i_BinaryNumberStringArray)
        {
            int maxSequenceLength = 0;
            string stringWithLongestOnes = "";

            foreach(string binaryNumber in i_BinaryNumberStringArray)
            {
                int currentCount = 0;
                int longestInCurrent = 0;

                foreach(char currentBit in binaryNumber)
                {
                    if(currentBit == '1')
                    {
                        currentCount++;
                        longestInCurrent = Math.Max(longestInCurrent, currentCount);
                    }
                    else
                    {
                        currentCount = 0;
                    }
                }
                
                if(longestInCurrent > maxSequenceLength)
                {
                    maxSequenceLength = longestInCurrent;
                    stringWithLongestOnes = binaryNumber;
                }
            }

            return $"Longest sequence of 1's: {maxSequenceLength} (from string: {stringWithLongestOnes})";
        }

        private static string countNumberOfFlips(string[] i_BinaryNumberStringArray)
        {
            StringBuilder result = new StringBuilder("Number of flips: \n");

            foreach (string binaryNumber in i_BinaryNumberStringArray)
            {
                int numOfFlips = 0;

                for(int i = 1; i < binaryNumber.Length; i++)
                {
                    if(binaryNumber[i] != binaryNumber[i - 1])
                    {
                        numOfFlips++;
                    }
                }

                result.AppendLine($"{binaryNumber} has {numOfFlips} flips");
            }

            return result.ToString().TrimEnd();
        }

        private static string numberWithMostOnes(string[] i_BinaryNumberStringArray)
        {
            int maxNumOfOnes = 0;
            int indexWithMostOnes = 0;

            for(int i = 0; i < i_BinaryNumberStringArray.Length ; i++)
            {
                int currentOnesCount = 0;

                foreach(char currentBit in i_BinaryNumberStringArray[i])
                {
                    if(currentBit == '1')
                    {
                        currentOnesCount++;
                    }
                }

                if(currentOnesCount > maxNumOfOnes)
                {
                    maxNumOfOnes = currentOnesCount;
                    indexWithMostOnes = i;
                }
            }

            int decimalNumberWithMostOnes = convertToDecimal(i_BinaryNumberStringArray[indexWithMostOnes]); 
            //omri delete this after you read: I used convert to decimal because I merge sorted the decimal array (in order to not make a copy)
            //and now the indexes in the binary array and decimal array aren't synced. 
            //If you have a better solution - please let me know!
            return $"The number with the most 1's is {decimalNumberWithMostOnes} (in binary {i_BinaryNumberStringArray[indexWithMostOnes]})";
        }

        private static string totalNumberOfOnes(string[] i_BinaryNumberStringArray)
        {
            int totalNumberOfOnes = 0;

            foreach(string binaryNumber in i_BinaryNumberStringArray)
            {
                foreach(char currentBit in binaryNumber)
                {
                    if(currentBit == '1')
                    {
                        totalNumberOfOnes++; 
                    }
                }
            }

            return $"The total number of 1's is {totalNumberOfOnes}";
        }
    }
}
