using System;
using NUnit.Framework;
using AL = Anagram.Library;

namespace Anagram.Test
{
    [TestFixture]
    public class AnagramTest
    {
        [Test]
        public void No_matches()
        {
            var detector = new AL.Anagram("diaper");
            var words = new[] { "hello", "world", "zombies", "pants" };
            var results = new string[0];
            Assert.That(detector.Match(words), Is.EqualTo(results));
        }

        [Test]
        public void Detect_simple_anagram()
        {
            var detector = new AL.Anagram("ant");
            var words = new[] { "tan", "stand", "at" };
            var results = new[] { "tan" };
            Assert.That(detector.Match(words), Is.EqualTo(results));
        }

        [Test]
        public void Detect_multiple_anagrams()
        {
            var detector = new AL.Anagram("master");
            var words = new[] { "stream", "pigeon", "maters" };
            var results = new[] { "maters", "stream" };
            Assert.That(detector.Match(words), Is.EqualTo(results));
        }

        [Test]
        public void Does_not_confuse_different_duplicates()
        {
            var detector = new AL.Anagram("galea");
            var words = new[] { "eagle" };
            var results = new string[0];
            Assert.That(detector.Match(words), Is.EqualTo(results));
        }

        [Test]
        public void Identical_word_is_not_anagram()
        {
            var detector = new AL.Anagram("corn");
            var words = new[] { "corn", "dark", "Corn", "rank", "CORN", "cron", "park" };
            var results = new[] { "cron" };
            Assert.That(detector.Match(words), Is.EqualTo(results));
        }

        [Test]
        public void Eliminate_anagrams_with_same_checksum()
        {
            var detector = new AL.Anagram("mass");
            var words = new[] { "last" };
            var results = new string[0];
            Assert.That(detector.Match(words), Is.EqualTo(results));
        }

        [Test]
        public void Eliminate_anagram_subsets()
        {
            var detector = new AL.Anagram("good");
            var words = new[] { "dog", "goody" };
            var results = new string[0];
            Assert.That(detector.Match(words), Is.EqualTo(results));
        }

        [Test]
        public void Detect_anagrams()
        {
            var detector = new AL.Anagram("allergy");
            var words = new[] { "gallery", "ballerina", "regally", "clergy", "largely", "leading" };
            var results = new[] { "gallery", "largely", "regally" };
            Assert.That(detector.Match(words), Is.EqualTo(results));
        }

        [Test]
        public void Anagrams_are_case_insensitive()
        {
            var detector = new AL.Anagram("Orchestra");
            var words = new[] { "cashregister", "Carthorse", "radishes" };
            var results = new[] { "Carthorse" };
            Assert.That(detector.Match(words), Is.EqualTo(results));
        }
    }
}
