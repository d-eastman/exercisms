using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCount.Library
{
    public class Phrase
    {
        /// <summary>
        /// The word phrase to be parsed that's passed in via the constructor and cannot be changed after that.
        /// </summary>
        public string WordPhrase { get; private set; }

        /// <summary>
        /// Construct the object, passing in the phrase.
        /// </summary>
        /// <param name="phrase">String of words</param>
        public Phrase(string phrase)
        {
            WordPhrase = phrase;
        }

        /// <summary>
        /// Break the phrase into unique words and the count of each word and return as a dictionary object with the words (strings)
        /// as the keys and the word counts (ints) as the values.
        /// </summary>
        /// <returns>Unique words and the word count per word in the phrase in the form of a Dictionary<string, int>.</returns>
        public Dictionary<string, int> WordCount()
        {
            //Initialize return object.
            Dictionary<string, int> ret = new Dictionary<string, int>(); 

            //Use simple regex to grab all "words" consisting of alphanumerics plus the apostrophe, and put matches into a string array.
            string[] words = Regex.Matches(WordPhrase.ToLower(), "([a-z'0-9]+)").Cast<Match>().Select(x => x.Value).ToArray();

            //Since I didn't want to write "look around" logic into the regex (too complicated to get just right and maintain),
            //this loop removes all leading and trailing apostrophes, leaving only apostropes that are internal to words.
            //"Words" that consisted only of apostrophes and become empty will be omitted in the next step.  
            //NOTE: this is not going to handle special case words in English that legitimately begin or end in an apostrophe 
            //      (e.g., 'til or Cass'), but none of those cases showed up in the test cases.  Custom logic will need to be added 
            //      if that becomes an issue that needs addressing.
            for (int i = 0; i < words.Length; i++)
            {
                while (words[i].StartsWith("'")) words[i] = words[i].Substring(1);
                while (words[i].EndsWith("'")) words[i] = words[i].Substring(0, words[i].Length - 1);
            }

            //Use LINQ to aggregate the string array of words into a dictionary of words/word counts, omitting the blank items.
            return (from w in words.Where(x => !String.IsNullOrWhiteSpace(x))
                    group w by w into g
                    orderby g.Key
                    select new KeyValuePair<string, int>(g.Key, g.Count())
                    ).ToDictionary(x => x.Key, y => y.Value);
        }
    }
}
