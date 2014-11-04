using System;
using System.Collections.Generic;
using System.Linq;

namespace Anagram.Library
{
    public class Anagram
    {
        /// <summary>
        /// The base word that is being tested for anagram matches.  Can only be set internally (in the constructor).
        /// </summary>
        protected string BaseWord { get; private set; }

        /// <summary>
        /// Constructor that takes the base word and does some simple validation.
        /// Throws an ArgumentException if base word is null, empty, or all whitespace.
        /// </summary>
        /// <param name="baseWord">Word that is being tested for anagram matches</param>
        public Anagram(string baseWord)
        {
            if (String.IsNullOrWhiteSpace(baseWord))
                throw new ArgumentException("Anagram word is null, empty or whitespace."); //Throw exception if nothing to work with

            BaseWord = baseWord;
        }

        /// <summary>
        /// Determine which words are anagrams of the base word passed in the constructor.  
        /// In determining anagram matches, ignore case and ignore words that are the base word itself.
        /// Return the array in sorted order even though that wasn't an explicit requirement because a few tests fail otherwise.
        /// </summary>
        /// <param name="testWords">The words to test against the base word</param>
        /// <returns>The words in the input array of test words that are anagrams of the base word</returns>
        public string[] Match(string[] testWords)
        {
            List<string> retList = new List<string>(); //Initialize list to hold return values

            string sortedBaseWord = sortCharsInString(BaseWord);

            foreach (string tw in testWords)
            {
                if (!String.IsNullOrWhiteSpace(tw) && tw.ToLower() != BaseWord.ToLower()) // && tw.Length == BaseWord.Length)
                {
                    //If test word is not the base word and the two words are the same length, then compare the compositions
                    //if (CharIntDictionariesAreIdentical(baseComposition, GetWordComposition(tw)))
                    if (sortCharsInString(tw).Equals(sortedBaseWord))
                    {
                        retList.Add(tw); //Words are anagrams, so add to return list of words
                    }
                }
            }

            return retList.OrderBy(x => x).ToArray(); //Return matches as sorted string array
        }

        /// <summary>
        /// Sort the chars in a string alphabetically in a case-insensitive way and return those chars as a new string
        /// </summary>
        /// <param name="text">String to be sorted</param>
        /// <returns>Sorted string of characters</returns>
        protected string sortCharsInString(string text)
        {
            char[] chars = text.ToLower().ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }
    }
}
