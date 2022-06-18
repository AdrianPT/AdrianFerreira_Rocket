using RocketLanding_AFerreiraPT.Factories.Interfaces;
using RocketLanding_AFerreiraPT.Services.Interfaces;

namespace RocketLanding_AFerreiraPT.Services
{
    public class ControlTowerService : IControlTowerService
    {
        private readonly ISpaceVehicleModelFactory _spaceVehicleModelFactory;
        private readonly ILandModelFactory _landModelFactory;

        public ControlTowerService(
            ILandModelFactory landModelFactory,
            ISpaceVehicleModelFactory spaceVehicleModelFactory)
        {
            _landModelFactory = landModelFactory;
            _spaceVehicleModelFactory = spaceVehicleModelFactory;
       
        }




    }
}
