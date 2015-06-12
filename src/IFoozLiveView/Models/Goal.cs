using System;
using System.ComponentModel.DataAnnotations;

namespace IFoozLiveView.Models
{
    public class Goal
    {
        public int PlayerId { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}" )]
        public DateTime Timestamp { get; set; }

        public Player Player { get; private set; }
        public string TeamName => Player.Team.ToString().ToLower();

        public void SetPlayer(Player player)
        {
            Player = player;
        }

        public string TimeSince(DateTime startTime)
        {
            return $"'{(Timestamp - startTime).Minutes}";
        }
    }
}