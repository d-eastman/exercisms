using System;
using System.Collections.Generic;
using System.Linq;

namespace Etl.Library
{
    /// <summary>
    /// Static ETL class that contains Transform class method to convert old data structure into new data structure
    /// </summary>
    public static class ETL
    {
        /// <summary>
        /// Transform old system of scrabble score data structure into new system data structure.
        /// 
        /// The old system stored a list of letters per score, for example:
        ///     - 1 point: "A", "E", "I", "O", "U", "L", "N", "R", "S", "T",
        ///     - 2 points: "D", "G",
        ///     - 3 points: "B", "C", "M", "P",
        ///     - 4 points: "F", "H", "V", "W", "Y",
        ///     - 5 points: "K",
        ///     - 8 points: "J", "X",
        ///     - 10 points: "Q", "Z",
        ///
        /// The shiny new scrabble system instead stores the score per letter, which
        /// makes it much faster and easier to calculate the score for a word. It
        /// also stores the letters in lower-case regardless of the case of the
        /// input letters:
        ///     - "a" is worth 1 point.
        ///     - "b" is worth 3 points.
        ///     - "c" is worth 3 points.
        ///     - "d" is worth 2 points.
        ///     - Etc.
        ///
        /// This is a conversion from a Dictionary<int, IList<string>> to a Dictionary<string, int>.
        /// </summary>
        /// <param name="incomingData">Incoming data structure of old scores</param>
        /// <returns>New representation of input data</returns>
        public static Dictionary<string, int> Transform(Dictionary<int, IList<string>> incomingData)
        {
            return incomingData.SelectMany(a => a.Value.SelectMany(b => b.Select(c => new { intKey = a.Key, strValue = b.ToLower() })))
                .ToDictionary(d => d.strValue, d => d.intKey);
        }

        public static Dictionary<string, int> Transform1(Dictionary<int, IList<string>> incomingData)
        {
            //Create return object
            Dictionary<string, int> ret = new Dictionary<string, int>();

            //Loop through each dictionary key in the old structure.  Old keys are score point values.
            foreach (int i in incomingData.Keys)
            {
                //Within each old structure key (point value), loop through each lowercased letter in the value part.
                foreach (string s in incomingData[i].Select(x => x.ToLower()))
                {
                    //If the new data structure does not already have an item with the letter, then add it with the point value.
                    //Thus the old keys become the new values and the old value list items become the new keys.
                    if (!ret.ContainsKey(s))
                        ret.Add(s, i);
                }
            }

            //Return new structure
            return ret;
        }
    }
}
