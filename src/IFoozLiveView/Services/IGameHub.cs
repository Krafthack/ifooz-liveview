using IFoozLiveView.Models;

namespace IFoozLiveView.Services
{
    public interface IGameHub
    {
        void Publish(GameState game);
    }
}