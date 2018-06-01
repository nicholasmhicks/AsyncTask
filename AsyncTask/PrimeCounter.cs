using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTask
{
    public class PrimeCounter
    {
        public static long Prime(int primeNumber)
        {
            int count = 0;
            long a = 2;
            while (count < primeNumber)
            {
                long b = 2;
                int prime = 1;

                while (b*b <= a)
                {
                    if (a % b == 0)
                    {
                        prime = 0;
                        break;
                    }
                    b++;
                }
                if (prime > 0)
                {
                    count++;
                }
                a++;
            }
            long v = --a;
            return v;
        }
    }
}
