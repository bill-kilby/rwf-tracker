using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RWFTracker.Infastructure.Adapters.RaiderIO.Data
{
    [Serializable]
    public class Guild
    {
        [JsonPropertyName("displayName")]
        public required string DisplayName { get; set; }

        [JsonPropertyName("faction")]
        public required string Faction { get; set; }

        [JsonPropertyName("realm")]
        public required Realm Realm { get; set; }

        [JsonPropertyName("region")]
        public required Region Region { get; set; }

        [JsonPropertyName("logo")]
        public required string Logo { get; set; }
    }
}
