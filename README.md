# Blazor demo: JS call, HttpClientFactory
Just a demo base on C# .NET Core Blazor Server project, with Javascript call/callback and HttpClientFactory, calling openweathermap to get weather forecast data.

1.HttpClientFactory [[ref](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests)]  
https://github.com/died/BlazorWithJsAndHttpClientFactory/blob/5f2b65f45aa52971919d04f8f12ee972e1299dbd/BlazorApp1/Startup.cs#L26
https://github.com/died/BlazorWithJsAndHttpClientFactory/blob/5f2b65f45aa52971919d04f8f12ee972e1299dbd/BlazorApp1/Data/OpenWeatherMapService.cs#L11-L18  

2.Blazor Javascript call [[ref](https://docs.microsoft.com/en-us/aspnet/core/blazor/call-javascript-from-dotnet?view=aspnetcore-3.1)]  
check `wwwroot\js\Geolocation.js` and `Pages\FetchWeather.razor` 
https://github.com/died/BlazorWithJsAndHttpClientFactory/blob/5f2b65f45aa52971919d04f8f12ee972e1299dbd/BlazorApp1/Pages/_Host.cshtml#L35

3.OpenWeatherMap API call was easy, please check `Data\OpenWeatherMapService.cs`