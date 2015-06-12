using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNet.Razor.Generator.Compiler;

namespace IFoozLiveView.Models
{
    public class GameState
    {
        public IEnumerable<Player> Players { get; set; }
        public DateTime StartTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:mm\\:ss}")]
        public TimeSpan Clock => DateTime.Now - StartTime;


        public IEnumerable<Goal> Goals => Players.SelectMany(p => p.Goals).OrderByDescending(g => g.Timestamp);

        public IEnumerable<Player> BluePlayers => Players.Where(p => p.Team == Team.Blue);
        public IEnumerable<Player> WhitePlayers => Players.Where(p => p.Team == Team.White);
        
        public int BlueScore => BluePlayers.SelectMany(p => p.Goals).Count();
        public int WhiteScore => WhitePlayers.SelectMany(p => p.Goals).Count();


        public GameState()
        {
            
        }

        public GameState(IEnumerable<Player> players, DateTime startTime)
        {
            StartTime = startTime;
            Players = players;
            SetPlayerOnGoals();
        }

        public void SetPlayerOnGoals()
        {
            foreach (var player in Players)
            {
                foreach (var goal in player.Goals)
                {
                    goal.SetPlayer(player);
                }
            }
        }
    }
}
