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
        
        public Team Blue { get; set; }
        public Team White { get; set; }

        public DateTime StartTime { get; set; }
        public string StartTimeFriendly => StartTime.ToString("dd. MMM HH:mm");

        [DisplayFormat(DataFormatString = "{0:mm\\:ss}")]
        public TimeSpan Clock => DateTime.Now - StartTime;


        public IEnumerable<Goal> Goals =>  Blue.Goals.Concat(White.Goals).OrderByDescending(g => g.Timestamp);

        public int? ScoreLimit { get; set; }
        private const int DefaultScoreLimit = 10;

        public GameState()
        {
            ScoreLimit = ScoreLimit ?? DefaultScoreLimit;
        }

        public GameState(Team white, Team blue, DateTime startTime, int scoreLimit = DefaultScoreLimit)
        {
            StartTime = startTime;
            Blue = blue;
            White = white;
            ScoreLimit = scoreLimit;
        }


        public void SetTeamOnGoals()
        {
            Blue.SetTeamOnGoals();
            White.SetTeamOnGoals();
        }
    }
}
