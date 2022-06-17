using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using RocketLanding_AFerreiraPT.Models;

namespace RocketLanding_AFerreiraPT.Hubs
{
    public class RocketHub : Hub
    {
        public async Task SendMessage(LandingMessage message,string userId)
        {


            await Clients.User(userId).SendAsync("ReceiveMessage", message);
        }

    }
}



