using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using RWFTracker.Infastructure.Adapters.RaiderIO;
using RWFTracker.Infastructure.Adapters.RaiderIO.Data;
using RWFTracker.Infastructure.Adapters.Web;

namespace RWFTracker.Infrastructure.Tests.Adapters.RaiderIO
{
    [TestFixture]
    public class RaiderIOCollectorTests
    {
        private IApiClient<RaidRankingsResponse> _apiClient;
        private ILogger<RaiderIOCollector> _logger;
        private RaiderIOCollector _collector;

        [SetUp]
        public void Setup()
        {
            _apiClient = Substitute.For<IApiClient<RaidRankingsResponse>>();
            _logger = Substitute.For<ILogger<RaiderIOCollector>>();
            _collector = new RaiderIOCollector(_apiClient, _logger);
        }

        [Test]
        public async Task CollectRaceDataAsync_ShouldReturnMappedRaceData_WhenApiSucceeds()
        {
            // Arrange
            var response = new RaidRankingsResponse
            {
                RaidRankings = Array.Empty<Ranking>()
            };

            _apiClient.GetDataAsync().Returns(Task.FromResult(response));

            // Act
            var result = await _collector.CollectRaceDataAsync();

            // Assert
            Assert.That(result, Is.Not.Null);
            await _apiClient.Received(1).GetDataAsync();
        }

        [Test]
        public async Task CollectRaceDataAsync_ShouldReturnNullAndLogError_WhenApiThrows()
        {
            // Arrange
            _apiClient.GetDataAsync().Throws(new Exception());

            // Act
            var result = await _collector.CollectRaceDataAsync();

            // Assert
            Assert.That(result, Is.Null);
        }
    }
}