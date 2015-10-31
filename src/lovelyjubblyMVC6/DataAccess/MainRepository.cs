using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lovelyjubblyMVC6.Contracts;
using lovelyjubblyMVC6.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;

namespace lovelyjubblyMVC6.DataAccess
{
    public class MainRepository : IMainRepository
    {
        private readonly lovelyjubblyMVC6WebApiContext _db = new lovelyjubblyMVC6WebApiContext();

        public IQueryable<Team> GetTeams()
        {
            return _db.Teams.Include(t => t.Division).OrderBy(t => t.TeamName).AsQueryable();
        }

        public Team GetTeamById(int teamId)
        {
            return _db.Teams.Include(t => t.Division).FirstOrDefault(c => c.TeamId == teamId);
        }

        public Team GetTeamByTeamName(string teamName)
        {
            return _db.Teams.FirstOrDefault(c => c.TeamName == teamName);
        }

        public Team AddTeam(Team team)
        {
            team.Division = _db.Divisions.FirstOrDefault(t => t.DivisionId == team.DivisionId);

            _db.Teams.Add(team);
            _db.SaveChanges();

            return team;
        }

        public Team UpdateTeam(Team team)
        {
            team.TeamId = team.TeamId;

            team.Division = _db.Divisions.FirstOrDefault(t => t.DivisionId == team.DivisionId);

            _db.Teams.Attach(team);
            _db.Entry(team).State = EntityState.Modified;
            _db.SaveChanges();
            return team;
        }

        public bool DeleteTeam(int teamId)
        {
            var item = _db.Teams.FirstOrDefault(x => x.TeamId == teamId);

            if (item == null)
            {
                return false;
            }
            _db.Teams.Remove(item);
            _db.SaveChanges();

            return true; 
        }

        public IQueryable<Fixture> GetFixtures()
        {
            //[{"FixtureId":1,"Season":"1993","Week":11,"AwayTeamId":23,"AwayTeam":{"TeamId":23,"Logo":null,"TeamName":"Philadelphia Eagles"},"HomeTeamId":13,"HomeTeam":{"TeamId":13,"Logo":null,"TeamName":"Houston Oilers"},"AwayTeamScore":21,"HomeTeamScore":27}]
            return _db.Fixtures.Include(f => f.AwayTeam).Include(f => f.HomeTeam).AsQueryable();
        }

        public Fixture GetFixtureById(int fixtureId)
        {
            var fixture = _db.Fixtures.FirstOrDefault(c => c.FixtureId == fixtureId);

            if (fixture != null)
            {
                fixture.AwayTeam = _db.Teams.FirstOrDefault(t => t.TeamId == fixture.AwayTeamId);
                fixture.HomeTeam = _db.Teams.FirstOrDefault(t => t.TeamId == fixture.HomeTeamId);
            }

            return fixture;
        }

        public Fixture AddFixture(Fixture fixture)
        {
            fixture.AwayTeam = _db.Teams.FirstOrDefault(t => t.TeamId == fixture.AwayTeamId);
            fixture.HomeTeam = _db.Teams.FirstOrDefault(t => t.TeamId == fixture.HomeTeamId);

            _db.Fixtures.Add(fixture);
            _db.SaveChanges();

            return fixture;
        }

        public Fixture UpdateFixture(Fixture fixture)
        {
            fixture.FixtureId = fixture.FixtureId;

            fixture.AwayTeam = _db.Teams.FirstOrDefault(t => t.TeamId == fixture.AwayTeamId);
            fixture.HomeTeam = _db.Teams.FirstOrDefault(t => t.TeamId == fixture.HomeTeamId);

            _db.Fixtures.Attach(fixture);
            _db.Entry(fixture).State = EntityState.Modified;
            _db.SaveChanges();
            return fixture;
        }

        public bool DeleteFixture(int fixtureId)
        {
            var item = _db.Fixtures.FirstOrDefault(x => x.FixtureId == fixtureId);

            if (item == null)
            {
                return false;
            }
            _db.Fixtures.Remove(item);
            _db.SaveChanges();

            return true;
        }

        public IQueryable<Division> GetDivisions()
        {
            return _db.Divisions.OrderBy(t => t.DivisionName).AsQueryable();
        }

        public Division GetDivisionById(int divisionId)
        {
            return _db.Divisions.FirstOrDefault(c => c.DivisionId == divisionId);
        }

        public Division GetDivisionByDivisionName(string divisionName)
        {
            return _db.Divisions.FirstOrDefault(c => c.DivisionName == divisionName);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}