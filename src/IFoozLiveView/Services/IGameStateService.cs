using System.Security.Cryptography.X509Certificates;
using IFoozLiveView.Models;

namespace IFoozLiveView.Services
{
    public interface IGameStateService
    {
        GameState RetrieveCurrent();
    }
}