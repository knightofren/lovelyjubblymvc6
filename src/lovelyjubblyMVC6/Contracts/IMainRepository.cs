using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lovelyjubblyMVC6.Models;
using Microsoft.AspNet.Mvc;

namespace lovelyjubblyMVC6.Contracts
{
    public interface IMainRepository : IDisposable
    {
        IQueryable<Team> GetTeams();
        Team GetTeamById(int teamId);
        Team GetTeamByTeamName(string teamName);
        Team AddTeam(Team team);
        Team UpdateTeam(Team team);
        bool DeleteTeam(int teamId);
        IQueryable<Fixture> GetFixtures();
        Fixture GetFixtureById(int fixtureId);
        Fixture AddFixture(Fixture fixture);
        Fixture UpdateFixture(Fixture fixture);
        bool DeleteFixture(int fixtureId);
        IQueryable<Division> GetDivisions();
        Division GetDivisionById(int divisionId);
        Division GetDivisionByDivisionName(string divisionName);
        IQueryable<QBRating> GetQBRatings();
        QBRating GetQBRatingById(int qbRatingId);
        IQueryable<QBRating> GetQBRatingsBySeason(string season);
    }
}