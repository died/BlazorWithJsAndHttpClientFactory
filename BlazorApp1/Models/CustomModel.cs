namespace BlazorApp1.Models
{
    public class ApiOptions
    {
        public const string ApiSetting = "ApiSetting";
        public ApiConfig Fxbit { get; set; }
        public ApiConfig OpenWeatherMap { get; set; }
    }

    public class ApiConfig
    {
        public string Url { get; set; }
        public string ApiKey { get; set; }
    }
}
