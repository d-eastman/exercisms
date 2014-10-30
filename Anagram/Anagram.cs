using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            var baseComposition = GetWordComposition(BaseWord); //Get our word's composition

            foreach (string tw in testWords)
            {
                if (!String.IsNullOrWhiteSpace(tw) && tw.ToLower() != BaseWord.ToLower() && tw.Length == BaseWord.Length)
                {
                    //If test word is not the base word and the two words are the same length, then compare the compositions
                    if (CharIntDictionariesAreIdentical(baseComposition, GetWordComposition(tw)))
                    {
                        retList.Add(tw); //Words are anagrams, so add to return list of words
                    }
                }
            }

            return retList.OrderBy(x => x).ToArray(); //Return matches as sorted string array
        }

        /// <summary>
        /// Break a word down into a dictionary of sorted unique characters (dictionary keys) and character counts (dictionary values).  
        /// Note: converting ToDictionary does not automatically sort the dictionary entries by key, so that's done in LINQ.
        /// </summary>
        /// <param name="word">Word to decompose</param>
        /// <returns>Dictionary of unique characters in the word and how many times each appears in the word.  Sorted by key.</returns>
        protected Dictionary<char, int> GetWordComposition(string word)
        {
            return (from c in word.ToLower().ToCharArray()
                    group c by c into g
                    orderby g.Key
                    select new KeyValuePair<char, int>(g.Key, g.Count())
                    ).ToDictionary(x => x.Key, y => y.Value);
        }

        /// <summary>
        /// Compare all keys and values of two dictionary objects and return true if everything is exactly
        /// the same, otherwise return false if anything does not match.  Note: returns false if either object is null.
        /// </summary>
        /// <param name="d1">First char-int dictionary object</param>
        /// <param name="d2">Second char-int dictionary object</param>
        /// <returns>True means the dictionary objects have identical keys and values.</returns>
        protected bool CharIntDictionariesAreIdentical(Dictionary<char, int> d1, Dictionary<char, int> d2)
        {
            if (d1 == null || d2 == null)
                return false; //One or both objects are null

            if (d1.Keys.Count != d2.Keys.Count)
                return false; //Number of unique characters is different

            //Get an enumerator for each dictionary
            var e1 = d1.GetEnumerator();
            var e2 = d2.GetEnumerator();

            //Loop through both enumerators in lockstep to compare the key and value of the dictionary entries.
            while (e1.MoveNext())
            {
                e2.MoveNext(); //Move to next element on 2nd dictionary to stay in step with first enumerator
                if (!e1.Current.Key.Equals(e2.Current.Key) || !e1.Current.Value.Equals(e2.Current.Value))
                    return false; //A key or value did not match
            }

            //If execution gets to here, then all keys and all values match
            return true;
        }
    }
}
