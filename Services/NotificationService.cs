using Microsoft.AspNetCore.SignalR;
using RocketLanding_AFerreiraPT.Hubs;
using RocketLanding_AFerreiraPT.Models;
using System.Threading.Tasks;

namespace RocketLanding_AFerreiraPT.ServiceLayer
{
    public class NotificationService
    {

        private readonly IHubContext<RocketHub> _hubContext;

        public NotificationService(IHubContext<RocketHub> hubContext) =>
            _hubContext = hubContext;

        // To communicate a message to the Rocket user with many different devices mobile, etc. at same time.
        public Task SendNotificationAsync(LandingMessage notification, string userId)
        {
            if (!(notification is null))
                return _hubContext.Clients.User(userId).SendAsync("ReceiveMessage", notification);

            else return Task.CompletedTask;
        }


    }
}
