using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using RocketLanding_AFerreiraPT.Models;

namespace RocketLanding_AFerreiraPT.Hubs
{
    public class RocketHub : Hub
    {
        public async Task UpdateLandingStatus(string userId, Rocket spaceCraft)
        {




            //Logic LandingStatus



            await Clients.User(userId).SendAsync("LandingStatus", spaceCraft.Status);
        }

    }
}



