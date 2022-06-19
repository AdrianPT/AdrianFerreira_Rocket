using RocketLanding_AFerreiraPT.Factories.Interfaces;
using RocketLanding_AFerreiraPT.Services.Interfaces;

namespace RocketLanding_AFerreiraPT.Services
{
    public class ControlTowerService : IControlTowerService
    {
        private readonly ISpaceVehicleModelFactory _spaceVehicleModelFactory;
        private readonly ILandModelFactory _landModelFactory;
        private readonly ISpaceVehicleService _spaceVehicleService;
        private readonly ILandService _landService;

        public ControlTowerService(
            ILandModelFactory landModelFactory,
            ISpaceVehicleModelFactory spaceVehicleModelFactory,
            ISpaceVehicleService spaceVehicleService,
            ILandService landService)
        {
            _landModelFactory = landModelFactory;
            _spaceVehicleModelFactory = spaceVehicleModelFactory;
            _spaceVehicleService = spaceVehicleService;
            _landService = landService;
            
        }




    }
}
