namespace MvcSampleWithTest.Application.Queries
{
    using System.Collections.Generic;
    using MediatR;
    using MvcSampleWithTest.Application.ViewModels;

    public sealed record GetWeatherForecasts : IRequest<IReadOnlyList<WeatherForecast>>
    {
    }
}
