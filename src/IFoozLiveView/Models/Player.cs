using System.Collections.Generic;

namespace IFoozLiveView.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Team Team { get; set; }
        public IEnumerable<Goal> Goals { get; set; } 

    }
}