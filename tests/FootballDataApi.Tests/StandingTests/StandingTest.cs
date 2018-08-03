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
        private StandingController _standingController;

        [SetUp]
        public void MatchTestSetUp()
        {
            IStanding standing = new StandingSource();
            _standingController = new StandingController(standing);
        }

        [Test]
        public void GetStandingOfCompetition_Return_IndexOutOfRangeException_When_Id_IsNegative()
        {
            Assert.ThrowsAsync<IndexOutOfRangeException>(() => _standingController.GetStandingOfCompetition(-1));
        }
    }
}
