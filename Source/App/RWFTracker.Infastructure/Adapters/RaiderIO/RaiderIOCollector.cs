using Microsoft.Extensions.Logging;
using RWFTracker.Domain.RaceData;
using RWFTracker.Infastructure.Adapters.RaceDataCollector;
using RWFTracker.Infastructure.Adapters.RaiderIO.Data;
using RWFTracker.Infastructure.Adapters.RaiderIO.Translators;
using RWFTracker.Infastructure.Adapters.Web;
using System.Text.Json;

namespace RWFTracker.Infastructure.Adapters.RaiderIO
{
    public class RaiderIOCollector : IRaceDataCollector
    {
        private IApiClient<RaidRankingsResponse> _api;
        private ILogger<RaiderIOCollector> _logger;

        public RaiderIOCollector(IApiClient<RaidRankingsResponse> apiClient, ILogger<RaiderIOCollector> logger)
        {
            _api = apiClient;
            _logger = logger;
        }

        public async Task<RaceData?> CollectRaceDataAsync()
        {
            try
            {
                var response = await _api.GetDataAsync();
                return RaiderIOTranslator.ToDomain(response);
            }
            catch (Exception e)
            {
                _logger.LogError($"Could not process data from RaiderIO: {e.Message}");
                return null;
            }
        }
    }
}
