using IFoozLiveView.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace IFoozLiveView.Services
{
    [HubName("game")]
    public class GameHub : Hub
    {
      
    }
}