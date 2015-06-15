using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IFoozLiveView.Models;
using IFoozLiveView.Services;

namespace IFoozLiveViewTests
{
    public class TestData : IGameStateService
    {

        public GameState RetrieveCurrent()
        {
            return SetupGameState(5, 5);
        }

        public GameState SetupGameState(int blueGoals = 0, int whiteGoals = 0)
        {
            var players = CreatePlayers("Ken", "Eivind", "Calle", "Frode");

            var blue = CreateTeam(players.Take(2), CreateGoals(count: blueGoals), TeamNames.Blue);
            var white = CreateTeam(players.Skip(2), CreateGoals(count: whiteGoals), TeamNames.White);


            var gamestate = CreateGameState(white, blue);
            return gamestate;
        }

        public List<Goal> CreateGoals(Random rnd = null, int count = 0)
        {
            var result = new List<Goal>();

            count = rnd?.Next(0, 9) ?? count;

            for (int i = 0; i < count; i++)
            {
                var timestamp = DateTime.Now.AddSeconds(-(rnd?.Next(5, 349) ?? 0));

                result.Add(new Goal()
                {
                    Timestamp = timestamp
                });

            }
            return result;

        }


        public List<Player> CreatePlayers(params string[] players)
        {
            var result = new List<Player>();

            for (int i = 0; i < players.Length; i++)
            {
                var player = new Player
                {
                    Id = i,
                    Name = players[i],
                };
                result.Add(player);
            }
            return result;
        }






        public GameState CreateGameState(Team white, Team blue, DateTime startTime = default(DateTime))
        {
            var gamestate = new GameState(white, blue, startTime);
            return gamestate;
        }

        public Team CreateTeam(IEnumerable<Player> players, List<Goal> goals, string teamName)
        {
            var blue = new Team { Players = players, Name = teamName, Goals = goals };
            return blue;
        }
    }
}
