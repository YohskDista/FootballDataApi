using FluentAssertions;
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

        expectedUrl.Should().BeEquivalentTo(urlWithFilters);
    }

    [Test]
    public void AddFiltersToUrl_With_GivenFilter_MustThrow_ArgumentException()
    {
        var baseUrl = "http://test-url.ch";
        var filters = new string[] { "test" };

        Assert.Throws<ArgumentException>(() => HttpHelpers.AddFiltersToUrl(baseUrl, filters));
    }
}
