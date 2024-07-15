using FluentAssertions;
using FootballDataApi.Services;
using NUnit.Framework;
using System;

namespace FootballDataApi.Tests.MatchTests;

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

        result.Should().HaveCount(3);
    }

    [Test]
    public void GetMatchesByCompetition_Must_Return_ThreeResults()
    {
        var result = _matchProvider.GetAllMatchOfCompetition(2000).Result;

        result.Should().HaveCount(3);
    }

    [Test]
    public void GetMatchesByTeam_Must_Return_OneResult()
    {
        var result = _matchProvider.GetAllMatchOfTeam(794).Result;

        result.Should().HaveCount(1);
    }

    [Test]
    public void GetMatchesById_Must_Return_OneResultOnly()
    {
        var result = _matchProvider.GetMatchById(200045).Result;

        result.Should().NotBeNull();
        result.HomeTeam.Name.Should().Be("Poland");
    }

    [Test]
    public void VerifyThatNoData_IsNull_InTheFirstMatch()
    {
        var result = _matchProvider.GetMatchById(200045).Result;

        result.Should().NotBeNull();

        result.Referees.Should().NotBeNull();

        result.HomeTeam.Should().NotBeNull();
        result.HomeTeam.Captain.Should().NotBeNull();
        result.HomeTeam.Lineup.Should().NotBeNull();
        result.HomeTeam.Bench.Should().NotBeNull();

        result.AwayTeam.Should().NotBeNull();
        result.AwayTeam.Captain.Should().NotBeNull();
        result.AwayTeam.Lineup.Should().NotBeNull();
        result.AwayTeam.Bench.Should().NotBeNull();

        result.Referees.Should().HaveCount(4);
        result.HomeTeam.Lineup.Should().HaveCount(11);
        result.AwayTeam.Lineup.Should().HaveCount(11);
        result.HomeTeam.Bench.Should().HaveCount(12);
        result.AwayTeam.Bench.Should().HaveCount(11);
    }
}
