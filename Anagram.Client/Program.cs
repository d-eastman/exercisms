using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AL = Anagram.Library;

namespace Anagram.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            AL.Anagram a = new AL.Anagram("word");
            var b = a.Match(new[] { "word", "drow", "xyz"});

            var detector = new AL.Anagram("master");
            var words = new[] { "stream", "pigeon", "maters" };
            var results = detector.Match(words);

            AL.Anagram bad = new AL.Anagram("  "); //Exception causing

        }
    }
}
