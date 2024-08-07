﻿using FluentAssertions;
using NUnit.Framework;
using System;

namespace FootballDataApi.Tests.CompetitionTests;

[TestFixture]
public class CompetitionTest
{
    private CompetitionSource _competitionSource;

    [SetUp]
    public void CompetitionSetUp()
    {
        _competitionSource = new CompetitionSource();
    }

    [Test]
    public void MethodWhoReceive_Id_ToFoundData_MustReturn_IndexOutOfRange_IfParameter_IsNotValid()
    {
        Assert.ThrowsAsync<IndexOutOfRangeException>(() => _competitionSource.GetAvailableCompetitionByArea(-1));
        Assert.ThrowsAsync<IndexOutOfRangeException>(() => _competitionSource.GetCompetition(-1));
    }

    [Test]
    public void GetCompetitionByArea_MustReturn_OneResult_With_AreaCorrespondingTo_World()
    {
        var competition = _competitionSource.GetAvailableCompetitionByArea(2267).Result;

        competition.Should().NotBeEmpty();
        competition.Should().HaveCount(1);
    }

    [Test]
    public void GetCompetitionById_MustReturn_OneOrNoResult()
    {
        var competition = _competitionSource.GetCompetition(1).Result;

        competition.Should().BeNull();

        competition = _competitionSource.GetCompetition(2000).Result;

        competition.Should().NotBeNull();
    }

    [Test]
    public void DeserializationOfCompetition_HaveNot_NullValues()
    {
        var competition = _competitionSource.GetCompetition(2000).Result;

        competition.Should().NotBeNull();
        competition.Area.Should().NotBeNull();
        competition.CurrentSeason.Should().NotBeNull();
    }
}
