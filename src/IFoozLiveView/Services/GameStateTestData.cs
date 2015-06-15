using System;
using System.Collections.Generic;
using System.Linq;
using IFoozLiveView.Models;

namespace IFoozLiveView.Services
{
    public class GameStateTestData : IGameStateService
    {
        public GameState RetrieveCurrent()
        {
            var rnd = new Random();
            var players = CreatePlayers("Ken", "Eivind", "Calle", "Frode");

            var blue = new Team {Players = players.Take(2), Name = TeamNames.Blue, Goals = CreateGoals(rnd)};
            var white = new Team {Players = players.Skip(2), Name = TeamNames.White, Goals = CreateGoals(rnd) };


            var gamestate =  new GameState(white, blue, DateTime.Now.AddSeconds(-350));

            return gamestate;

        }

       
        private List<Goal> CreateGoals(Random rnd)
        {
            var result = new List<Goal>();

            var count = rnd.Next(0, 9);

            for (int i = 0; i < count; i++)
            {
                var timestamp = DateTime.Now.AddSeconds(-rnd.Next(5, 349));

                result.Add(new Goal()
                {
                    Timestamp = timestamp
                });

            }
            return result;

        }


        private List<Player> CreatePlayers(params string[] players)
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
        
    }
}