using FootballDataApi.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDataApi.Tests.TeamTests
{
    [TestFixture]
    public class TeamTest
    {
        private TeamController _teamController;

        [SetUp]
        public void TeamTestSetUp()
        {
            var teamSource = new TeamSource();
            _teamController = new TeamController(teamSource);
        }

        [Test]
        public void MethodWhoReceive_Id_ToFoundData_MustReturn_IndexOutOfRange_IfParameter_IsNotValid()
        {
            Assert.ThrowsAsync<IndexOutOfRangeException>(() => _teamController.GetTeamByCompetition(-1));
            Assert.ThrowsAsync<IndexOutOfRangeException>(() => _teamController.GetTeamById(-1));
        }

        [Test]
        public void GetTeamByCompetition_CanOnlyReceive_StageFilter_OtherwiseThrowException()
        {
            Assert.ThrowsAsync<ArgumentException>(() => _teamController.GetTeamByCompetition(2001, new string[] { "hello", "ciao" }));

            var teams = _teamController.GetTeamByCompetition(2001, new string[] { "stage", "SEMI_FINAL" }).Result;

            Assert.IsNotNull(teams);
            Assert.AreEqual(teams.Count(), 4);
        }
    }
}
