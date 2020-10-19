using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorApp1.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BlazorApp1.Data
{
    public class OpenWeatherMapService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiOptions _api;

        public OpenWeatherMapService(HttpClient httpClient, IOptions<ApiOptions> settings)
        {
            _httpClient = httpClient;
            _api = settings.Value;
        }

        /// <summary>
        /// Get owm forecast by geolocation
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lon"></param>
        /// <returns></returns>
        public Task<OwmWeather> GetForecastAsync(double lat, double lon)
        {
            var weather = new OwmWeather();
            var list = new List<OwmWeatherData>();

            if (lat != 0.0 && lon != 0.0)
            {
                var url = new Uri($"{_api.OpenWeatherMap.Url}Forecast?lat={lat}&lon={lon}&appid={_api.OpenWeatherMap.ApiKey}&units=metric");
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
