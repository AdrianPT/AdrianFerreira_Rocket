using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RocketLanding_AFerreiraPT.Factories.Interfaces;
using RocketLanding_AFerreiraPT.Hubs;
using RocketLanding_AFerreiraPT.Models;
using RocketLanding_AFerreiraPT.Services.Interfaces;
using System.Threading.Tasks;

namespace RocketLanding_AFerreiraPT.Controllers
{
    [Produces("application/json")]
    public class ControlTowerController : ControllerBase
    {

        private readonly ILandModelFactory _landModelFactory;
        private readonly ISpaceVehicleModelFactory _spaceVehicleModelFactory;
        private readonly IControlTowerService _controlTowerService;
        private readonly ILandService _landService;
        private readonly ISpaceVehicleService _spaceVehicleService;

        public ControlTowerController(
            ILandModelFactory landModelFactory,
            ISpaceVehicleModelFactory spaceVehicleModelFactory,
            IControlTowerService controlTowerService
            ,ILandService landService,
            ISpaceVehicleService spaceVehicleService)
        {
            _landModelFactory = landModelFactory;
            _spaceVehicleModelFactory = spaceVehicleModelFactory;
            _landService = landService;
            _spaceVehicleService = spaceVehicleService;
            _controlTowerService= controlTowerService;
        }


        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <param name="spaceCraft"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item #1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        [HttpPost("api/ControlTower/CheckLanding")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //async - 
        public string CheckLanding(Rocket spaceCraft)
        {
            return _controlTowerService.CheckLanding(spaceCraft);
        }

        [HttpPost("api/ControlTower/PlatformSizeChange")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //async - 
        public void PlatformSizeChange(Rocket spaceCraft, Size newSize)
        {
            _landService.ChangeSize(spaceCraft, newSize);

        }


        [HttpPost("api/ControlTower/ChangeCurrentPosition")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //async - 
        public void ChangeCurrentPosition(Rocket spaceCraft,Position _pos)
        {
          _spaceVehicleService.ChangeCurrentPosition(spaceCraft,_pos);

        }

        [HttpPost("api/ControlTower/ChangeCheckPosition")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //async - 
        public void ChangeCheckPosition(Rocket spaceCraft, Position _pos)
        {
            _spaceVehicleService.ChangeCheckPosition(spaceCraft, _pos);

        }

      
    }
}
