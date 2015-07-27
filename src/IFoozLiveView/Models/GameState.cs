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
        
        [Required]
        public Team Blue { get; set; }
        [Required]
        public Team White { get; set; }

        [Required]
        public DateTime StartTime { get; set; }
        public string StartTimeFriendly => StartTime.ToString("dd. MMM HH:mm");

        [DisplayFormat(DataFormatString = "{0:mm\\:ss}")]
        public TimeSpan Clock => DateTime.Now - StartTime;


        private IEnumerable<Goal> BlueGoals => Blue != null ? Blue.Goals : new List<Goal>();
        private IEnumerable<Goal> WhiteGoals => White != null ? White.Goals : new List<Goal>();
        public IEnumerable<Goal> Goals =>  BlueGoals.Concat(WhiteGoals).OrderByDescending(g => g.Timestamp);

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
            SetTeamNames();
        }


        public void SetTeamNames()
        {
            Blue.SetTeamName(TeamNames.Blue);
            White.SetTeamName(TeamNames.White);
        }
    }
}
