using FootballDataApi.Extensions;
using NUnit.Framework;
using System;

namespace FootballDataApi.Tests;

[TestFixture]
public class HttpHelpersTests
{
    private static string[] authorizedFilters = new string[] { "dateFrom", "dateTo", "stage", "status", "matchday", "group", "venue" };

    [Test]
    [TestCase("http://test-url.ch", new string[] { "name", "hello", "surname", "world" }, "http://test-url.ch/?name=hello&surname=world")]
    [TestCase("http://test-url.ch", new string[] { "name", "hello" }, "http://test-url.ch/?name=hello")]
    [TestCase("http://test-url.ch", new string[] { }, "http://test-url.ch")]
    public void AddFiltersToUrl_With_GivenFilters_MustReturn_CorrectUrl(string baseUrl, string[] filters, string expectedUrl)
    {
        var urlWithFilters = HttpHelpers.AddFiltersToUrl(baseUrl, filters);

        Assert.AreEqual(expectedUrl, urlWithFilters);
    }

    [Test]
    public void AddFiltersToUrl_With_GivenFilter_MustThrow_ArgumentException()
    {
        var baseUrl = "http://test-url.ch";
        var filters = new string[] { "test" };

        Assert.Throws<ArgumentException>(() => HttpHelpers.AddFiltersToUrl(baseUrl, filters));
    }

    [Test]
    public void VerifyMatchDayFilter_IfAnInvalidData_IsGiven_Then_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => HttpHelpers.VerifyFilters(new string[] { "matchday", "-1" }, authorizedFilters));
        Assert.Throws<ArgumentException>(() => HttpHelpers.VerifyFilters(new string[] { "matchday", "hello" }, authorizedFilters));

        Assert.DoesNotThrow(() => HttpHelpers.VerifyFilters(new string[] { "matchday", "1" }, authorizedFilters));
    }

    [Test]
    public void VerifyStatusFilter_IfAnInvalidData_IsGiven_Then_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => HttpHelpers.VerifyFilters(new string[] { "status", "live" }, authorizedFilters));
        Assert.Throws<ArgumentException>(() => HttpHelpers.VerifyFilters(new string[] { "status", "world" }, authorizedFilters));
        Assert.Throws<ArgumentException>(() => HttpHelpers.VerifyFilters(new string[] { "status", "hello" }, authorizedFilters));

        Assert.DoesNotThrow(() => HttpHelpers.VerifyFilters(new string[] { "status", "CANCELED" }, authorizedFilters));
    }

    [Test]
    public void VerifyStageFilter_IfAnInvalidData_IsGiven_Then_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => HttpHelpers.VerifyFilters(new string[] { "stage", "live0" }, authorizedFilters));
        Assert.Throws<ArgumentException>(() => HttpHelpers.VerifyFilters(new string[] { "stage", "hello_world" }, authorizedFilters));

        Assert.DoesNotThrow(() => HttpHelpers.VerifyFilters(new string[] { "stage", "CoUCOU" }, authorizedFilters));
        Assert.DoesNotThrow(() => HttpHelpers.VerifyFilters(new string[] { "stage", "CANCELED" }, authorizedFilters));
    }

    [Test]
    [TestCase("home", false)]
    [TestCase("HOME", true)]
    [TestCase("Hello", false)]
    [TestCase("HoME", false)]
    [TestCase("away", false)]
    [TestCase("AWAY", true)]
    public void VerifyVenueFilterValid_IfAnInvalidData_IsGiven_Then_ThrowsException(string data, bool expectedResult)
    {
        var result = true;
        try
        {
            HttpHelpers.VerifyFilters(new string[] { "venue", data }, authorizedFilters);
        }
        catch (ArgumentException)
        {
            result = false;
        }

        Assert.AreEqual(expectedResult, result);
    }

    [Test]
    [TestCase("2018-12-22", true)]
    [TestCase("2018-6-22", false)]
    [TestCase("18-12-22", false)]
    [TestCase("22.04.1998", false)]
    [TestCase("2018-12-22 16:07:00", false)]
    public void VerifyDateFilterValid_ThatTheDate_IsInTheCorrectFormat_Otherwise_ThrowException(string data, bool expectedResult)
    {
        var result = true;
        try
        {
            HttpHelpers.VerifyFilters(new string[] { "dateFrom", data }, authorizedFilters);
        }
        catch (ArgumentException)
        {
            result = false;
        }

        Assert.AreEqual(expectedResult, result);
    }
}
