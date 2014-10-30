using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anagram.Library
{
    public class Anagram
    {
        protected string Word { get; private set; }
        protected WordComposition Composition { get; private set; }

        public Anagram(string word)
        {
            Word = word;
            Composition = new WordComposition(word);
        }

        public string[] Match(string[] words)
        {
            List<string> retList = new List<string>();

            foreach (string w in words)
            {
                if (w.ToLower() != Word.ToLower())
                {
                    if (new WordComposition(w).Equals(Composition))
                    {
                        retList.Add(w);
                    }
                }
            }
            return retList.OrderBy(x => x).ToArray(); //Return matches as sorted string array
        }

        public class WordComposition
        {
            public string Word { get; private set; }
            public Dictionary<char, int> Composition { get; private set; }

            public WordComposition(string word)
            {
                Word = word;
                Composition = GetComposition(word);
            }

            protected Dictionary<char, int> GetComposition(string word)
            {
                return (
                            from c in word.ToLower().ToCharArray()
                            group c by c into g
                            orderby g.Key
                            select new { Key = g.Key, Count = g.Count() }
                        ).ToDictionary(x => x.Key, y => y.Count);
            }

            public override bool Equals(object obj)
            {
                WordComposition other = obj as WordComposition;

                //It is not the right kind of object
                if (other == null)
                    return false;

                //Word lengths are different, can't be an anagram
                if (other.Word.Length != this.Word.Length)
                    return false;

                //Number of unique characters is different, can't be an anagram
                if (other.Composition.Keys.Count != this.Composition.Keys.Count)
                    return false;

                char[] thisKeys = this.Composition.Keys.ToArray();
                char[] otherKeys = other.Composition.Keys.ToArray();

                for (int k = 0; k < thisKeys.Length; k++)
                {
                    if (thisKeys[k].Equals(otherKeys[k]))
                    {
                        if (!this.Composition[thisKeys[k]].Equals(other.Composition[otherKeys[k]]))
                            return false; //A value didn't match
                    }
                    else
                    {
                        //A key didn't match
                        return false;
                    }
                }

                //If execution gets to here, then all keys and all values match
                return true;
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }

    }
}
