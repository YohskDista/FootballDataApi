using FakeItEasy;
using FluentAssertions;
using FootballDataApi.Services;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace FootballDataApi.Tests
{
    [TestFixture(TestOf = typeof(CompetitionProvider))]
    internal class CompetitionProviderTests
    {
        [TestCase("")]
        [TestCase("  ")]
        [TestCase(null)]
        public async Task When_giving_invalid_competition_id_to_get_all_matches_Then_should_throw_exception(
            string competitionId)
        {
            var dataProvider = A.Fake<IDataProvider>();
            var competitionProvider = new CompetitionProvider(dataProvider);

            var action = () => competitionProvider.GetAllMatchesOfCompetitionAsync(competitionId);

            await action.Should().ThrowAsync<ArgumentException>();
        }

        [TestCase("")]
        [TestCase("  ")]
        [TestCase(null)]
        public async Task When_giving_invalid_competition_id_to_get_competion_Then_should_throw_exception(
            string competitionId)
        {
            var dataProvider = A.Fake<IDataProvider>();
            var competitionProvider = new CompetitionProvider(dataProvider);

            var action = () => competitionProvider.GetCompetitionAsync(competitionId);

            await action.Should().ThrowAsync<ArgumentException>();
        }

        [TestCase("")]
        [TestCase("  ")]
        [TestCase(null)]
        public async Task When_giving_invalid_competition_id_to_get_competion_scorers_Then_should_throw_exception(
            string competitionId)
        {
            var dataProvider = A.Fake<IDataProvider>();
            var competitionProvider = new CompetitionProvider(dataProvider);

            var action = () => competitionProvider.GetScorersForCompetitionAsync(competitionId);

            await action.Should().ThrowAsync<ArgumentException>();
        }

        [Test]
        public async Task When_giving_invalid_season_number_to_get_competion_scorers_Then_should_throw_exception()
        {
            var dataProvider = A.Fake<IDataProvider>();
            var competitionProvider = new CompetitionProvider(dataProvider);

            var action = () => competitionProvider.GetScorersForCompetitionAsync("SA", season: -1);

            await action.Should().ThrowAsync<ArgumentOutOfRangeException>();
        }

        [Test]
        public async Task When_giving_invalid_match_day_to_get_competion_scorers_Then_should_throw_exception()
        {
            var dataProvider = A.Fake<IDataProvider>();
            var competitionProvider = new CompetitionProvider(dataProvider);

            var action = () => competitionProvider.GetScorersForCompetitionAsync("SA", matchDay: -1);

            await action.Should().ThrowAsync<ArgumentOutOfRangeException>();
        }

        [Test]
        public async Task When_giving_invalid_area_ids_Then_should_throw_exception()
        {
            var dataProvider = A.Fake<IDataProvider>();
            var competitionProvider = new CompetitionProvider(dataProvider);

            var action = () => competitionProvider.GetAvailableCompetitionsByAreaAsync(null);

            await action.Should().ThrowAsync<ArgumentNullException>();
        }
    }
}
