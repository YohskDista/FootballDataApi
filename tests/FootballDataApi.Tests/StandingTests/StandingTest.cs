using FootballDataApi.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDataApi.Tests.StandingTests
{
    [TestFixture]
    public class StandingTest
    {
        private StandingProvider _standingController;

        [SetUp]
        public void MatchTestSetUp()
        {
            IStanding standing = new StandingSource();
            _standingController = new StandingProvider(standing);
        }

        [Test]
        public void GetStandingOfCompetition_Return_IndexOutOfRangeException_When_Id_IsNegative()
        {
            Assert.ThrowsAsync<IndexOutOfRangeException>(() => _standingController.GetStandingOfCompetition(-1));
        }

        [Test]
        public void Team_MustNotBe_Null_InFirstStanding()
        {
            var standing = _standingController.GetStandingOfCompetition(10).Result;

            Assert.IsNotNull(standing);

            var firstTeam = standing.Standings.FirstOrDefault().Table.FirstOrDefault();

            Assert.IsNotNull(firstTeam);
            Assert.IsNotNull(firstTeam.Team);
        }
    }
}
