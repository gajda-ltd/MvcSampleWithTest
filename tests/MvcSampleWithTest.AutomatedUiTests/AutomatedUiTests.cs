namespace MvcSampleWithTest.AutomatedUiTests
{
    using System;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Edge;

    [TestClass]
    public sealed class AutomatedUiTests : IDisposable
    {
        private bool disposed = false;
        private IWebDriver driver;

        public AutomatedUiTests()
        {
            var options = new EdgeOptions
            {
                //UseChromium = true,
            };

            this.driver = new EdgeDriver(options);
        }

        ~AutomatedUiTests()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.driver.Dispose();
                    this.driver = null;
                }

                disposed = true;
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            //Arrange

            //Act
            this.driver.Navigate().GoToUrl("http://localhost:5000/WeatherForecast");

            //Assert
            this.driver.Title.Should().BeNullOrEmpty();
        }
    }
}
