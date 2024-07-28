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
    [TestFixture(TestOf = typeof(AreaProvider))]
    internal sealed class AreaProviderTests
    {
        [Test]
        public async Task When_giving_invalid_area_id_Then_should_throw_exception()
        {
            var dataProvider = new AreaDataProvider();
            var areaProvider = new AreaProvider(dataProvider);

            var action = () => areaProvider.GetAreaByIdAsync(-1);

            await action.Should().ThrowAsync<ArgumentOutOfRangeException>();
        }

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

            areaTreeStructure.ChildAreas.Should().NotBeEmpty();
            areaTreeStructure.ChildAreas.Should().HaveCount(2);
            areaTreeStructure.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public async Task When_getting_all_areas_Then_should_receive_expected_values()
        {
            var expectedResult = new List<DetailedArea>
            {
                new DetailedArea
                {
                    Id = 2103,
                    Name = "Haiti",
                    Flag = null,
                    CountryCode = "HTI",
                    ParentArea = "N/C America",
                    ParentAreaId = 2159
                },
                new DetailedArea
                {
                    Id = 2104,
                    Name = "Honduras",
                    Flag = null,
                    CountryCode = "HND",
                    ParentArea = "N/C America",
                    ParentAreaId = 2159
                },
                new DetailedArea
                {
                    Id = 2105,
                    Name = "Hong Kong",
                    Flag = null,
                    CountryCode = "HKG",
                    ParentArea = "Asia",
                    ParentAreaId = 2014
                },
                new DetailedArea
                {
                    Id = 2171,
                    Name = "Northern Ireland",
                    Flag = "https://crests.football-data.org/829.svg",
                    CountryCode = "NIR",
                    ParentArea = "Europe",
                    ParentAreaId = 2077
                },
                new DetailedArea
                {
                    Id = 2173,
                    Name = "Norway",
                    Flag = "https://crests.football-data.org/813.svg",
                    CountryCode = "NOR",
                    ParentArea = "Europe",
                    ParentAreaId = 2077
                },
                new DetailedArea
                {
                    Id = 2272,
                    Name = "Zimbabwe",
                    CountryCode = "ZIM",
                    Flag = null,
                    ParentAreaId = 2001,
                    ParentArea = "Africa"
                }
            };

            var dataProvider = new AreaDataProvider();
            var areaProvider = new AreaProvider(dataProvider);

            var areas = await areaProvider.GetAllAreasAsync();

            areas.Should().NotBeEmpty();
            areas.Should().HaveCount(6);
            areas.Should().BeEquivalentTo(expectedResult);
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
