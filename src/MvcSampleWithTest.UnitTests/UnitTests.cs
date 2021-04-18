namespace MvcSampleWithTest.UnitTests
{
    using System.Threading;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MvcSampleWithTest.Application.Queries;
    using MvcSampleWithTest.Integration.QueryHandlers;

    [TestClass]
    public class UnitTests
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

        [TestMethod]
        public async Task TestMethod1()
        {
            //Arrange
            var command = new GetWeatherForecasts { };
            var handler = new GetWeatherForecastsHandler();

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(5);

            foreach (var item in result)
            {
                item.Summary.Should().BeOneOf(Summaries);
                item.TemperatureC.Should().BeInRange(-20, 55);
            }
        }
    }
}
