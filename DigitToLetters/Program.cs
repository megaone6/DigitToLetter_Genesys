using System;
using System.Collections.Generic;
using System.Linq;

namespace DigitToLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            String digits;
            do // if the input is invalid, the loop continues and asks for the input again
            {
                Console.WriteLine("What is your input? Constraints: length of 0-4, only contains digits from 2-9");
                digits = Console.ReadLine();
                if (digits.Length < 0 || digits.Length > 4 || !digits.All(char.IsDigit) || digits.Contains('1') || digits.Contains('0'))
                    Console.WriteLine("Input does not meet the requirements! (length of 0-4, only contains digits from 2-9)\n");
            } while (digits.Length < 0 || digits.Length > 4 || !digits.All(char.IsDigit) || digits.Contains('1') || digits.Contains('0'));

            DigitToLetter dtl1 = new DigitToLetter(digits);
            //List<String> combinations1 = dtl1.GetCombinations();
            List<String> combinations1 = dtl1.GetCombinationsSorted();
            Console.WriteLine("Number of combinations: " + combinations1.Count);
            combinations1.ForEach(Console.WriteLine);

            Console.WriteLine("---------------------------------------------------------------------------");

            DigitToLetter dtl2 = new DigitToLetter("3974");
            //List<String> combinations2 = dtl2.GetCombinations();
            List<String> combinations2 = dtl2.GetCombinationsSorted();
            Console.WriteLine("Number of combinations: " + combinations2.Count);
            combinations2.ForEach(Console.WriteLine);

            Console.WriteLine("---------------------------------------------------------------------------");

            DigitToLetter dtl3 = new DigitToLetter("184a9e");
            //List<String> combinations3 = dtl3.GetCombinations();
            List<String> combinations3 = dtl3.GetCombinationsSorted();
            Console.WriteLine("Number of combinations: " + combinations3.Count);
            combinations3.ForEach(Console.WriteLine);

            Console.WriteLine("Press any key to quit the program!");
            Console.ReadKey();
        }
    }
}
