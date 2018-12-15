using Microsoft.Owin.Hosting;
using System;

namespace BookService
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start("http://localhost:8282")) {
                Console.WriteLine("Started on localhost:8282");
                Console.ReadKey();
            }
        }
    }
}
