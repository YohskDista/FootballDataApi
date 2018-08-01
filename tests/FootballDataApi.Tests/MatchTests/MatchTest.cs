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
        private MatchController _matchController;

        [SetUp]
        public void MatchTestSetUp()
        {
            IMatch match = new MatchSource();
            _matchController = new MatchController(match);
        }

        [Test]
        [TestCase("http://test-url.ch", new string[] { "name", "hello", "surname", "world" }, "http://test-url.ch/?name=hello&surname=world")]
        [TestCase("http://test-url.ch", new string[] { "name", "hello" }, "http://test-url.ch/?name=hello")]
        [TestCase("http://test-url.ch", new string[] { }, "http://test-url.ch")]
        public void AddFiltersToUrl_With_GivenFilters_MustReturn_CorrectUrl(string baseUrl, string[] filters, string expectedUrl)
        {
            var urlWithFilters = HttpExtensions.AddFiltersToUrl(baseUrl, filters);

            Assert.AreEqual(expectedUrl, urlWithFilters);
        }

        [Test]
        public void AddFiltersToUrl_With_GivenFilter_MustThrow_ArgumentException()
        {
            var baseUrl = "http://test-url.ch";
            var filters = new string[] { "test" };
            
            Assert.Throws<ArgumentException>(() => HttpExtensions.AddFiltersToUrl(baseUrl, filters));
        }

        [Test]
        public void GetMatchById_MustThrow_IndexOutOfRangeException_If_IdIsNegative()
        {
            Assert.ThrowsAsync<IndexOutOfRangeException>(() => _matchController.GetMatchById(-1));
        }

        [Test]
        public void GetAllMatchByTeam_MustThrow_IndexOutOfRangeException_If_IdIsNegative()
        {
            Assert.ThrowsAsync<IndexOutOfRangeException>(() => _matchController.GetAllMatchOfTeam(-1));
        }

        [Test]
        public void GetAllMatchOfCompetition_MustThrow_IndexOutOfRangeException_If_IdIsNegative()
        {
            Assert.ThrowsAsync<IndexOutOfRangeException>(() => _matchController.GetAllMatchOfCompetition(-1));
        }

        [Test]
        public void AllMatchesMethods_WhoHaveFilters_MustVerifyThat_TheFilters_AreValid()
        {
            Assert.ThrowsAsync<ArgumentException>(() => _matchController.GetAllMatches("test"), "Respect key value parameters.");
            Assert.ThrowsAsync<ArgumentException>(() => _matchController.GetAllMatches("test", "value"), "This filters are not supported: \n test");

            Assert.ThrowsAsync<ArgumentException>(() => _matchController.GetAllMatchOfCompetition(1, "test"), "Respect key value parameters.");
            Assert.ThrowsAsync<ArgumentException>(() => _matchController.GetAllMatchOfCompetition(1, "test", "value"), "This filters are not supported: \n test");


            Assert.ThrowsAsync<ArgumentException>(() => _matchController.GetAllMatchOfTeam(1, "test"), "Respect key value parameters.");
            Assert.ThrowsAsync<ArgumentException>(() => _matchController.GetAllMatchOfTeam(1, "test", "value", "hello", "world"), "This filters are not supported: \n test\nworld");
        }

        [Test]
        public void GetAllMatches_Must_Return_ThreeResults()
        {
            var result = _matchController.GetAllMatches().Result;

            Assert.NotZero(result.Count());
            Assert.AreEqual(result.Count(), 3);
        }

        [Test]
        public void GetMatchesByCompetition_Must_Return_ThreeResults()
        {
            var result = _matchController.GetAllMatchOfCompetition(2000).Result;

            Assert.NotZero(result.Count());
            Assert.AreEqual(result.Count(), 3);
        }

        [Test]
        public void GetMatchesByTeam_Must_Return_OneResult()
        {
            var result = _matchController.GetAllMatchOfTeam(794).Result;

            Assert.NotZero(result.Count());
            Assert.AreEqual(result.Count(), 1);
        }

        [Test]
        public void GetMatchesById_Must_Return_OneResultOnly()
        {
            var result = _matchController.GetMatchById(200045).Result;

            Assert.NotNull(result);
            Assert.AreEqual(result.HomeTeam.Name, "Poland");
        }
    }
}
