using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DigitToLetters
{
    public class DigitToLetter
    {
        private readonly String digits; // String for the input
        public String Digits
        {
            get { return digits; }
        }
        private IEnumerable<String> combinations; // an enumerable type for the combinations of letters

        private readonly ReadOnlyDictionary<char, List<char>> numbersAndLetters; // a read only Dictionary for storing the number-letter combinations

        public DigitToLetter(String digitsInput) // constructor with parameter
        {
            if (digitsInput.Length < 0 || digitsInput.Length > 4 || !digitsInput.All(char.IsDigit) || digitsInput.Contains('1') || digitsInput.Contains('0'))
            {
                Console.WriteLine("Input is invalid! Defaulting to empty string...");
                digits = "";
            }
            else
                digits = digitsInput;

            numbersAndLetters = new ReadOnlyDictionary<char, List<char>>(new Dictionary<char, List<char>>() // initializing the dictionary of number-letter combinations (letters are not in order to prove that the sorting algorithm works)
            {
                { '2', new List<char>() { 'b', 'a', 'c' } },
                { '3', new List<char>() { 'd', 'f', 'e' } },
                { '4', new List<char>() { 'i', 'h', 'g' } },
                { '5', new List<char>() { 'k', 'j', 'l' } },
                { '6', new List<char>() { 'm', 'n', 'o' } },
                { '7', new List<char>() { 's', 'q', 'r', 'p' } },
                { '8', new List<char>() { 't', 'v', 'u' } },
                { '9', new List<char>() { 'w', 'z', 'x', 'y' } },
            });

            if (digits == "")
                combinations = new List<String>();
            else
                combinations = new List<String> { null };
        }

        public List<String> GetCombinations() // this function returns the list of combinations (unsorted)
        {
            List<List<char>> listOfLists = new List<List<char>>(); // initializing an empty list of list of chars

            foreach (char c in digits) // adding the needed lists to the list of lists based on their keys in the dictionary
            {
                listOfLists.Add(numbersAndLetters[c]);
            }
            foreach (List<char> list in listOfLists) // joining the current result with each element of the next list
            {
                combinations = combinations.SelectMany(x => list.Select(y => x + y));
            }

            return combinations.ToList();
        }

        public List<String> GetCombinationsSorted() // this function gets the return value of the getCombinations function and sorts it with the insertion sort algorithm, returning the sorted list
        {
            List<String> combinationList = GetCombinations();
            int i, j;

            for (i = 1; i < combinationList.Count; i++)
            {
                String current = combinationList[i];
                j = i - 1;
                while ((j >= 0) && (combinationList[j].CompareTo(current) > 0))
                {
                    combinationList[j + 1] = combinationList[j];
                    j--;
                }
                combinationList[j + 1] = current;
            }

            return combinationList;
        }
    }
}
