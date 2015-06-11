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

            return new GameState()
            {
                TeamBlue = players.Take(2),
                TeamWhite = players.Skip(2),
                Goals = GetGoals(players)
            };
        }

        private IEnumerable<Goal> GetGoals(IEnumerable<Player> players)
        {
            var result = new List<Goal>();
            var rnd = new Random();

            foreach (var player in players)
            {
                result.AddRange(CreateGoals(player, rnd));
            }
            return result.OrderByDescending(g => g.Timestamp);

        }

        private List<Goal> CreateGoals(Player player, Random rnd)
        {
            var result = new List<Goal>();

            var count = rnd.Next(0, 5);

            for (int i = 0; i < count; i++)
            {
                var timestamp = DateTime.Now.AddSeconds(-rnd.Next(5, 250));

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
            var result = new List<Player>();

            for (int i = 0; i < players.Length; i++)
            {
                result.Add(new Player {Id = i, Name = players[i]});
            }
            return result;
        }
        
    }
}