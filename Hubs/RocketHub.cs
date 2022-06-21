using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using RocketLanding_AFerreiraPT.Models;
using RocketLanding_AFerreiraPT.Services.Interfaces;

namespace RocketLanding_AFerreiraPT.Hubs
{
    public class RocketHub : Hub
    {
  
        private readonly IControlTowerService _controlTowerService;
 
        public RocketHub(
            IControlTowerService controlTowerService)
        {
            _controlTowerService = controlTowerService;
        }
        public async Task UpdateLandingStatus(string userId, ISpaceVehicle spaceCraft)
        {

            _controlTowerService.CheckLanding(spaceCraft);

            await Clients.User(userId).SendAsync("LandingStatus", spaceCraft.Status);
        }

    }
}



