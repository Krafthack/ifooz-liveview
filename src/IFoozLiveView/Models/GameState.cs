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

        [DisplayFormat(DataFormatString = "{0:mm\\:ss}")]
        public TimeSpan Clock => DateTime.Now - StartTime;


        public IEnumerable<Goal> Goals =>  Blue.Goals.Concat(White.Goals).OrderByDescending(g => g.Timestamp);

     

        public GameState()
        {
            
        }

        public GameState(Team white, Team blue, DateTime startTime)
        {
            StartTime = startTime;
            Blue = blue;
            White = white;
        }


        public void SetTeamOnGoals()
        {
            Blue.SetTeamOnGoals();
            White.SetTeamOnGoals();
        }
    }
}
