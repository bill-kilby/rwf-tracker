using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWFTracker.Domain.RaceData
{
    public class Encounter
    {
        public string Name { get; set; }
        public int PullCount { get; set; }
        public DateTime Time { get; set; }
        public bool Defeated { get; set; }
        public float Percent { get; set; }
        
        public Encounter(string name, int pullCount, DateTime time, bool defeated, float percent)
        {
            Name = name;
            PullCount = pullCount;
            Time = time;
            Defeated = defeated;
            Percent = percent;
        }
    }
}
