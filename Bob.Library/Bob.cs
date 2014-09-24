using System;
using System.Linq;

namespace Bob.Library
{
    /// <summary>
    /// This class represents a "lackadaisical teenager"
    /// </summary>
    public class Bob
    {
        /// <summary>
        /// What does Bob the lackadaisical teenager say in response to what you say to him?
        /// </summary>
        /// <param name="whatYouSay">Text string that you say to Bob</param>
        /// <returns>What Bob says in response to your input</returns>
        public string Hey(string whatYouSay)
        {
            //Default response unless questioned, yelled at or given silent treatment
            string ret = "Whatever.";

            if (String.IsNullOrWhiteSpace(whatYouSay))
            {
                //Nothing was said
                ret = "Fine. Be that way!";
            }
            else
            {
                if (whatYouSay.Count(x => char.IsLetter(x)) > 0 && whatYouSay.Count(x => char.IsLetter(x) && char.IsLower(x)) == 0)
                {
                    //The saying has alphabetic characters (letters) and at none are lower case, so this is yelling
                    ret = "Whoa, chill out!";
                }
                else if (whatYouSay.EndsWith("?"))
                {
                    //Not yelling and ends with a question mark, so act like this is a legitimate question.
                    ret = "Sure.";
                }
            }

            return ret;
        }
    }
}