using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlazorApp1.Data
{
    public class OpenWeatherMapService
    {
        private readonly HttpClient _httpClient;
        //Go https://openweathermap.org/guide to get an API key
        private const string OwmApiKey = "your key";

        public OpenWeatherMapService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<OwmWeather> GetForecastAsync(double lat, double lon)
        {
            var weather = new OwmWeather();
            var list = new List<OwmWeatherData>();
            if (lat != 0.0 && lon != 0.0)
            {
                var url = new Uri($"https://api.openweathermap.org/data/2.5/forecast?lat={lat}&lon={lon}&appid={OwmApiKey}&units=metric");
                var response = _httpClient.GetStringAsync(url).Result;
                var data = JsonConvert.DeserializeObject<OwmForecast>(response);
                weather.City = data.City.Name;
                var weatherList = data.List;
                foreach (var d in weatherList)
                {
                    list.Add(new OwmWeatherData
                    {
                        Date = DateTime.Parse(d.DtTxt),
                        DateText = d.DtTxt,
                        Temperature = d.Main.Temp,
                        Rain = d.Rain?.ThreeHour ?? 0.0,
                        Cloud = d.Clouds.All,
                        Summary = d.Weather?[0].Description
                    });
                }
            }

            weather.Data = list;
            return Task.FromResult(weather);
        }
    }
}
