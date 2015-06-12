using System.Collections.Generic;
using System.Linq;

namespace IFoozLiveView.Models
{
    public class Team
    {
        public IEnumerable<Player> Players { get; set; }
        public IEnumerable<Goal> Goals { get; set; }
        public string Name { get; set; }
        
        public int Score => Goals.Count();


        public void SetTeamOnGoals()
        {
            foreach (var goal in Goals)
            {
                goal.Team = Name;
            }
        }
    }
}