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
            var players = CreatePlayers("Ken", "Eivind", "Calle", "Frode");

            return new GameState( players, DateTime.Now.AddSeconds(-350));

        }

       
        private List<Goal> CreateGoals(Player player, Random rnd)
        {
            var result = new List<Goal>();

            var count = rnd.Next(0, 5);

            for (int i = 0; i < count; i++)
            {
                var timestamp = DateTime.Now.AddSeconds(-rnd.Next(5, 349));

                result.Add(new Goal()
                {
                    PlayerId = player.Id,
                    Timestamp = timestamp
                });

            }
            return result;

        }


        private List<Player> CreatePlayers(params string[] players)
        {
            var rnd = new Random();
            var result = new List<Player>();

            for (int i = 0; i < players.Length; i++)
            {
                var player = new Player
                {
                    Id = i,
                    Name = players[i],
                    Team = i < 2 ? Team.Blue : Team.White,

                };
                player.Goals = CreateGoals(player, rnd);
                result.Add(player);
            }
            return result;
        }
        
    }
}