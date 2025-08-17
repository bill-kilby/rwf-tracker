using RWFTracker.Domain.RaceData;

namespace RWFTracker.Infastructure.Adapters.RaceDataCollector
{
    public interface IRaceDataCollector
    {
        public Task<RaceData?> CollectRaceDataAsync();
    }
}
