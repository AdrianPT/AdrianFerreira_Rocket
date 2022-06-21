using RocketLanding_AFerreiraPT.Models;

namespace RocketLanding_AFerreiraPT.Services.Interfaces
{
    public interface ISpaceVehicleService
    {

        public void ChangeCurrentPosition(ISpaceVehicle _rocket, Position _newPosition);

        public void ChangeCheckPosition(ISpaceVehicle _rocket, Position _newPosition);

    }
}
