namespace Leap.Library
{
    /// <summary>
    /// Static class Year to contain static method IsLeap
    /// </summary>
    public static class Year
    {
        /// <summary>
        /// //Class method on Year to determine if passed in value is a leap year or not
        /// </summary>
        /// <param name="year">Year value</param>
        /// <returns>Whether the input year is a leap year (true) or not (false)</returns>
        public static bool IsLeap(int year)
        {
            //By default, return false (not leap year)
            bool ret = false;

            if (year % 4 == 0)
            {
                //Divisible by 4, so possibly a leap year
                if (year % 400 == 0)
                {
                    //Divisible by 400, so a leap year
                    ret = true;
                }
                else if (year % 100 == 0)
                {
                    //Divisible by 100 but not 400, so NOT a leap year
                    ret = false;
                }
                else
                {
                    //Not divisible by 100 or 400, some other number that's divisible by 4, so it is a leap year
                    ret = true;
                }
            }

            return ret; //Return result
        }
    }
}