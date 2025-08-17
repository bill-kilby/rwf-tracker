using RWFTracker.Domain.RaceData;
using RWFTracker.Domain.RaceData.Enums;
using RWFTracker.Infastructure.Adapters.RaiderIO.Data;
using System.Text.RegularExpressions;

namespace RWFTracker.Infastructure.Adapters.RaiderIO.Translators
{
    public static class RaiderIOTranslator
    {
        public static RaceData ToDomain(RaidRankingsResponse response)
        {
            return new RaceData(
                    ToDomain(response.RaidRankings)
                );
        }

        private static List<RaceEntry> ToDomain(Ranking[] rankings)
        {
            var entries = new List<RaceEntry>();

            foreach (var ranking in rankings)
            {
                entries.Add(
                    new RaceEntry(
                        ToDomain(ranking.Guild),
                        ToDomain(ranking.Guild.Region),
                        ranking.Guild.Realm.Name,
                        ToDomain(ranking.EncountersPulled)));
            }

            return entries;
        }

        private static List<Encounter> ToDomain(EncounterPull[] pulls)
        {
            var encounters = new List<Encounter>();

            foreach (var pull in pulls)
            {
                encounters.Add(ToDomain(pull));
            }

            return encounters;
        }

        private static Encounter ToDomain(EncounterPull pull)
        {
            var name = Regex.Replace(pull.Slug, "-", " ");
            name = Regex.Replace(name, @"\b\w", m => m.Value.ToUpper());

            return new Encounter(
                name,
                pull.NumPulls,
                DateTime.Parse(pull.PullStartedAt),
                pull.IsDefeated,
                pull.BestPercent
                );
        }

        private static Domain.RaceData.Enums.Region ToDomain(Data.Region region)
        {
            switch (region.Slug)
            {
                case "us":
                    return Domain.RaceData.Enums.Region.US;
                case "eu":
                    return Domain.RaceData.Enums.Region.EU;
                case "kr":
                    return Domain.RaceData.Enums.Region.KR;
                case "tw":
                    return Domain.RaceData.Enums.Region.TW;
                default:
                    throw new HttpRequestException($"Invalid region: {region.Slug}");
            }
        }

        private static Domain.RaceData.Guild ToDomain(Data.Guild guild)
        {
            return new Domain.RaceData.Guild(
                guild.DisplayName,
                guild.Logo,
                ToDomain(guild.Faction)
                );
        }

        private static Faction ToDomain(string faction)
        {
            switch (faction)
            {
                case "horde":
                    return Faction.Horde;
                case "alliance":
                    return Faction.Alliance;
                default:
                    throw new HttpRequestException($"Invalid faction: {faction}");
            }
        }
    }
}
