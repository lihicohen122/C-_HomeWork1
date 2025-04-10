using System;

namespace Ex01_01
{
    public class Program
    {
        public const int k_ArraySize = 4;
        public static void Main()
        {
            startApp();

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
            

            for(int i = 0; i < i_BinaryString.Length; i++)
            {
                int bitValue=i_BinaryString[i]-'0';
                currentOutput += bitValue * (int)Math.Pow(2, i);
            }

            return currentOutput;
        }

        private static void printResults(int[] i_DecimalNumberArray, string[] i_BinaryNumberStringArray)
        {
            //sortAndPrintArray(i_DecimalNumberArray); //Omri
            //calculateAndPrintAverage(i_DecimalNumberArray); //Lihi
            //longestSequenceOfOnes(i_BinaryNumberStringArray); //Omri
            //countNumberOfFlips(i_BinaryNumberStringArray); //Lihi
            //numberWithMostOnes(i_BinaryNumberStringArray); //Omri
            //totalNumberOfOnes(i_BinaryNumberStringArray); //Lihi 
        }
    }
}
