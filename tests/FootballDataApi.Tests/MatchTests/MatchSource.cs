using FootballDataApi.Interfaces;
using FootballDataApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDataApi.Tests.MatchTests
{
    public class MatchSource : IMatch
    {
        private readonly List<Match> listMatchMockup;

        public MatchSource()
        {
            listMatchMockup = new List<Match>
            {
                new Match {
                    Id = 1,
                    Attendance = 1000,
                    HomeTeam = new MatchTeam
                    {
                        Id = 100
                    },
                    AwayTeam = new MatchTeam
                    {
                        Id = 101
                    },
                    Competition = new Competition { Id = 1 }
                },
                new Match {
                    Id = 2,
                    Attendance = 1000,
                    HomeTeam = new MatchTeam
                    {
                        Id = 101
                    },
                    AwayTeam = new MatchTeam
                    {
                        Id = 102
                    },
                    Competition = new Competition { Id = 2 }
                },
                new Match {
                    Id = 3,
                    Attendance = 5000,
                    HomeTeam = new MatchTeam
                    {
                        Id = 100
                    },
                    AwayTeam = new MatchTeam
                    {
                        Id = 103
                    },
                    Competition = new Competition { Id = 2 }
                }
            };
        }

        public Task<IEnumerable<Match>> GetAllMatches(params string[] filters)
        {
            return Task.Run(() => listMatchMockup.AsEnumerable());
        }

        public Task<IEnumerable<Match>> GetAllMatchOfCompetition(int idCompetition, params string[] filters)
        {
            return Task.Run(() => listMatchMockup.Where(T => T.Competition.Id == idCompetition));
        }

        public Task<IEnumerable<Match>> GetAllMatchOfTeam(int idTeam, params string[] filters)
        {
            return Task.Run(() => listMatchMockup.Where(T => T.AwayTeam.Id == idTeam || T.HomeTeam.Id == idTeam));
        }

        public Task<Match> GetMatchById(int idMatch)
        {
            return Task.Run(() => listMatchMockup.FirstOrDefault(T => T.Id == idMatch));
        }
    }
}
