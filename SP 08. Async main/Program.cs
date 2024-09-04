﻿using System;
using System.Net;

namespace SP_08._Async_main
{
    internal class Program
    {
        static WebClient client = new();
        static string url = @"https://turbo.az/";
        static async Task Main(string[] args)
        {
            Console.WriteLine(await client.DownloadStringTaskAsync(url)); 
            //    Console.WriteLine(SomeAsync().Result);
        }
        static async Task<string> SomeAsync()
        {
            return  await client.DownloadStringTaskAsync(url);
        }
    }
}
