using System;
using System.Text;


namespace Ex01_05
{
    public class Program
    {
        public static void Main()
        {
            startApp();
            Console.ReadLine();
        }

        private static void startApp()
        {
            string userInputStr = getUserInput();
            printResults(userInputStr);
        }

        private static string getUserInput()
        {
            string userInputStr = askForInput();
            bool isValidInput = checkValidInput(userInputStr);

            while (!isValidInput)
            {
                userInputStr = askForInput();

                if (checkValidInput(userInputStr))
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }

            return userInputStr;
        }

        private static string askForInput()
        {
            Console.WriteLine("Please enter an 8 digits number");

            string userInputStr = Console.ReadLine();

            return userInputStr;
        }

        private static bool checkValidInput(string i_UserInputStr)
        {
            return (checkOnlyNumbers(i_UserInputStr) && (i_UserInputStr.Length == 8));
        }

        private static bool checkOnlyNumbers(string i_UserInputStr)
        {
            bool isOnlyNumbers = true;

            foreach (char character in i_UserInputStr)
            {
                if (!char.IsDigit(character))
                {
                    isOnlyNumbers = false;
                }
            }

            return isOnlyNumbers;
        }

        private static void printResults(string i_UserInputStr)
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"The number of digits smaller than the first digit: {calcNumberOfSmallerDigits(i_UserInputStr)}");
            output.AppendLine($"The number of digits that are divisible by 3 : {calcNumberOfDivisible(i_UserInputStr)}");
            output.AppendLine($"The difference between the largest digit and the smallest digit: {calcLargestDifference(i_UserInputStr)}");
            output.AppendLine(mostFrequentNumber(i_UserInputStr));
            Console.WriteLine(output.ToString());
        }

        private static int calcNumberOfSmallerDigits(string i_UserInputStr)
        {
            int numberOfSmaller = 0;
            char firstNum = i_UserInputStr[0];

            for(int i = 1; i < i_UserInputStr.Length; i++)
            {
                if(firstNum > i_UserInputStr[i])
                {
                    numberOfSmaller++; 
                }
            }

            return numberOfSmaller; 
        }

        private static int calcNumberOfDivisible(string i_UserInputStr)
        {
            int divisibleCount = 0;

            foreach(char digit in i_UserInputStr)
            {
                bool isDivisibleByThree = checkDivisionByThree(digit);

                if(isDivisibleByThree)
                {
                    divisibleCount++;
                }
            }

            return divisibleCount;
        }

        private static bool checkDivisionByThree(char i_UserInputSingleDigit)
        {
            int.TryParse(i_UserInputSingleDigit.ToString(), out int oUserDigitInt);
            return (oUserDigitInt % 3 == 0);
        }

        private static int calcLargestDifference(string i_UserInputStr)
        {
            int smallestDigit = calcSmallestDigit(i_UserInputStr);
            int largestDigit = calcLargestDigit(i_UserInputStr);

            return (largestDigit - smallestDigit); 
        }

        private static int calcSmallestDigit(string i_UserInputStr)
        {
            int smallestDigit = 10;

            foreach (char letter in i_UserInputStr)
            {
                int.TryParse(letter.ToString(), out int oCurrentDigit);

                if (oCurrentDigit < smallestDigit)
                {
                    smallestDigit = oCurrentDigit;
                }
            }
            return smallestDigit;
        }

        private static int calcLargestDigit(string i_UserInputStr)
        {
            int largestDigit = 0;

            foreach (char digit in i_UserInputStr)
            {
                int.TryParse(digit.ToString(), out int oCurrentDigit);

                if (oCurrentDigit > largestDigit)
                {
                    largestDigit = oCurrentDigit;
                }
            }
            return largestDigit;
        }

        private static string mostFrequentNumber(string i_UserInputStr)
        {
            int maxOccurrences = 0;
            char mostFrequentNum = '\0' ; 

            foreach(char digit in i_UserInputStr)
            {
                int currentNumOccurrences = calcNumOfOccurrences(digit, i_UserInputStr);

                if(currentNumOccurrences > maxOccurrences)
                {
                    maxOccurrences = currentNumOccurrences;
                    mostFrequentNum = digit; 
                }
            }

            return $"The number with the most occurrences: {mostFrequentNum} (it appears: {maxOccurrences} times)";
        }

        private static int calcNumOfOccurrences(char i_DigitToCount, string i_UserInputStr)
        {
            int countCurrentDigit = 0;

            foreach (char currentChar in i_UserInputStr)
            {
                if (currentChar == i_DigitToCount)
                {
                    countCurrentDigit++;
                }
            }

            return countCurrentDigit;
        }

    }
}
