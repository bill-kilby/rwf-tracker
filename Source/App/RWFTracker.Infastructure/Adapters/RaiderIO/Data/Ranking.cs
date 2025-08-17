using System.Text.Json.Serialization;

namespace RWFTracker.Infastructure.Adapters.RaiderIO.Data
{
    [Serializable]
    public class Ranking
    {
        [JsonPropertyName("guild")]
        public required Guild Guild { get; set; }

        [JsonPropertyName("encountersPulled")]
        public required EncounterPull[] EncountersPulled { get; set; }
    }
}
