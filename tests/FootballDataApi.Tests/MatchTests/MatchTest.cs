using FootballDataApi.Extensions;
using FootballDataApi.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDataApi.Tests.MatchTests
{
    [TestFixture]
    public class MatchTest
    {
        private IMatchProvider _matchProvider;

        [SetUp]
        public void MatchTestSetUp()
        {
            _matchProvider = new MatchSource();
        }

        [Test]
        public void GetMatchById_MustThrow_IndexOutOfRangeException_If_IdIsNegative()
        {
            Assert.ThrowsAsync<IndexOutOfRangeException>(() => _matchProvider.GetMatchById(-1));
        }

        [Test]
        public void GetAllMatchByTeam_MustThrow_IndexOutOfRangeException_If_IdIsNegative()
        {
            Assert.ThrowsAsync<IndexOutOfRangeException>(() => _matchProvider.GetAllMatchOfTeam(-1));
        }

        [Test]
        public void GetAllMatchOfCompetition_MustThrow_IndexOutOfRangeException_If_IdIsNegative()
        {
            Assert.ThrowsAsync<IndexOutOfRangeException>(() => _matchProvider.GetAllMatchOfCompetition(-1));
        }

        [Test]
        public void AllMatchesMethods_WhoHaveFilters_MustVerifyThat_TheFilters_AreValid()
        {
            Assert.ThrowsAsync<ArgumentException>(() => _matchProvider.GetAllMatches("test"), "Respect key value parameters.");
            Assert.ThrowsAsync<ArgumentException>(() => _matchProvider.GetAllMatches("test", "value"), "This filters are not supported: \n test");

            Assert.ThrowsAsync<ArgumentException>(() => _matchProvider.GetAllMatchOfCompetition(1, "test"), "Respect key value parameters.");
            Assert.ThrowsAsync<ArgumentException>(() => _matchProvider.GetAllMatchOfCompetition(1, "test", "value"), "This filters are not supported: \n test");


            Assert.ThrowsAsync<ArgumentException>(() => _matchProvider.GetAllMatchOfTeam(1, "test"), "Respect key value parameters.");
            Assert.ThrowsAsync<ArgumentException>(() => _matchProvider.GetAllMatchOfTeam(1, "test", "value", "hello", "world"), "This filters are not supported: \n test\nworld");
        }

        [Test]
        public void GetAllMatches_Must_Return_ThreeResults()
        {
            var result = _matchProvider.GetAllMatches().Result;

            Assert.NotZero(result.Count());
            Assert.AreEqual(result.Count(), 3);
        }

        [Test]
        public void GetMatchesByCompetition_Must_Return_ThreeResults()
        {
            var result = _matchProvider.GetAllMatchOfCompetition(2000).Result;

            Assert.NotZero(result.Count());
            Assert.AreEqual(result.Count(), 3);
        }

        [Test]
        public void GetMatchesByTeam_Must_Return_OneResult()
        {
            var result = _matchProvider.GetAllMatchOfTeam(794).Result;

            Assert.NotZero(result.Count());
            Assert.AreEqual(result.Count(), 1);
        }

        [Test]
        public void GetMatchesById_Must_Return_OneResultOnly()
        {
            var result = _matchProvider.GetMatchById(200045).Result;

            Assert.NotNull(result);
            Assert.AreEqual(result.HomeTeam.Name, "Poland");
        }

        [Test]
        public void VerifyThatNoData_IsNull_InTheFirstMatch()
        {
            var result = _matchProvider.GetMatchById(200045).Result;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Referees);

            Assert.IsNotNull(result.HomeTeam);
            Assert.IsNotNull(result.HomeTeam.Captain);
            Assert.IsNotNull(result.HomeTeam.Lineup);
            Assert.IsNotNull(result.HomeTeam.Bench);

            Assert.IsNotNull(result.AwayTeam);
            Assert.IsNotNull(result.AwayTeam.Captain);
            Assert.IsNotNull(result.AwayTeam.Lineup);
            Assert.IsNotNull(result.AwayTeam.Bench);

            Assert.AreEqual(result.Referees.Count(), 4);
            Assert.AreEqual(result.HomeTeam.Lineup.Count(), 11);
            Assert.AreEqual(result.AwayTeam.Lineup.Count(), 11);

            Assert.AreEqual(result.HomeTeam.Bench.Count(), 12);
            Assert.AreEqual(result.AwayTeam.Bench.Count(), 11);
        }
    }
}
