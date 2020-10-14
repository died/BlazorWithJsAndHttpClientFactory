# Blazor demo: JS call, HttpClientFactory
Just a demo base on C# .NET Core Blazor Server project, with Javascript call/callback and HttpClientFactory, calling openweathermap to get weather forecast data.

1.HttpClientFactory [[ref](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests)]  
check  
[Startup.cs#L26](https://github.com/died/BlazorWithJsAndHttpClientFactory/blob/5f2b65f45aa52971919d04f8f12ee972e1299dbd/BlazorApp1/Startup.cs#L26)  
[Data\OpenWeatherMapService.cs#L11-L18](https://github.com/died/BlazorWithJsAndHttpClientFactory/blob/5f2b65f45aa52971919d04f8f12ee972e1299dbd/BlazorApp1/Data/OpenWeatherMapService.cs#L11-L18)  

2.Blazor Javascript call [[ref](https://docs.microsoft.com/en-us/aspnet/core/blazor/call-javascript-from-dotnet?view=aspnetcore-3.1)]  
check  
`wwwroot\js\Geolocation.js`  
`Pages\FetchWeather.razor`   
[Pages\_Host.cshtml#L35](https://github.com/died/BlazorWithJsAndHttpClientFactory/blob/5f2b65f45aa52971919d04f8f12ee972e1299dbd/BlazorApp1/Pages/_Host.cshtml#L35)  

3.OpenWeatherMap API call was easy, please check `Data\OpenWeatherMapService.cs`

# Result
It will require your geolocation by browser and get the city's weather forecast, if everything working fine.  
![image](https://i.imgur.com/qhbqe8I.png)

## Remember
Go [OpenWeatherMap](https://openweathermap.org/guide) to get your API key and update it in [here](https://github.com/died/BlazorWithJsAndHttpClientFactory/blob/d1f1980a5a5bb4e2de6c5bf474cdedc26013dd86/BlazorApp1/Data/OpenWeatherMapService.cs#L13), the API key will need few time to active so you should do it first.
