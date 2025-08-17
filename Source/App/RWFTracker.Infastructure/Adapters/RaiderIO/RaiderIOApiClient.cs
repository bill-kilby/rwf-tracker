using RWFTracker.Infastructure.Adapters.RaiderIO.Data;
using RWFTracker.Infastructure.Adapters.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RWFTracker.Infastructure.Adapters.RaiderIO
{
    public class RaiderIOApiClient : IApiClient<RaidRankingsResponse>
    {
        private HttpClient _httpClient = new();

        private const string RaiderIOEndpoint =
            @"https://raider.io/api/v1/raiding/raid-rankings?raid=manaforge-omega&difficulty=mythic&region=world&limit=50&page=0";

        public async Task<RaidRankingsResponse> GetDataAsync()
        {
            var response = await _httpClient.GetStringAsync(RaiderIOEndpoint);

            return JsonSerializer.Deserialize<RaidRankingsResponse>(response)!;
        }
    }
}
