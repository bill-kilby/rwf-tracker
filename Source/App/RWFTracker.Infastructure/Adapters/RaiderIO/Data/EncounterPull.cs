using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RWFTracker.Infastructure.Adapters.RaiderIO.Data
{
    [Serializable]
    public class EncounterPull
    {
        [JsonPropertyName("slug")]
        public required string Slug { get; set; }

        [JsonPropertyName("numPulls")]
        public required int NumPulls { get; set; }

        [JsonPropertyName("pullStartedAt")]
        public required string PullStartedAt { get; set; }

        [JsonPropertyName("bestPercent")]
        public required float BestPercent { get; set; }

        [JsonPropertyName("isDefeated")]
        public required bool IsDefeated { get; set; } 
    }
}
