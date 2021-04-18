namespace MvcSampleWithTest.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using MvcSampleWithTest.Application.Queries;
    using MvcSampleWithTest.Application.ViewModels;

    [ApiController]
    [Route("[controller]")]
    public sealed class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> logger;
        private readonly IMediator mediator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IReadOnlyList<WeatherForecast>> Get()
        {
            return await this.mediator.Send<IReadOnlyList<WeatherForecast>>(new GetWeatherForecasts { });
        }
    }
}
