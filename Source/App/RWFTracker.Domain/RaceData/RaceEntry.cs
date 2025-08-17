using RWFTracker.Domain.RaceData.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWFTracker.Domain.RaceData
{
    public class RaceEntry
    {
        public Guild Guild;
        public Region Region;
        public string Realm;
        public List<Encounter> EncounteredBosses;

        public RaceEntry(Guild guild, Region region, string realm, List<Encounter> encounteredBosses)
        {
            Guild = guild;
            Region = region;
            Realm = realm;
            EncounteredBosses = encounteredBosses;
        }
    }
}
