using System.Text.Json.Serialization;

namespace RWFTracker.Infastructure.Adapters.RaiderIO.Data
{
    [Serializable]
    public class RaidRankingsResponse
    {
        [JsonPropertyName("raidRankings")]
        public Ranking[] RaidRankings { get; set; } = Array.Empty<Ranking>();
    }
}
