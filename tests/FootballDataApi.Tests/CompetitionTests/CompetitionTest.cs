using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDataApi.Tests.CompetitionTests
{
    [TestFixture]
    public class CompetitionTest
    {
        private CompetitionProvider _competitionController;

        [SetUp]
        public void CompetitionSetUp()
        {
            var competitionSource = new CompetitionSource();
            _competitionController = new CompetitionProvider(competitionSource);
        }

        [Test]
        public void MethodWhoReceive_Id_ToFoundData_MustReturn_IndexOutOfRange_IfParameter_IsNotValid()
        {
            Assert.ThrowsAsync<IndexOutOfRangeException>(() => _competitionController.GetAvailableCompetitionByArea(-1));
            Assert.ThrowsAsync<IndexOutOfRangeException>(() => _competitionController.GetCompetition(-1));
        }

        [Test]
        public void GetCompetitionByArea_MustReturn_OneResult_With_AreaCorrespondingTo_World()
        {
            var competition = _competitionController.GetAvailableCompetitionByArea(2267).Result;

            Assert.IsNotEmpty(competition);
            Assert.True(competition.Count() == 1);
        }

        [Test]
        public void GetCompetitionById_MustReturn_OneOrNoResult()
        {
            var competition = _competitionController.GetCompetition(1).Result;

            Assert.IsNull(competition);

            competition = _competitionController.GetCompetition(2000).Result;

            Assert.IsNotNull(competition);
        }

        [Test]
        public void DeserializationOfCompetition_HaveNot_NullValues()
        {
            var competition = _competitionController.GetCompetition(2000).Result;

            Assert.IsNotNull(competition);
            Assert.IsNotNull(competition.Area);
            Assert.IsNotNull(competition.CurrentSeason);
        }
    }
}
