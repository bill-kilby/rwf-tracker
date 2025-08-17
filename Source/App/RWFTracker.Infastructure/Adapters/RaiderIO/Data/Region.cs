using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RWFTracker.Infastructure.Adapters.RaiderIO.Data
{
    [Serializable]
    public class Region
    {
        [JsonPropertyName("slug")]
        public required string Slug { get; set; }
    }
}
