
using IFoozLiveView.Models;
using IFoozLiveView.Services;
using Microsoft.AspNet.Mvc;

namespace IFoozLiveView.Controllers
{
    public class GameController : Controller
    {
        public IGameStateService GameStateService { get; set; }


        public GameController(IGameStateService srv)
        {
            GameStateService = srv;
        }

        public IActionResult Index()
        {
            var gamestate = GameStateService.RetrieveCurrent();

            return View(gamestate);
        }


        public void PublishGameState(GameState game)
        {
            
        }
    }
}
