using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question1
    {
        public static int Answer(int[] portfolios)
        {
            var toBase = 2;
            var length = 7;
            var currentBiggest = 0;

            for (var portfolioIndex = 0; portfolioIndex < portfolios.Length; portfolioIndex++)
            {
                // Convert the element at the current index into a binary array
                var digit = Convert.ToString(portfolios[portfolioIndex], toBase).PadLeft(length, '0');
                var binary = digit.Select(c => c - '0').ToArray();

                // Loop through the array again, to compare the current element to the others.
                for (var i = 0; i < portfolios.Length; i++)
                {
                    if (i == portfolioIndex) continue; // Skip itself in the array.

                    // Convert the element at i to binary array.
                    var digit2 = Convert.ToString(portfolios[i], toBase).PadLeft(length, '0');
                    var binary2 = digit2.Select(c => c - '0').ToArray();

                    // Initialise the combined portfolio
                    int[] combinedPortfolio = {0, 0, 0, 0, 0, 0, 0};
                    
                    // Loop through the two binary arrays of length 7, and populate the combined using XOR logic 
                    for (var index = 0; index < 7; index++)
                        if (binary[index] == 0)
                        {
                            if (binary2[index] == 1) combinedPortfolio[index] = 1;
                        }
                        else
                        {
                            if (binary2[index] == 0) combinedPortfolio[index] = 1;
                        }
                    
                    // Convert the combined portfolio array back into a standard number
                    var combinedInt = Convert.ToInt32(string.Join("", combinedPortfolio), 2);
                    
                    if (combinedInt > currentBiggest) currentBiggest = combinedInt;
                }
            }

            return currentBiggest;
        }
    }
}