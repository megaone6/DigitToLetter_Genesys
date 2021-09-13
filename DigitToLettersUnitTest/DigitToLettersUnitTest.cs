using Microsoft.VisualStudio.TestTools.UnitTesting;
using DigitToLetters;
using System.Collections.Generic;
using System;

namespace DigitToLettersUnitTest
{
    [TestClass]
    public class DigitToLettersUnitTest
    {
        private DigitToLetter dtl;
        private List<String> combinations;
        private Random rnd;

        [TestInitialize]
        public void Initialize()
        {
            rnd = new Random();
        }

        [TestMethod]
        public void TestMethodEmpty() // testing the class with an empty string as parameter
        {
            dtl = new DigitToLetter(""); // constructor with empty string as parameter
            Assert.AreEqual("", dtl.Digits); // checks that the parameter and the actual field in the class are equal
            combinations = dtl.GetCombinationsSorted();
            Assert.AreEqual(0,combinations.Count); // checks that the number of elements in the list of combinations is correct
        }

        [TestMethod]
        public void TestMethodInvalidInput() // testing the class with an invalid string as parameter (same as empty string)
        {
            dtl = new DigitToLetter("ad231x"); // constructor with invalid string as parameter
            Assert.AreEqual("", dtl.Digits);
            combinations = dtl.GetCombinationsSorted();
            Assert.AreEqual(0, combinations.Count);
        }

        [TestMethod]
        public void TestMethodWithoutSorting() // testing the class with a valid, non-empty string as parameter without sorting
        {
            dtl = new DigitToLetter("247"); // constructor with valid, non-empty string as parameter
            Assert.AreEqual("247", dtl.Digits);
            combinations = dtl.GetCombinations();
            Assert.AreEqual(36, combinations.Count);
            // randomly choosing 3 characters that make up a String which is surely in the list of combinations
            char[] first = { 'a', 'b', 'c' };
            char[] second = { 'g', 'h', 'i' };
            char[] third = { 'p', 'q', 'r', 's' };
            char[] chars = { first[rnd.Next(0, first.Length)], second[rnd.Next(0, second.Length)], third[rnd.Next(0, third.Length)] };
            String digits = new String(chars);
            CollectionAssert.Contains(combinations, digits); // checks that the list contains the randomly generated String
            digits += 'e';
            CollectionAssert.DoesNotContain(combinations, digits); // checks that the list does not contain the prior String with an 'e' added to the end of it
        }

        [TestMethod]
        public void TestMethodWithSorting() // testing the class with a valid, non-empty string as parameter with sorting
        {
            dtl = new DigitToLetter("3858");
            Assert.AreEqual("3858", dtl.Digits);
            combinations = dtl.GetCombinationsSorted();
            Assert.AreEqual(81, combinations.Count);
            char[] first = { 'd', 'e', 'f' };
            char[] second = { 't', 'u', 'v' };
            char[] third = { 'j', 'k', 'l'};
            char[] fourth = second;
            char[] chars = { first[rnd.Next(0, first.Length)], second[rnd.Next(0, second.Length)], third[rnd.Next(0, third.Length)], fourth[rnd.Next(0, fourth.Length)] };
            String digits = new String(chars);
            CollectionAssert.Contains(combinations, digits);
            digits += 'e';
            CollectionAssert.DoesNotContain(combinations, digits);
            // the tests below check that the following strings are on the correct index of the list
            Assert.AreEqual(combinations.IndexOf("dtjt"), 0);
            Assert.AreEqual(combinations.IndexOf("fvlv"), 80);
            Assert.AreEqual(combinations.IndexOf("dvku"), 22);
        }
    }
}
