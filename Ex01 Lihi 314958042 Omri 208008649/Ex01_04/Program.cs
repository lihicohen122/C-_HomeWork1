using System;

namespace Ex01_04
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
            Console.WriteLine("Please enter a 12 character string (you can mix between letters and numbers as you please)");
            string userInputStr = "";
            bool isValidInput = false;

            while(!isValidInput)
            {
                userInputStr = Console.ReadLine();

                if(checkUserInput(userInputStr))
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    Console.WriteLine("Please enter a 12 character string");
                }
            }

            return userInputStr;
        }

        private static bool checkUserInput(string i_UserInputStr)
        {
            bool isValidInput = i_UserInputStr.Length == 12;
            return isValidInput;
        }

        private static void printResults(string i_UserInputStr)
        {
            bool isOnlyNumbers = checkOnlyNumbers(i_UserInputStr);
            bool isOnlyEnglish = checkOnlyEnglish(i_UserInputStr);

            Console.WriteLine(
                isPalindromeRecursive(i_UserInputStr)
                    ? "The string is a palindrome"
                    : "The string is not a palindrome");
            if(isOnlyNumbers)
            {
                Console.WriteLine(
                    checkDivisionByThree(i_UserInputStr)
                        ? "The number is divisible by 3"
                        : "The number is not divisible by 3");
            }

            if(isOnlyEnglish)
            {
                Console.WriteLine($"The number of uppercase letters: {calcNumOfUppercase(i_UserInputStr)}");
                Console.WriteLine(
                    checkAlphabeticalOrder(i_UserInputStr)
                        ? "The string is ordered alphabetically"
                        : "The string is not ordered alphabetically");
            }

        }

        private static bool isPalindromeRecursive(string i_UserInputStr)
        {
            string userInputLowercase = i_UserInputStr.ToLower();
            bool checkLengthOfStr = (userInputLowercase.Length <= 1);

            if(checkLengthOfStr)
            {
                return true;
            }

            bool isEqual = userInputLowercase[0].Equals(userInputLowercase[userInputLowercase.Length - 1]);
            bool recursionStatement =
                isPalindromeRecursive(userInputLowercase.Substring(1, userInputLowercase.Length - 2));

            return isEqual && recursionStatement;
        }

        private static bool checkOnlyNumbers(string i_UserInputStr)
        {
            bool isOnlyNumbers = true;

            foreach(char character in i_UserInputStr)
            {
                if(!char.IsDigit(character))
                {
                    isOnlyNumbers = false;
                }
            }

            return isOnlyNumbers;
        }

        private static bool checkOnlyEnglish(string i_UserInputStr)
        {
            bool isOnlyEnglish = false;

            foreach(char character in i_UserInputStr)
            {
                if(((character >= 65) && (character <= 90)) || ((character >= 97) && (character <= 122)))
                {
                    isOnlyEnglish = true;
                }
            }

            return isOnlyEnglish;
        }

        private static bool checkDivisionByThree(string i_UserInputStr)
        {
            int.TryParse(i_UserInputStr, out int oUserInputInt);
            return (oUserInputInt % 3 == 0);
        }

        private static int calcNumOfUppercase(string i_UserInputStr)
        {
            int numOfUppercaseLetters = 0;

            foreach(char character in i_UserInputStr)
            {
                if(char.IsUpper(character))
                {
                    numOfUppercaseLetters++;
                }
            }

            return numOfUppercaseLetters;
        }

        private static bool checkAlphabeticalOrder(string i_UserInputStr)
        {
            bool isAlphabeticalOrder = true;
            string userInputLowercase = i_UserInputStr.ToLower();

            for(int i = 0; i < userInputLowercase.Length - 1; i++)
            {
                if(userInputLowercase[i] > userInputLowercase[i + 1])
                {
                    isAlphabeticalOrder = false;
                    break;
                }
            }

            return isAlphabeticalOrder;
        }
    }
}
