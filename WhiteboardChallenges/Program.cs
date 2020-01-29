using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteboardChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] indices = TargetNumber(new int[] { 5, 25, 30, 59 }, 55);
            Console.WriteLine(PrintIndices(indices));

            Console.WriteLine(CheckForPalindrome("nurses run"));

            Console.WriteLine($"Reversed reciprocal: {ReverseReciprocal(17)}");

            Console.WriteLine($"Total turn to target: {TurnsToTargetCombo(new int[] { 3, 8, 9, 3 }, new int[] { 5, 2, 9, 6})}");

            Console.WriteLine(SequenceOfIncrementing( new List<int> {5,7,3,8,6}));
            Console.WriteLine(SequenceOfIncrementing( new List<int> {17,15,20,19,21,16,18}));
            Console.WriteLine(SequenceOfIncrementing( new List<int> {6, 2, 8, 4}));

            int[] countOfNums = CountOfPositiveAndNegative(new int[] { 7, 9, -3, -32, 0, -1, 36, 95, -14, -99, 21 });
            Console.WriteLine(PrintArray(countOfNums));

            Console.WriteLine(HighestAndLowest("3 9 2 1 4 8 10 2"));
            Console.WriteLine();

            int numToCheckForHappy1 = 11;
            int numToCheckForHappy2 = 19;
            Console.WriteLine($"Is {numToCheckForHappy1} Happy?: {HappyNumberTest(numToCheckForHappy1)}");
            Console.WriteLine($"Is {numToCheckForHappy2} Happy?: {HappyNumberTest(numToCheckForHappy2)}");
            Console.WriteLine();

            Console.WriteLine(CheckValidEmailAddress("bill@gmail.com"));
            Console.WriteLine(CheckValidEmailAddress("bi.ll@dd.com"));
            Console.WriteLine(CheckValidEmailAddress("r@outlook.gov"));
            Console.WriteLine(CheckValidEmailAddress("@frog.mil"));
            Console.WriteLine(CheckValidEmailAddress("bi.ll@frog.edu"));
            Console.WriteLine(CheckValidEmailAddress("bi.ll@frog.org"));
            Console.WriteLine(CheckValidEmailAddress("bi.ll@frog.fish"));

            Console.WriteLine(AlphabetPosition("abc!"));
            Console.WriteLine(AlphabetPosition("coding is fun"));
            Console.WriteLine(AlphabetPosition("I LIKE POTATOES"));
            Console.ReadLine();

        }

        //Checks to see if any two numbers in the numbers array add up to the target
        public static int[] TargetNumber(int[] numbers, int target)
        {
            int[] indices = new int[2];
            int current;

            for(int i = 0; i < numbers.Length; i++)
            {
                current = numbers[i];
                for(int j = 0; j < numbers.Length; j++)
                {
                    if (current + numbers[j] == target)
                    {
                        indices[0] = i;
                        indices[1] = j;
                        return indices;
                    }
                }
            }
            return indices;
        }

        //To print the index values of the array numbers that add to the target number for the target number method
        public static string PrintIndices(int[] indices)
        {
            string printedNums;

            if(indices[0] == indices[1])
            {
                printedNums = "None of the numbers added to the target..";
            }
            else
            {
                printedNums = $"{indices[0].ToString()} , {indices[1].ToString()}";
            }

            return printedNums;
        }

        public static string ReverseString(string wordToReverse)
        {
            string reversedWord = "";

            for(int i = wordToReverse.Length - 1; i >= 0; i--)
            {
                reversedWord += wordToReverse[i];
            }

            return reversedWord;
        }

        public static string CheckForPalindrome(string wordToCheck)
        {
            if(ReverseString(wordToCheck).Replace(" ", String.Empty) == wordToCheck.Replace(" ", String.Empty))
            {
                return $"{wordToCheck} is a palindrome!";
            }
            else
            {
                return $"{wordToCheck} is not a palindrome...";
            }
        }

        //reverses a number, then does the reciprocal
        public static double ReverseReciprocal(int num)
        {
            string numberToReverse = num.ToString();
            string reversedNum = ReverseString(numberToReverse);

            double reverseReciprocal = 1 / Convert.ToDouble(reversedNum);

            return reverseReciprocal;
        }

        //A 4 digit rolling lock, this method figures out the minimum turns from a current position to the target unlocked position
        public static int TurnsToTargetCombo(int[] current, int[] target)
        {
            int turns;
            int totalTurns = 0;

            for(int i = 0; i < current.Length; i++)
            {
                turns = Math.Abs(current[i] - target[i]);
                if(turns > 5)
                {
                    turns = 10 - current[i] + target[i];
                }
                totalTurns += turns;
            }

            return totalTurns;
        }

        public static bool SequenceOfIncrementing(List<int> numbers)
        {
            bool increments = true;
            numbers.Sort();

            int incrementValue = numbers[1] - numbers[0];

            for(int i = 0; i < numbers.Count - 1; i++)
            {
                if(!(numbers[i + 1] == numbers[i] + incrementValue))
                {
                    increments = false;
                    break;
                }
            }
            return increments;
        }

        public static string PrintArray(int[] array)
        {
            string arrayString = "";

            foreach(int item in array)
            {
                arrayString += item.ToString() + " ";
            }

            return arrayString;
        }

        //Counts how many positive and negative numbers are in an array (ignore zero)
        public static int[] CountOfPositiveAndNegative(int[] numbers)
        {
            int positiveCount = 0;
            int negativeCount = 0;

            int[] countOfNums = new int[2];

            foreach(int num in numbers)
            {
                if (num == 0)
                {
                    continue;
                }
                else if(num > 0)
                {
                    positiveCount++;
                }
                else
                {
                    negativeCount++;
                }
            }

            countOfNums[0] = positiveCount;
            countOfNums[1] = negativeCount;

            return countOfNums;
        }

        public static int[] TurnStringOfNumsToArray(string toChange)
        {
            string[] stringValues = toChange.Split(' ');
            int[] numArrayFromString = new int[stringValues.Length];

            for(int i = 0; i < stringValues.Length; i++)
            {
                numArrayFromString[i] = Int32.Parse(stringValues[i]);
            }

            return numArrayFromString;
        }

        //Finds the highest and lowest values in an array
        public static string HighestAndLowest(string numsToCheck)
        {
            int[] nums = TurnStringOfNumsToArray(numsToCheck);

            int highest = nums[0];
            int lowest = nums[0];

            for (int i = 0; i < nums.Length; i++)
            {
                if(nums[i] > highest)
                {
                    highest = nums[i];
                }
                if(nums[i] < lowest)
                {
                    lowest = nums[i];
                }
            }

            string highestAndLowest = $"Highest: {highest}, Lowest: {lowest}";
            return highestAndLowest;
        }

        public static bool HappyNumberTest(double number)
        {
            List<double> checkedNums = new List<double>();

            while ((number > 1) && !(checkedNums.Contains(number)))
            {
                Console.WriteLine(number);
                checkedNums.Add(number);
                number = CheckForHappy(number);
            }
            return (number == 1);
        }

        public static double CheckForHappy(double number)
        {
            double total = 0;
            while (number >= 1)
            {
                total += Math.Pow(number % 10, 2);
                number = Math.Floor(number / 10);
            }
            return total;
        }

        public static bool CheckValidEmailAddress(string email)
        {
            string[] topLevelDomains = new string[] { "com", "gov", "net", "org", "mil", "edu" };

            if(email.Contains("@") && email.Contains("."))
            {
                string[] emailSplit = email.Split('@');
                if (emailSplit[0].Length >= 1&& emailSplit[1].Contains('.'))
                {
                    string[] domainSplit = emailSplit[1].Split('.');
                    if (domainSplit[0].Length >= 1 && topLevelDomains.Contains(domainSplit[1]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //Gives the number position of a letter in the alphabet
        public static string AlphabetPosition(string input)
        {
            string letterPositions = "";
            string withoutSpaces = input.Replace(" ", String.Empty).ToLower();

            for(int i = 0; i < withoutSpaces.Length; i++)
            {
                letterPositions += (withoutSpaces[i] - 96) + " ";
            }

            return letterPositions;
        }
    }
}
