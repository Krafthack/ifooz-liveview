
using IFoozLiveView.Models;
using IFoozLiveView.Services;
using Microsoft.AspNet.Mvc;

namespace IFoozLiveView.Controllers
{
    public class GameController : Controller
    {
        [FromServices]
        public IGameStateService GameStateService { get; set; }

        [FromServices]
        public IGameHub GameHub { get; set; }


        public IActionResult Index()
        {
            return View();
        }

        public JsonResult RetrieveGameState()
        {

            var gameState = GameStateService.RetrieveCurrent();


            return Json(gameState);
        }

        public void PublishGameState(GameState game)
        {
            game.SetTeamOnGoals();
            GameHub.Publish(game);
        }
    }
}
