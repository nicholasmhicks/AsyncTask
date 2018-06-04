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
            FindPrime();
            Console.ReadKey();
        }

        public static async Task FindPrimeMultiThread() //12 seconds
        {

            var a = await Task.Run(() => PrimeCounter.PrimeLong(250000));

            Console.WriteLine(a);

            var b = await Task.Run(() => PrimeCounter.PrimeLong(400000));

            Console.WriteLine(b);
        }
        public static async void FindPrimeAsync() // 14 seconds
        {

            var a = await PrimeCounter.PrimeTaskLong(250000);

            Console.WriteLine(a);

            var b = await PrimeCounter.PrimeTaskLong(400000);

            Console.WriteLine(b);
        }

        public static void FindPrime() // 14 seconds
        {
            var a = PrimeCounter.PrimeLong(250000);
            Console.WriteLine(a);

            var b = PrimeCounter.PrimeLong(400000);

            
            Console.WriteLine(b);
        }
    }
}

