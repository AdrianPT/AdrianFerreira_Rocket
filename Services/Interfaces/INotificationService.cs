using RocketLanding_AFerreiraPT.Models;
using System.Threading.Tasks;

namespace RocketLanding_AFerreiraPT.Services.Interfaces
{
    public interface INotificationService
    {
        public Task SendNotificationAsync(LandingMessage notification, string userId);

    }
}
