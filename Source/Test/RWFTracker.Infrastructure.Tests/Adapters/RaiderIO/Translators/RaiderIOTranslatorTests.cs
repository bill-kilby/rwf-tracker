using RWFTracker.Domain.RaceData.Enums;
using RWFTracker.Infastructure.Adapters.RaiderIO.Data;
using RWFTracker.Infastructure.Adapters.RaiderIO.Translators;

namespace RWFTracker.Infrastructure.Tests.Adapters.RaiderIO.Translators
{
    [TestFixture]
    public class RaiderIOTranslatorTests
    {
        [Test]
        public void ToDomain_ShouldMapRaceDataCorrectly()
        {
            // Arrange
            var response = GetResponse();

            // Act
            var result = RaiderIOTranslator.ToDomain(response);

            // Assert
            Assert.That(result.Entries, Is.Not.Null);
            Assert.That(result.Entries, Has.Count.EqualTo(1));

            var domainEntry = result.Entries[0];
            Assert.Multiple(() =>
            {
                Assert.That(domainEntry.Guild.Name, Is.EqualTo("BKDEV"));
                Assert.That(domainEntry.Guild.LogoUrl, Is.EqualTo("LogoUrl"));
                Assert.That(domainEntry.Guild.Faction, Is.EqualTo(Faction.Alliance));
                Assert.That(domainEntry.Region, Is.EqualTo(Domain.RaceData.Enums.Region.EU));

                Assert.That(domainEntry.EncounteredBosses, Is.Not.Null);
                Assert.That(domainEntry.EncounteredBosses, Has.Count.EqualTo(1));
            });

            var domainEncounter = domainEntry.EncounteredBosses[0];
            Assert.Multiple(() =>
            {
                Assert.That(domainEncounter.Name, Is.EqualTo("BKBoss"));
                Assert.That(domainEncounter.PullCount, Is.EqualTo(3));
                Assert.That(domainEncounter.Defeated, Is.False);
                Assert.That(domainEncounter.Percent, Is.EqualTo(98.5f));
                Assert.That(domainEncounter.Time, Is.EqualTo(DateTime.Parse("2025-08-17T12:00:00Z")));
            });
        }

        [TestCase("horde", Faction.Horde)]
        [TestCase("alliance", Faction.Alliance)]
        public void ToDomain_ShouldMapFactionCorrectly(string faction, Faction expected)
        {
            // Arrange
            var response = GetResponse();
            response.RaidRankings[0].Guild.Faction = faction;

            // Act
            var result = RaiderIOTranslator.ToDomain(response);

            // Assert
            Assert.That(result.Entries[0].Guild.Faction, Is.EqualTo(expected));
        }

        [TestCase("us", Domain.RaceData.Enums.Region.US)]
        [TestCase("eu", Domain.RaceData.Enums.Region.EU)]
        [TestCase("kr", Domain.RaceData.Enums.Region.KR)]
        [TestCase("tw", Domain.RaceData.Enums.Region.TW)]
        public void ToDomain_ShouldMapRegionCorrectly(string region, Domain.RaceData.Enums.Region expected)
        {
            // Arrange
            var response = GetResponse();
            response.RaidRankings[0].Guild.Region.Slug = region;

            // Act
            var result = RaiderIOTranslator.ToDomain(response);

            // Assert
            Assert.That(result.Entries[0].Region, Is.EqualTo(expected));
        }

        [Test]
        public void ToDomain_ShouldThrowForInvalidFaction()
        {
            // Arrange
            var response = GetResponse();
            response.RaidRankings[0].Guild.Faction = "InvalidFaction";

            // Act + Assert
            Assert.Throws<HttpRequestException>(() =>
            {
                RaiderIOTranslator.ToDomain(response);
            });
        }

        [Test]
        public void ToDomain_ShouldThrowForInvalidRegion()
        {
            // Arrange
            var response = GetResponse();
            response.RaidRankings[0].Guild.Region.Slug = "InvalidRegion";

            // Act + Assert
            Assert.Throws<HttpRequestException>(() =>
            {
                RaiderIOTranslator.ToDomain(response);
            });
        }

        private RaidRankingsResponse GetResponse()
        {
            return new RaidRankingsResponse
            {
                RaidRankings = new[]
                {
                    new Ranking
                    {
                        Guild = new Infastructure.Adapters.RaiderIO.Data.Guild
                        {
                            DisplayName = "BKDEV",
                            Logo = "LogoUrl",
                            Faction = "alliance",
                            Region = new Infastructure.Adapters.RaiderIO.Data.Region { Slug = "eu" },
                            Realm = new()
                            {
                                Id = 404,
                                Name = "BKREALM"
                            }
                        },
                        EncountersPulled = new[]
                        {
                            new EncounterPull
                            {
                                Slug = "BKBoss",
                                NumPulls = 3,
                                PullStartedAt = "2025-08-17T12:00:00Z",
                                IsDefeated = false,
                                BestPercent = 98.5f
                            }
                        }
                    }
                }
            };
        }
    }
}
