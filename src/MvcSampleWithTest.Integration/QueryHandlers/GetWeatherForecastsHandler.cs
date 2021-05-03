namespace MvcSampleWithTest.Integration.QueryHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using MvcSampleWithTest.Application.Queries;
    using MvcSampleWithTest.Application.ViewModels;

    internal sealed class GetWeatherForecastsHandler : IRequestHandler<GetWeatherForecasts, IReadOnlyList<WeatherForecast>>
    {
        private static readonly string[] Summaries = new[]
        {
            "Balmy",
            "Bracing",
            "Chilly",
            "Cool",
            "Freezing",
            "Hot",
            "Mild",
            "Warm",
            "Scorching",
            "Sweltering",
        };

        public async Task<IReadOnlyList<WeatherForecast>> Handle(GetWeatherForecasts request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new NullReferenceException("Request cannot be null");
            }

            var rng = new Random();
            var weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToList()
            .AsReadOnly();

            return await Task.FromResult<IReadOnlyList<WeatherForecast>>(weatherForecasts);
        }
    }
}
