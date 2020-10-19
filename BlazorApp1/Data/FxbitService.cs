using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorApp1.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BlazorApp1.Data
{
    public interface IFxbitService
    {
        Task InitAsync();
        Task GetExchangeRate();
        string RateRaw { get; }
        Dictionary<string, Dictionary<string, FxbitExchangeRate>> RateDict { get; }
    }

    public class FxbitService : IFxbitService
    {
        private readonly HttpClient _client;
        private static string _rateRaw;
        private static Dictionary<string, Dictionary<string, FxbitExchangeRate>> _rateDict;
        public string RateRaw => _rateRaw;
        public Dictionary<string, Dictionary<string, FxbitExchangeRate>> RateDict => _rateDict;

        public FxbitService(IOptions<ApiOptions> settings, HttpClient httpClient)
        {
            var api = settings.Value;
            httpClient.BaseAddress = new Uri(api.Fxbit.Url);
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("x-api-key", api.Fxbit.ApiKey);
            _client = httpClient;
        }

        /// <summary>
        /// Get data when init
        /// </summary>
        /// <returns></returns>
        public async Task InitAsync()
        {
            await GetExchangeRate();
        }

        public async Task GetExchangeRate()
        {
            using var response = await _client.GetAsync("getExchangeRate");
            if (response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadAsStringAsync();
                if (str.Length < 5)
                {
                    Console.WriteLine($"Error: wrong response=>{str}");
                    return;
                }
                var data = JsonConvert.DeserializeObject<dynamic>(str);
                if (data.error != null)
                {
                    Console.WriteLine($"Error Code:{data.error.code} message:{data.error.message}");
                    return;
                }
                #region success

                var dict = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, FxbitExchangeRate>>>(str);
                _rateRaw = str;  //set raw json
                _rateDict = dict;
                #endregion
            }
            else
            {
                Console.WriteLine($"Error response code:{response.StatusCode}");
            }
        }
    }

    public class FxbitExchangeRate
    {
        [JsonProperty("updated_timestamp")]
        public string UpdatedTimestamp { get; set; }

        [JsonProperty("buyRate")]
        public string BuyRate { get; set; }

        [JsonProperty("sellRate")]
        public string SellRate { get; set; }
    }
}
