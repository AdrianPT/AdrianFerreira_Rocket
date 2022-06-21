using RocketLanding_AFerreiraPT.Models;
using RocketLanding_AFerreiraPT.Services.Interfaces;

namespace RocketLanding_AFerreiraPT.Services
{
    public class SpaceVehicleService : ISpaceVehicleService
    {
      
        public void ChangeCurrentPosition(ISpaceVehicle _rocket, 
            Position _newPosition)
        {
            _rocket.CurrentPosition = _newPosition;
        }

        public void ChangeCheckPosition(ISpaceVehicle _rocket, 
            Position _newPosition)
        {
            _rocket.LandCheckPosition = _newPosition;
        }


    }


}
