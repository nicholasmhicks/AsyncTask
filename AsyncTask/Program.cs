using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = FindPrimeAsync();
            Console.ReadKey();
        }

        public static async Task FindPrimeAsync()
        {

            var a = await Task.Run(() => PrimeCounter.Prime(250000));
            var b = await Task.Run(() => PrimeCounter.Prime(400000));
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}
