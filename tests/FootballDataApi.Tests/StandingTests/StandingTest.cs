﻿using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace FootballDataApi.Tests.StandingTests;

[TestFixture]
public class StandingTest
{
    private StandingSource _standingSource;

    [SetUp]
    public void MatchTestSetUp()
    {
        _standingSource = new StandingSource();
    }

    [Test]
    public void GetStandingOfCompetition_Return_IndexOutOfRangeException_When_Id_IsNegative()
    {
        Assert.ThrowsAsync<IndexOutOfRangeException>(() => _standingSource.GetStandingOfCompetition(-1));
    }

    [Test]
    public void Team_MustNotBe_Null_InFirstStanding()
    {
        var standing = _standingSource.GetStandingOfCompetition(10).Result;

        standing.Should().NotBeNull();

        var firstTeam = standing.Standings.FirstOrDefault().Table.FirstOrDefault();

        firstTeam.Should().NotBeNull();
        firstTeam.Team.Should().NotBeNull();
    }
}
