using FakeItEasy;
using FluentAssertions;
using FootballDataApi.Models;
using FootballDataApi.Services;
using NUnit.Framework;
using System;
using System.ComponentModel;
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

        [TestCase("")]
        [TestCase("  ")]
        [TestCase(null)]
        public async Task When_giving_invalid_competition_id_to_get_teams_Then_should_throw_exception(
            string competitionId)
        {
            var dataProvider = A.Fake<IDataProvider>();
            var competitionProvider = new CompetitionProvider(dataProvider);

            var action = () => competitionProvider.GetCompetitionTeamsAsync(competitionId);

            await action.Should().ThrowAsync<ArgumentException>();
        }

        [Test]
        public async Task When_giving_invalid_season_to_get_teams_Then_should_throw_exception()
        {
            var dataProvider = A.Fake<IDataProvider>();
            var competitionProvider = new CompetitionProvider(dataProvider);

            var action = () => competitionProvider.GetCompetitionTeamsAsync("BEL", -1);

            await action.Should().ThrowAsync<ArgumentOutOfRangeException>();
        }


        [TestCase("")]
        [TestCase("  ")]
        [TestCase(null)]
        public async Task When_giving_invalid_competition_id_to_get_all_competition_matches_Then_should_throw_exception(
            string competitionId)
        {
            var dataProvider = A.Fake<IDataProvider>();
            var competitionProvider = new CompetitionProvider(dataProvider);

            var action = () => competitionProvider.GetAllMatchesOfCompetitionBetweenAsync(
                competitionId, 
                DateTime.MinValue, 
                DateTime.MaxValue);

            await action.Should().ThrowAsync<ArgumentException>();
        }

        [Test]
        public async Task When_start_is_greater_than_end_to_get_all_competition_matches_Then_should_throw_exception()
        {
            var dataProvider = A.Fake<IDataProvider>();
            var competitionProvider = new CompetitionProvider(dataProvider);

            var action = () => competitionProvider.GetAllMatchesOfCompetitionBetweenAsync(
                "BEL",
                DateTime.Now,
                DateTime.Now.AddDays(-1));

            await action.Should().ThrowAsync<ArgumentException>();
        }

        [Test]
        public async Task When_giving_invalid_status_Then_should_throw_exception()
        {
            var dataProvider = A.Fake<IDataProvider>();
            var competitionProvider = new CompetitionProvider(dataProvider);

            var action = () => competitionProvider.GetAllMatchesOfCompetitionBetweenAsync(
                "BEL",
                DateTime.MinValue,
                DateTime.MaxValue,
                (Status)100);

            await action.Should().ThrowAsync<InvalidEnumArgumentException>().WithParameterName("status");
        }

        [Test]
        public async Task When_giving_invalid_group_Then_should_throw_exception()
        {
            var dataProvider = A.Fake<IDataProvider>();
            var competitionProvider = new CompetitionProvider(dataProvider);

            var action = () => competitionProvider.GetAllMatchesOfCompetitionBetweenAsync(
                "BEL",
                DateTime.MinValue,
                DateTime.MaxValue,
                group: (Group)100);

            await action.Should().ThrowAsync<InvalidEnumArgumentException>().WithParameterName("group");
        }

        [Test]
        public async Task When_giving_invalid_stage_Then_should_throw_exception()
        {
            var dataProvider = A.Fake<IDataProvider>();
            var competitionProvider = new CompetitionProvider(dataProvider);

            var action = () => competitionProvider.GetAllMatchesOfCompetitionBetweenAsync(
                "BEL",
                DateTime.MinValue,
                DateTime.MaxValue,
                stage: (Stage)100);

            await action.Should().ThrowAsync<InvalidEnumArgumentException>().WithParameterName("stage");
        }
    }
}
