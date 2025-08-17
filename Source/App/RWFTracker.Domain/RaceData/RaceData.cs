using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWFTracker.Domain.RaceData
{
    public class RaceData
    {
        public string Name;
        public List<RaceEntry> Entries;

        public RaceData(List<RaceEntry> entries)
        {
            Name = "TODO";
            Entries = entries;
        }
    }
}
