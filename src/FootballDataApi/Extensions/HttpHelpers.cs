using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FootballDataApi.Extensions
{
    public static class HttpHelpers
    {
        public static string AddFiltersToUrl(string baseUrl, string[] filters)
        {
            if (filters.Length == 0)
                return baseUrl;

            if (filters.Length % 2 != 0)
                throw new ArgumentException("Respect the key / value in filters (args=value)");

            var urlWithFilters = $"{baseUrl}/?";
            for (int i = 0; i < filters.Length; i += 2)
            {
                urlWithFilters = $"{urlWithFilters}{filters[i]}={filters[i + 1]}&";
            }
            urlWithFilters = urlWithFilters.Remove(urlWithFilters.Length - 1);

            return urlWithFilters;
        }

        internal static IEnumerable<string> FilterNotPresentInList(string[] authorizedFilters, string[] filters)
        {
            var parametersNotPresent = filters
                .Where((filter, index) => index % 2 == 0 &&
                    !authorizedFilters.Contains(filter))
                .ToList();

            return parametersNotPresent;
        }

        public static void VerifyFilters(string[] givenFilters, string[] authorizedFilters)
        {
            if (givenFilters.Length % 2 != 0)
                throw new ArgumentException("Respect key value parameters.");

            var parametersNotPresent = FilterNotPresentInList(authorizedFilters, givenFilters);

            if (parametersNotPresent.Count() > 0)
                throw new ArgumentException($"This filters are not supported : \n { string.Join("\n", parametersNotPresent) }");

            if (givenFilters.Contains("matchday"))
                VerifyMatchDayFilterValid(GetValueOfFilter(givenFilters, "matchday"));

            if (givenFilters.Contains("status"))
                VerifyStatusFilterValid(GetValueOfFilter(givenFilters, "status"));

            if (givenFilters.Contains("venue"))
                VerifyVenueFilterValid(GetValueOfFilter(givenFilters, "venue"));

            if (givenFilters.Contains("dateFrom"))
                VerifyDateFilterValid(GetValueOfFilter(givenFilters, "dateFrom"));

            if (givenFilters.Contains("dateTo"))
                VerifyDateFilterValid(GetValueOfFilter(givenFilters, "dateTo"));

            if (givenFilters.Contains("stage"))
                VerifyStageFilterValid(GetValueOfFilter(givenFilters, "stage"));
        }

        public static void VerifyActionParameters(int id, string[] givenFilters, string[] authorizedFilters)
        {
            if (id < 0)
                throw new IndexOutOfRangeException("ID cannot be negative");

            if (givenFilters?.Length > 0)
                VerifyFilters(givenFilters, authorizedFilters);
        }

        internal static void VerifyMatchDayFilterValid(string matchDay)
        {
            var isInteger = int.TryParse(matchDay, out var result);

            if (!isInteger || result < 0)
                throw new ArgumentException("The match day filter must be a positive integer");
        }

        internal static void VerifyStatusFilterValid(string status)
        {
            var validStatus = new string[] { "SCHEDULED", "LIVE", "IN_PLAY", "PAUSED", "FINISHED", "POSTPONED", "SUSPENDED", "CANCELED" };
            var contain = validStatus.Contains(status);

            if (!contain)
                throw new ArgumentException($"The status filter must be one of this valid status :\n{string.Join("\n", validStatus) }");
        }

        internal static void VerifyVenueFilterValid(string venue)
        {
            var validVenue = new string[] { "HOME", "AWAY" };
            var contain = validVenue.Contains(venue);

            if (!contain)
                throw new ArgumentException($"The venue filter must be one of this valid venues :\n{string.Join("\n", validVenue) }");
        }

        internal static void VerifyDateFilterValid(string date)
        {
            var result = DateTime.TryParseExact(date, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out var validDate);

            if (!result)
                throw new ArgumentException("The datetime format must be like YYYY-MM-dd");
        }

        internal static void VerifyStageFilterValid(string stage)
        {
            Regex regex = new Regex("[A-Z]+");
            var result = regex.Match(stage);

            if (!result.Success)
                throw new ArgumentException("The stage filter must be in upper case and contain only [A-Z] characters");
        }

        private static string GetValueOfFilter(string[] givenFilters, string filter)
        {
            return givenFilters.ElementAt(Array.IndexOf(givenFilters, filter) + 1);
        }
    }
}
