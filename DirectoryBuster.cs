using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
     static async Task Main(string[] args)
    {

       Console.WriteLine("Enter IP: ");
       string ip = Console.ReadLine();

        Console.WriteLine("Enter Wordlist Path: ");
        string path = Console.ReadLine();

        foreach (string word in File.ReadLines(path))
        {

            string url = $"http://{ip}/{word}/";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Flag.txt found at {url}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error accessing {url}: {ex.Message}");
                }
            }
        }
    }
}




