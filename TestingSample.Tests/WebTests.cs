using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using TestingSample.Web.Data;
using TestingSample.Web.Models;
using Xunit;
using Xunit.Abstractions;

namespace TestingSample.Tests
{
    /// <summary>
    /// From example at https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-5.0
    /// </summary>
    public class WebTests
    : IClassFixture<WebApplicationFactory<TestingSample.Web.Startup>>
    {
        private readonly WebApplicationFactory<TestingSample.Web.Startup> _factory;
        private readonly ITestOutputHelper _output;

        public WebTests(WebApplicationFactory<TestingSample.Web.Startup> factory, ITestOutputHelper output)
        {
            _factory = factory;
            this._output = output;
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Artists/Index")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            _output.WriteLine("Testing connection to path: " + url);

            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}