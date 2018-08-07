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
        private TeamSource _teamSource;

        [SetUp]
        public void TeamTestSetUp()
        {
            _teamSource = new TeamSource();
        }

        [Test]
        public void MethodWhoReceive_Id_ToFoundData_MustReturn_IndexOutOfRange_IfParameter_IsNotValid()
        {
            Assert.ThrowsAsync<IndexOutOfRangeException>(() => _teamSource.GetTeamByCompetition(-1));
            Assert.ThrowsAsync<IndexOutOfRangeException>(() => _teamSource.GetTeamById(-1));
        }

        [Test]
        public void GetTeamByCompetition_CanOnlyReceive_StageFilter_OtherwiseThrowException()
        {
            Assert.ThrowsAsync<ArgumentException>(() => _teamSource.GetTeamByCompetition(2001, new string[] { "hello", "ciao" }));

            var teams = _teamSource.GetTeamByCompetition(2001, new string[] { "stage", "SEMI_FINAL" }).Result;

            Assert.IsNotNull(teams);
            Assert.AreEqual(teams.Count(), 4);
        }
    }
}
