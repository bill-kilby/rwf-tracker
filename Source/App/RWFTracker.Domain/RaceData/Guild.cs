using RWFTracker.Domain.RaceData.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWFTracker.Domain.RaceData
{
    public class Guild
    {
        public Guid Guid { get; }
        public string Name { get; }
        public string LogoUrl { get; }
        public Faction Faction { get; }

        public Guild(string name, string logoUrl, Faction faction)
        {
            Guid = Guid.NewGuid();

            Name = name;
            LogoUrl = logoUrl;
            Faction = faction;
        }

    }
}
