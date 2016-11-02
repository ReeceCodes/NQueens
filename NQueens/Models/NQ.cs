using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NQueens.Models
{
    public class NQ
    {
        public int NumberOfQueens { get; set; }

        public int iterations = 0;
  
        public int[] position;

        public List<string> Solutions = new List<string>();

        public NQ()
        {

        }

        public NQ(int i)
        {
            NumberOfQueens = i;

            position = new int[i];

            //recursive, seemingly brute force solution, works ok for 12 Q but after that soooooooo slow. by the time you get to 15 it's almost 175 million iterations. 
            //upside: gets all valid solutions :) includes where the board is just rotated but the positions are the 'same'
            //it is actually the display of all the solutions that is slower.
            //using this you would run out of memory trying to store all possible results and the counter would overflow unless changed to bigint.
            solve(0);          
        }

        public bool isSafe(int k, int p)
        {
            for (int i = 1; i <= k; i++)
            {
                int other = position[k - i];
                if (other == p || other == p - i || other == p + i)
                {
                    return false;
                }
            }
            return true;
        }

        public void solve(int k)
        {
            iterations++;

            if (k == NumberOfQueens)
            {
                Solutions.Add(string.Join(",",position));
            }
            else
            {
                for (int p = 0; p < NumberOfQueens; p++)
                {
                    if (isSafe(k, p))
                    {
                        position[k] = p;
                        solve(k + 1);
                    }
                }
            }
        }

    }
}