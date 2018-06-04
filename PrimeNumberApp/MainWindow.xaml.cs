using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AsyncTask;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace PrimeNumberApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static HttpClient client = new HttpClient();

        public MainWindow()
        {

        }

        private async void GetJSon(object sender, RoutedEventArgs e)
        {
            JSonTextBox.Content = await DownloadPageAsync();
        }

        private void GenerateRandomNumber(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            RandomNumber.Content = r.Next(1, 100).ToString();
        }

        public static async Task<string> DownloadPageAsync()
        {
            
            // ... Target page.
            string page = "https://jsonplaceholder.typicode.com/posts/1/comments";

            // ... Use HttpClient.
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(page))
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                string result = await content.ReadAsStringAsync();

                // ... Display the result.
                if (result != null)
                {
                     return result;
                }
                else
                {
                    return null;
                }
            }
        }

        private async void CalculatePrimeNumber(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke((Action)(async () =>
            {//this refer to form in WPF application 
                var PrimeNumber = await Task.Run(() => PrimeCounter.PrimeLong(Int32.Parse(PrimeTextBox.Text)));
                PrimeTextBox.Text = PrimeNumber.ToString();
            })); 
           
                
        }


        public Task<long> CalculatePrimeNumber(int primeNumber)
        {
            int count = 0;
            long a = 2;
            while (count < primeNumber)
            {
                long b = 2;
                int prime = 1;

                while (b * b <= a)
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
            var v = --a;
            return Task.FromResult(v);
        }
    }
}
