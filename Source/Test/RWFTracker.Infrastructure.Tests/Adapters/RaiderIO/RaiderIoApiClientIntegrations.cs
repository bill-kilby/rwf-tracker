using RWFTracker.Infastructure.Adapters.RaiderIO;
using RWFTracker.Infastructure.Adapters.RaiderIO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RWFTracker.Infrastructure.Tests.Adapters.RaiderIO
{
    [TestFixture]
    internal class RaiderIoApiClientIntegrations
    {
        private HttpClient _httpClient;
        private RaiderIOApiClient _apiClient; // Replace with your class name

        [SetUp]
        public void Setup()
        {
            _httpClient = new HttpClient();
            _apiClient = new RaiderIOApiClient();
        }

        [TearDown]
        public void Teardown()
        {
            _httpClient.Dispose();
        }

        [Test]
        public async Task GetDataAsync_ShouldReturnValidResponse()
        {
            // Act
            var result = await _apiClient.GetDataAsync();

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task GetDataAsync_ShouldDeserializeJsonCorrectly()
        {
            // Act
            var jsonString = await _httpClient.GetStringAsync(
                "https://raider.io/api/v1/raiding/raid-rankings?raid=manaforge-omega&difficulty=mythic&region=world&limit=10&page=0");

            var response = JsonSerializer.Deserialize<RaidRankingsResponse>(jsonString);

            // Assert
            Assert.That(response, Is.Not.Null);
        }
    }
}
