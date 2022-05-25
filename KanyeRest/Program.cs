using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace KanyeRest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Here's a random quote from Kanye");
            
            var url = "https://api.kanye.rest/";
            var client = new HttpClient();
            var response = client.GetStringAsync(url).Result;
            var kanyeQuote = JObject.Parse(response).GetValue("quote").ToString();
            Console.WriteLine(kanyeQuote);
            Console.ReadLine();
            Console.ReadKey();

            Console.WriteLine("Now here's something from Ron Swanson");
            Console.ReadKey();
            

            var ronURl = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var ronClient = new HttpClient();
            var ronsponse = ronClient.GetStringAsync(ronURl).Result;
            
            var ronQuote = JArray.Parse(ronsponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
            Console.WriteLine(ronQuote);
            Console.ReadKey();

            Console.WriteLine("Now we're going to simulate a convo between the two of them by" +
                " throwing these values in a forloop");
            Console.ReadKey();

           

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();
                response = client.GetStringAsync(url).Result;
                kanyeQuote = JObject.Parse(response).GetValue("quote").ToString();
                Console.WriteLine($"Kanye - {kanyeQuote}");
                Console.WriteLine();
                ronsponse = ronClient.GetStringAsync(ronURl).Result;
                ronQuote = JArray.Parse(ronsponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
                Console.WriteLine($"Ron - {ronQuote}");
                Console.ReadKey();
            }


        }
    }
}
