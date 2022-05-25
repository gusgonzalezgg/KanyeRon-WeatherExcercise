using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace weatherapp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("What city whose weather are you looking for?");
            string ZIP = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Please enter your API key");
            var api = Console.ReadLine();

            var url = $"https://api.openweathermap.org/data/2.5/weather?zip={ZIP},us&appid={api}";


            var client = new HttpClient();
            var response = client.GetStringAsync(url).Result;
            //Console.WriteLine(response);
            var weatherInfo = JObject.Parse(response).GetValue("main").ToString();
            var tempInfo = JObject.Parse(weatherInfo).GetValue("temp").ToString();

            double kelvinInfo = Convert.ToDouble(tempInfo);

            double convertFarenheit = kelvinInfo * 1.8 - 459.67;
            Console.WriteLine("Currently Calculating.....");
            Console.ReadKey();
            Console.WriteLine($"At the moment, it's currently {convertFarenheit} degrees out!");
        }
    }
}
