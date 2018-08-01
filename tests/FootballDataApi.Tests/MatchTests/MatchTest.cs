using FootballDataApi.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDataApi.Tests.MatchTests
{
    [TestFixture]
    public class MatchTests
    {
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
    }
}
