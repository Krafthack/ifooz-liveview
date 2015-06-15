
using IFoozLiveView.Models;
using IFoozLiveView.Services;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;

namespace IFoozLiveView.Controllers
{
    public class GameController : Controller
    {
        [FromServices]
        public IGameStateService GameStateService { get; set; }
        [FromServices]
        public IConnectionManager ConnectionManager { get; set; }


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

            var gameHub = ConnectionManager.GetHubContext<ChatHub>();
            gameHub.Clients.All.publish(game);
        }

        public void PublishTest()
        {

            var gameState = GameStateService.RetrieveCurrent();

            var gameHub = ConnectionManager.GetHubContext<ChatHub>();
            gameHub.Clients.All.publish(gameState);
        }
        
    }
}
