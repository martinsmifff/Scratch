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
using System.Net.Http;
using System.Net;
using System.IO;

namespace AsyncExampeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            startButton.IsEnabled = false;
            resultsTextBox.Clear();
            await SumPageSizesAsync();
            resultsTextBox.Text += "\r\nControl returned to satrtButton_Click.";
            startButton.IsEnabled = true;
        }

        private async Task SumPageSizesAsync()
        {
            // Make a list of web addresses.
            List<string> urlList = SetUpURLList();

            var total = 0;
            foreach (var url in urlList)
            {
                HttpClient client = new HttpClient() { MaxResponseContentBufferSize = 1000000 };

                // GetURLContents returns the contents of url as a byte array. 
                byte[] urlContents = await client.GetByteArrayAsync(url);


                DisplayResults(url, urlContents);

                // Update the total.
                total += urlContents.Length;
            }

            // Display the total count for all of the web addresses.
            resultsTextBox.Text +=
                string.Format("\r\n\r\nTotal bytes returned:  {0}\r\n", total);
        }


        private List<string> SetUpURLList()
        {
            var urls = new List<string> 
            { 
                "http://msdn.microsoft.com/library/windows/apps/br211380.aspx",
                "http://msdn.microsoft.com",
                "http://msdn.microsoft.com/en-us/library/hh290136.aspx",
                "http://msdn.microsoft.com/en-us/library/ee256749.aspx",
                "http://msdn.microsoft.com/en-us/library/hh290138.aspx",
                "http://msdn.microsoft.com/en-us/library/hh290140.aspx",
                "http://msdn.microsoft.com/en-us/library/dd470362.aspx",
                "http://msdn.microsoft.com/en-us/library/aa578028.aspx",
                "http://msdn.microsoft.com/en-us/library/ms404677.aspx",
                "http://msdn.microsoft.com/en-us/library/ff730837.aspx"
            };
            return urls;
        }


        //private async Task<byte[]> GetURLContentsAsync(string url)
        //{
        //    // The downloaded resource ends up in the variable named content. 
        //    var content = new MemoryStream();

        //    // Initialize an HttpWebRequest for the current URL. 
        //    var webReq = (HttpWebRequest)WebRequest.Create(url);

        //    // Send the request to the Internet resource and wait for 
        //    // the response. 
        //    // Note: you can't use HttpWebRequest.GetResponse in a Windows Store app. 
        //    using (WebResponse response = await webReq.GetResponseAsync())
        //    {
        //        // Get the data stream that is associated with the specified URL. 
        //        using (Stream responseStream = response.GetResponseStream())
        //        {
        //            // Read the bytes in responseStream and copy them to content.  
        //            await responseStream.CopyToAsync(content);
        //        }
        //    }

        //    // Return the result as a byte array. 
        //    return content.ToArray();
        //}


        private void DisplayResults(string url, byte[] content)
        {
            // Display the length of each website. The string format  
            // is designed to be used with a monospaced font, such as 
            // Lucida Console or Global Monospace. 
            var bytes = content.Length;
            // Strip off the "http://".
            var displayURL = url.Replace("http://", "");
            resultsTextBox.Text += string.Format("\n{0,-58} {1,8}", displayURL, bytes);
        }
    }
}
