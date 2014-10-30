using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WordCount.Library
{
    public class Phrase
    {
        private string _Phrase;

        public Phrase(string phrase)
        {
            _Phrase = phrase;
        }

        public Dictionary<string, int> WordCount()
        {
            Dictionary<string, int> ret = new Dictionary<string, int>();

            string[] words = Regex.Matches(_Phrase.ToLower(), "([a-z'0-9]+)").Cast<Match>().Select(x => x.Value).ToArray();

            for (int i = 0; i < words.Length; i++)
            {
                while (words[i].StartsWith("'")) words[i] = words[i].Substring(1);
                while (words[i].EndsWith("'")) words[i] = words[i].Substring(0, words[i].Length - 1);
            }

            return (from w in words.Where(x => !String.IsNullOrWhiteSpace(x))
                    group w by w into g
                    orderby g.Key
                    select new KeyValuePair<string, int>(g.Key, g.Count())
                    ).ToDictionary(x => x.Key, y => y.Value);
        }
    }
}
