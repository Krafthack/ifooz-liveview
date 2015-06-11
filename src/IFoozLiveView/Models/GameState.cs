using System.Collections.Generic;
using System.Linq;

namespace IFoozLiveView.Models
{
    public class GameState
    {
        public IEnumerable<Player> TeamBlue { get; set; }
        public IEnumerable<Player> TeamWhite { get; set; }
        public IEnumerable<Goal> Goals { get; set; }


        public int BlueScore => Goals.Count(g => TeamBlue.Any(p => p.Id == g.PlayerId));
        public int WhiteScore => Goals.Count(g => TeamWhite.Any(p => p.Id == g.PlayerId));

        public IEnumerable<Player> Players => TeamBlue.Concat(TeamWhite);


        public Player GetPlayer(int playerId)
        {
            return Players.SingleOrDefault(p => p.Id == playerId);
        }
    }
}
