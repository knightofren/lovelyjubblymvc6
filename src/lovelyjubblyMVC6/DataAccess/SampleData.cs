using Microsoft.Data.Entity;
using Microsoft.Framework.DependencyInjection;
using System;
using System.Linq;
using lovelyjubblyMVC6.Models;

namespace lovelyjubblyMVC6.DataAccess
{
    public static class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<lovelyjubblyMVC6WebApiContext>();

            if (context.Database.AsRelational().Exists())
            {
                if (!context.Divisions.Any())
                {
                    context.Divisions.Add(new Division { DivisionName = "AFC East" });
                    context.Divisions.Add(new Division { DivisionName = "AFC Central" });
                    context.Divisions.Add(new Division { DivisionName = "AFC West" });
                    context.Divisions.Add(new Division { DivisionName = "NFC East" });
                    context.Divisions.Add(new Division { DivisionName = "NFC Central" });
                    context.Divisions.Add(new Division { DivisionName = "NFC West" });
                }

                if (!context.Teams.Any())
                {
                    context.Teams.Add(new Team { TeamName = "Atlanta Falcons" });
                    context.Teams.Add(new Team { TeamName = "Arizona Cardinals" });
                    context.Teams.Add(new Team { TeamName = "Baltimore Ravens" });
                    context.Teams.Add(new Team { TeamName = "Buffalo Bills" });
                    context.Teams.Add(new Team { TeamName = "Carolina Panthers" });
                    context.Teams.Add(new Team { TeamName = "Chicago Bears" });
                    context.Teams.Add(new Team { TeamName = "Cincinnati Bengals" });
                    context.Teams.Add(new Team { TeamName = "Cleveland Browns" });
                    context.Teams.Add(new Team { TeamName = "Dallas Cowboys" });
                    context.Teams.Add(new Team { TeamName = "Denver Broncos" });
                    context.Teams.Add(new Team { TeamName = "Detroit Lions" });
                    context.Teams.Add(new Team { TeamName = "Green Bay Packers" });
                    context.Teams.Add(new Team { TeamName = "Houston Texans" });
                    context.Teams.Add(new Team { TeamName = "Indianapolis Colts" });
                    context.Teams.Add(new Team { TeamName = "Jacksonville Jaguars" });
                    context.Teams.Add(new Team { TeamName = "Kansas City Chiefs" });
                    context.Teams.Add(new Team { TeamName = "Miami Dolphins" });
                    context.Teams.Add(new Team { TeamName = "Minnesota Vikings" });
                    context.Teams.Add(new Team { TeamName = "New England Patriots" });
                    context.Teams.Add(new Team { TeamName = "New Orleans Saints" });
                    context.Teams.Add(new Team { TeamName = "New York Giants" });
                    context.Teams.Add(new Team { TeamName = "New York Jets" });
                    context.Teams.Add(new Team { TeamName = "Oakland Raiders" });
                    context.Teams.Add(new Team { TeamName = "Philadelphia Eagles" });
                    context.Teams.Add(new Team { TeamName = "Pittsburgh Steelers" });
                    context.Teams.Add(new Team { TeamName = "San Diego Chargers" });
                    context.Teams.Add(new Team { TeamName = "San Francisco 49ers" });
                    context.Teams.Add(new Team { TeamName = "Seattle Seahawks" });
                    context.Teams.Add(new Team { TeamName = "St Louis Rams" });
                    context.Teams.Add(new Team { TeamName = "Tampa Bay Buccaneers" });
                    context.Teams.Add(new Team { TeamName = "Tennessee Titans" });
                    context.Teams.Add(new Team { TeamName = "Washington Redskins" });
                    context.Teams.Add(new Team { TeamName = "Houston Oilers" });
                    context.Teams.Add(new Team { TeamName = "Los Angeles Raiders" });
                    context.Teams.Add(new Team { TeamName = "Los Angeles Rams" });
                }

                if (!context.Coaches.Any())
                {
                    context.Coaches.Add(new Coach { CoachName = "Mike Parr" });
                    context.Coaches.Add(new Coach { CoachName = "Tom Richards" });
                    context.Coaches.Add(new Coach { CoachName = "Martyn Williams" });
                    context.Coaches.Add(new Coach { CoachName = "Mark Dawson" });
                    context.Coaches.Add(new Coach { CoachName = "Andrew Risson" });
                    context.Coaches.Add(new Coach { CoachName = "Chris Stones" });
                    context.Coaches.Add(new Coach { CoachName = "Neil Arthurton" });
                    context.Coaches.Add(new Coach { CoachName = "Mike George" });
                    context.Coaches.Add(new Coach { CoachName = "Pete Mason" });
                    context.Coaches.Add(new Coach { CoachName = "Gary Woods" });
                    context.Coaches.Add(new Coach { CoachName = "Jon Gick" });
                    context.Coaches.Add(new Coach { CoachName = "Conrad Whittingham" });
                    context.Coaches.Add(new Coach { CoachName = "Craig Jackson" });
                    context.Coaches.Add(new Coach { CoachName = "Thomas Hennes" });
                    context.Coaches.Add(new Coach { CoachName = "Andreas Horch" });
                    context.Coaches.Add(new Coach { CoachName = "Will Smith" });
                    context.Coaches.Add(new Coach { CoachName = "Greg Salmon" });
                    context.Coaches.Add(new Coach { CoachName = "Jason O'Mahony" });
                    context.Coaches.Add(new Coach { CoachName = "Mike Thorp-Potter" });
                    context.Coaches.Add(new Coach { CoachName = "Paul Gorner" });
                    context.Coaches.Add(new Coach { CoachName = "Darren Halford" });
                    context.Coaches.Add(new Coach { CoachName = "Jean-Francois Briel" });
                    context.Coaches.Add(new Coach { CoachName = "Ian Mallet" });
                    context.Coaches.Add(new Coach { CoachName = "Andy Starkey" });
                    context.Coaches.Add(new Coach { CoachName = "Dave Flesfader" });
                    context.Coaches.Add(new Coach { CoachName = "Alex Coombe" });
                    context.Coaches.Add(new Coach { CoachName = "Ed Prosser" });
                    context.Coaches.Add(new Coach { CoachName = "Sean Young" });
                    context.Coaches.Add(new Coach { CoachName = "Andrew Harris" });
                    context.Coaches.Add(new Coach { CoachName = "Sam Chillari" });
                    context.Coaches.Add(new Coach { CoachName = "Norman Goetz" });
                    context.Coaches.Add(new Coach { CoachName = "Stephen Mowka" });
                    context.Coaches.Add(new Coach { CoachName = "Nick Dean" });
                    context.Coaches.Add(new Coach { CoachName = "Paul De Kievit" });
                    context.Coaches.Add(new Coach { CoachName = "Ben Anderson" });
                    context.Coaches.Add(new Coach { CoachName = "Danny Slavin" });
                    context.Coaches.Add(new Coach { CoachName = "Alasdair Campbell" });
                    context.Coaches.Add(new Coach { CoachName = "Paul Lancaster" });
                    context.Coaches.Add(new Coach { CoachName = "Tim Ufton" });
                    context.Coaches.Add(new Coach { CoachName = "Jonathan Blythe" });
                    context.Coaches.Add(new Coach { CoachName = "David Andre" });
                    context.Coaches.Add(new Coach { CoachName = "Bobby Davis" });
                    context.Coaches.Add(new Coach { CoachName = "Graham Beaton" });
                    context.Coaches.Add(new Coach { CoachName = "Chris Hatfield" });
                    context.Coaches.Add(new Coach { CoachName = "Michael Thompson" });
                    context.Coaches.Add(new Coach { CoachName = "Darren Woodlock" });
                    context.Coaches.Add(new Coach { CoachName = "Mark Gamble" });
                    context.Coaches.Add(new Coach { CoachName = "Kev Houghton" });
                    context.Coaches.Add(new Coach { CoachName = "Alan Horton" });
                    context.Coaches.Add(new Coach { CoachName = "Gavin Ash" });
                    context.Coaches.Add(new Coach { CoachName = "Gary Tunstall" });
                    context.Coaches.Add(new Coach { CoachName = "Andy Woodlock" });
                    context.Coaches.Add(new Coach { CoachName = "Kevin Sweeney" });
                    context.Coaches.Add(new Coach { CoachName = "Dominic Williams" });
                    context.Coaches.Add(new Coach { CoachName = "Troy Dilworth" });
                    context.Coaches.Add(new Coach { CoachName = "Neil Wolstenholme" });
                    context.Coaches.Add(new Coach { CoachName = "Steve Londesbrough" });
                    context.Coaches.Add(new Coach { CoachName = "Mark Hall" });
                    context.Coaches.Add(new Coach { CoachName = "Andrew Doe" });
                    context.Coaches.Add(new Coach { CoachName = "Andrew Fry" });
                    context.Coaches.Add(new Coach { CoachName = "Marcus Stent" });
                    context.Coaches.Add(new Coach { CoachName = "Phil Yeardley" });
                    context.Coaches.Add(new Coach { CoachName = "Will McConchie" });
                    context.Coaches.Add(new Coach { CoachName = "Marc Swan" });
                    context.Coaches.Add(new Coach { CoachName = "Richard Arundale" });
                    context.Coaches.Add(new Coach { CoachName = "Roland Humphrey" });
                    context.Coaches.Add(new Coach { CoachName = "Paul Simpson" });
                    context.Coaches.Add(new Coach { CoachName = "Andrew Gambrill" });
                    context.Coaches.Add(new Coach { CoachName = "Glen Schild" });
                    context.Coaches.Add(new Coach { CoachName = "Stuart Watkin" });
                    context.Coaches.Add(new Coach { CoachName = "Robert Tooze" });
                    context.Coaches.Add(new Coach { CoachName = "Michael Sawley" });
                    context.Coaches.Add(new Coach { CoachName = "Graham Harrison" });
                    context.Coaches.Add(new Coach { CoachName = "Brian Antill" });
                    context.Coaches.Add(new Coach { CoachName = "Martyn Searle" });
                    context.Coaches.Add(new Coach { CoachName = "Gary Jenkins" });
                    context.Coaches.Add(new Coach { CoachName = "Michael Mitchell" });
                    context.Coaches.Add(new Coach { CoachName = "Marcus Marsden" });
                    context.Coaches.Add(new Coach { CoachName = "Steve McArthur" });
                    context.Coaches.Add(new Coach { CoachName = "Garry Swain" });
                    context.Coaches.Add(new Coach { CoachName = "K Hodgson" });
                    context.Coaches.Add(new Coach { CoachName = "Nigel Legg" });
                    context.Coaches.Add(new Coach { CoachName = "Simon Horn" });
                    context.Coaches.Add(new Coach { CoachName = "Michael Isaacs" });
                    context.Coaches.Add(new Coach { CoachName = "Martin Bradley" });
                    context.Coaches.Add(new Coach { CoachName = "Errol Owen" });
                    context.Coaches.Add(new Coach { CoachName = "Jeff Gillan" });
                    context.Coaches.Add(new Coach { CoachName = "Rick Cross" });
                    context.Coaches.Add(new Coach { CoachName = "Paul Fitzpatrick" });
                    context.Coaches.Add(new Coach { CoachName = "Michael Thon" });
                    context.Coaches.Add(new Coach { CoachName = "Andrew Littlechild" });
                    context.Coaches.Add(new Coach { CoachName = "Richard Healy" });
                    context.Coaches.Add(new Coach { CoachName = "Graham Black" });
                    context.Coaches.Add(new Coach { CoachName = "Jamie Walters" });
                    context.Coaches.Add(new Coach { CoachName = "Dave Thorpe" });
                    context.Coaches.Add(new Coach { CoachName = "Neil Spencer" });
                    context.Coaches.Add(new Coach { CoachName = "William Stanbury" });
                    context.Coaches.Add(new Coach { CoachName = "Jamie Cleere" });
                    context.Coaches.Add(new Coach { CoachName = "Wilson Whitelock" });
                    context.Coaches.Add(new Coach { CoachName = "Mark Wilkinson" });
                    context.Coaches.Add(new Coach { CoachName = "Chris Cole" });
                    context.Coaches.Add(new Coach { CoachName = "Phil Smith" });
                    context.Coaches.Add(new Coach { CoachName = "Chris Gilbride" });
                    context.Coaches.Add(new Coach { CoachName = "Michael Parr" });
                    context.Coaches.Add(new Coach { CoachName = "Andy Fry & Andy Doe" });
                    context.Coaches.Add(new Coach { CoachName = "Dave Flesfader/Alex Coombe" });
                    context.Coaches.Add(new Coach { CoachName = "David Andre/Bobby Davis" });
                    context.Coaches.Add(new Coach { CoachName = "Tom Richards/Sean Young" });
                    context.Coaches.Add(new Coach { CoachName = "Dean Freeman" });
                    context.Coaches.Add(new Coach { CoachName = "Colin Bell" });
                    context.Coaches.Add(new Coach { CoachName = "Kevan Parrott" });
                    context.Coaches.Add(new Coach { CoachName = "Pete Davies" });
                }

                context.SaveChanges();
            }
        }
    }
}