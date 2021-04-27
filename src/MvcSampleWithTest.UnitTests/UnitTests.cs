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
        public TestContext TestContext { get; set; }

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
            var command = new GetWeatherForecasts();
            var handler = new GetWeatherForecastsHandler();

            //Act
            var result = await handler.Handle(command, CancellationToken.None);
            this.TestContext.WriteLine(result.ToString());

            //Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(5);

            foreach (var item in result)
            {
                item.Summary.Should().BeOneOf(Summaries);
                item.TemperatureC.Should().BeInRange(-20, 55);
            }
        }

        [TestMethod]
        public void TestRunParameters()
        {
            //Arrange
            var expected = "https://www.google.co.uk";

            //Act
            var result = TestContext.Properties["google"];

            //Assert
            result.Should().Be(expected);
        }
    }
}
