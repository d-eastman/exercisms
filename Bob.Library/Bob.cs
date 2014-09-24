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
        /// <param name="youSay">Text string that you say to Bob</param>
        /// <returns>What Bob says in response to your input</returns>
        public string Hey(string youSay)
        {
            //Default response unless questioned, yelled at or given silent treatment
            string ret = "Whatever.";

            if (String.IsNullOrWhiteSpace(youSay))
            {
                //Nothing was said
                ret = "Fine. Be that way!";
            }
            else
            {
                //Something was said

                //Determine percentage of alpha chars that are uppercase.  The tests included require 100%, but
                //writing this way to allow most but not all characters to be upper case and still consider it
                //yelling so that if Bob gets more sensitive to harsh words, he can say Whoa, chill out! when
                //someone says, YO, HEY MAN, WHAT the HECK IS WRONG WITH YOU?
                double alphaCount = youSay.Count(x => char.IsLetter(x));
                int upperCaseAlphaCount = youSay.Where(x => char.IsLetter(x)).Count(x => char.IsUpper(x));
                double yellingThreshold = 1.0; //In future iterations, this could be refactored as an optional method parameter

                if (alphaCount > 0 && (upperCaseAlphaCount / alphaCount) >= yellingThreshold)
                {
                    //Enough alpha characters are upper cased to qualify this as yelling
                    ret = "Whoa, chill out!";
                }
                else if (youSay.EndsWith("?"))
                {
                    //Not yelling and ends with a question mark, so act like this is a legitimate question.
                    ret = "Sure.";
                }
            }

            return ret;
        }
    }
}