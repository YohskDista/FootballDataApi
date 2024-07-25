using FakeItEasy;
using FluentAssertions;
using FootballDataApi.Models;
using FootballDataApi.Services;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FootballDataApi.Tests
{
    [TestFixture]
    internal sealed class AreaProviderTests
    {
        [Test]
        public async Task When_getting_area_by_id_Then_should_receive_expected_values()
        {
            var expectedResult = new AreaTreeStructure
            {
                Id = 2077,
                Name = "Europe",
                Code = "EUR",
                Flag = "https://crests.football-data.org/EUR.svg",
                ParentArea = "World",
                ParentAreaId = 2267,
                ChildAreas = new List<DetailedArea>
                {
                    new DetailedArea
                    {
                        Id = 2002,
                        Name = "Albania",
                        Flag = null,
                        CountryCode = "ALB",
                        ParentArea = "Europe",
                        ParentAreaId = 2077
                    },
                    new DetailedArea
                    {
                        Id = 2012,
                        Name = "Armenia",
                        Flag = "https://crests.football-data.org/1970.svg",
                        CountryCode = "ARM",
                        ParentArea = "Europe",
                        ParentAreaId = 2077
                    }
                }
            };


            var dataProvider = new AreaDataProvider();
            var areaProvider = new AreaProvider(dataProvider);

            var areaTreeStructure = await areaProvider.GetAreaByIdAsync(10);
            var serializedStructure = JsonConvert.SerializeObject(areaTreeStructure);

            areaTreeStructure.ChildAreas.Should().NotBeEmpty();
            areaTreeStructure.ChildAreas.Should().HaveCount(2);
            areaTreeStructure.Should().BeEquivalentTo(expectedResult);
        }

        private class AreaDataProvider : IDataProvider
        {
            public async Task<T> GetAsync<T>(string requestUri, CancellationToken cancellationToken = default)
            {
                var fileToLoad = requestUri.Contains("areas/10") ? @"Data\Areas.json" : @"Data\AllAreas.json";

                var content = await File.ReadAllTextAsync(fileToLoad);

                return JsonConvert.DeserializeObject<T>(content);
            }
        }
    }
}
