using Microsoft.AspNetCore.SignalR;
using RocketLanding_AFerreiraPT.Hubs;
using RocketLanding_AFerreiraPT.Models;
using RocketLanding_AFerreiraPT.Services.Interfaces;
using System.Threading.Tasks;

namespace RocketLanding_AFerreiraPT.Services
{
    public class NotificationService : INotificationService
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
