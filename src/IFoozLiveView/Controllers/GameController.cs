
using IFoozLiveView.Models;
using IFoozLiveView.Services;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;
using Microsoft.Net.Http.Server;
using Newtonsoft.Json.Linq;

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
            gameState.SetTeamNames();

            return Json(gameState);
        }

        [HttpPost]
        public void Publish([FromBody] GameState game)
        {
            game.SetTeamNames();

            var gameHub = ConnectionManager.GetHubContext<GameHub>();
            gameHub.Clients.All.publish(game);
        }

        public void PublishTest()
        {

            var gameState = GameStateService.RetrieveCurrent();
            gameState.SetTeamNames();

            var gameHub = ConnectionManager.GetHubContext<GameHub>();
            gameHub.Clients.All.publish(gameState);
        }
        
    }
}
