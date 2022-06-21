using RocketLanding_AFerreiraPT.Factories.Interfaces;
using RocketLanding_AFerreiraPT.Models;
using RocketLanding_AFerreiraPT.Services.Interfaces;
using System.Collections.Generic;

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

        public string CheckLanding(ISpaceVehicle _spaceVehicle) {

            LandingPlatform _firstPlatform = null;

            foreach (KeyValuePair<int, ILand> _iland in _spaceVehicle.myControlTower._land._content)
            {
                if (_iland.Value.IsLandingPlatform())
                    _firstPlatform = (LandingPlatform)_spaceVehicle.myControlTower._land._content[_iland.Key];
            }


            if ((_firstPlatform != null) && (_firstPlatform.IsLandingPlatform()))
            {

                bool inside = _landService.isInside(_firstPlatform, _spaceVehicle.LandCheckPosition);

                if (inside)
                {
                    _spaceVehicle.Status = GetClash(_spaceVehicle);
                }
                else
                {
                    _spaceVehicle.Status = LandingStatus.Out;
                }

            }
            else { _spaceVehicle.Status = LandingStatus.Out; }

            string message = "";

            if (_spaceVehicle.Status == LandingStatus.OK) {
                message = "ok for landing";
            }
            else if (_spaceVehicle.Status == LandingStatus.Clash)
            {
                message = "clash";
            }
            else if (_spaceVehicle.Status == LandingStatus.Out)
            {
                message = "out of platform";
            }

            return message;

        }
        public LandingStatus GetClash(ISpaceVehicle _spaceCraft)
        {
            LandingStatus aux = LandingStatus.OK;
            try
            {
                ISpaceVehicle _rocketSamePosition =
                           _spaceCraft.myControlTower.checkedPositions
                           [(Position)_spaceCraft.LandCheckPosition];


                if ((_rocketSamePosition != null)
                    && (_rocketSamePosition.Id != _spaceCraft.Id))
                {
                    ILand miniAntiLandingArea = new LandingArea();
                    miniAntiLandingArea._size = new Size(2, 2);
                    miniAntiLandingArea.InitialPosition =
                        new Position(_rocketSamePosition.LandCheckPosition.x - 1,
                        _rocketSamePosition.LandCheckPosition.y - 1);

          
                    if (_landService.isInside(miniAntiLandingArea, _spaceCraft.LandCheckPosition))
                        aux = LandingStatus.Clash;

                }

                if (_spaceCraft.myControlTower.checkedPositions.Count == 0)
                {
                    aux = LandingStatus.OK;
                }
            }
            catch (KeyNotFoundException e)
            {
                aux = LandingStatus.OK;
            }

            return aux;


        }


    }
}
