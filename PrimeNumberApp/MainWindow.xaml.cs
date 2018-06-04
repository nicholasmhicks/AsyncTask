﻿using System;
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("https://jsonplaceholder.typicode.com/posts/1/comments");
            Stream respStream = await client.GetStreamAsync(uri);


        }
        public async Task<string> GetResponseString(string text)
        {
            var httpClient = new HttpClient();

            var parameters = new Dictionary<string, string>();
            parameters["text"] = text;

            var response = await httpClient.PostAsync(new Uri("https://jsonplaceholder.typicode.com/posts/1/comments"), new FormUrlEncodedContent(parameters));
            var contents = await response.Content.ReadAsStringAsync();

            return contents;
        }

    }
}
