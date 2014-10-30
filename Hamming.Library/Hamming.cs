using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamming.Library
{
    public static class Hamming
    {
        /// <summary>
        /// Compute the Hamming distance between two DNA strands.  Each point mutation adds one to
        /// the calculated distance.
        /// </summary>
        /// <param name="strand1">Nucleotide DNA sequence 1 as string of the characters A, C, G, and T.</param>
        /// <param name="strand2">Nucleotide DNA sequence 2</param>
        /// <returns>Hamming distance, the number of point differences between the two DNA strands.</returns>
        public static int Compute(string strand1, string strand2)
        {
            if (strand1.Length != strand2.Length)
                throw new ArgumentException("Strands must be equal length.");

            int distance = 0;

            //Compare all points and increment distance if they are different.
            for (int i = 0; i < strand1.Length; i++)
            {
                if (strand1[i] != strand2[i])
                    distance++;
            }

            return distance;
        }
    }
}
