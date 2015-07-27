using System.Collections.Generic;
using System.Linq;

namespace IFoozLiveView.Models
{
    public class Team
    {
        public IEnumerable<Player> Players { get; set; }
        public IEnumerable<Goal> Goals { get; set; }
        public string Name { get; private set; }
        
        public virtual int Score => Goals.Count();


        public void SetTeamName(string name)
        {
            Name = name;
            foreach (var goal in Goals)
            {
                goal.Team = Name;
            }
        }

        public Team()
        {
            Goals = new List<Goal>();
        }
    }
}