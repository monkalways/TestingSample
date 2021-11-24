using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TestingSample.Web.Data;
using TestingSample.Web.Models;
using Xunit;

namespace TestingSample.Tests
{
    public class MusicCatalogTests : IDisposable
    {
        MusicCatalogContext _context;

        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.test.json")
                .AddEnvironmentVariables()
                .Build();
            return config;
        }

        public MusicCatalogTests()
        {
            var config = InitConfiguration();

            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlServer()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<MusicCatalogContext>();

            // build connection string depending on security model
            string connectionString = "";
            string databaseName = "musiccatalogtests_" + Guid.NewGuid();

            if (config["Database:IntegratedSecurity"] == "true")
            {
                // using Integrated Security for local testing
                connectionString = $"Server=(localdb)\\mssqllocaldb;Database=" + databaseName + ";Trusted_Connection=True;MultipleActiveResultSets=true";
            }
            else
            {
                // using standard (username/password) SQL authentication for remote database (GitHub Actions Service Container)
                // Connection string for remote database: Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;
                var serverName = config["Database:Server"] + "," + config["Database:Port"];
                var userName = config["Database:UserId"];
                var password = config["Database:Password"];
                connectionString = "Server=" + serverName + ";Database=" + databaseName + ";User Id=" + userName + ";Password=" + password;
            }

            builder.UseSqlServer(connectionString)
                .UseInternalServiceProvider(serviceProvider);

            _context = new MusicCatalogContext(builder.Options);
            _context.Database.EnsureCreated();
            DbInitializer.Initialize(_context);

        }

        [Fact]
        public async void QueryArtistsTest()
        {

            var artistResults = await _context.Artists.ToListAsync();

            Assert.Equal(3, artistResults.Count);

        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }


    }
}
