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

        public ControlTowerController(
            ILandModelFactory landModelFactory,
            ISpaceVehicleModelFactory spaceVehicleModelFactory,
            IControlTowerService controlTowerService)
        {
            _landModelFactory = landModelFactory;
            _spaceVehicleModelFactory = spaceVehicleModelFactory;
            _controlTowerService = controlTowerService;
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
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>

        [HttpPost("api/ControlTower/CheckLanding")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //async - 
        public string CheckLanding(Rocket spaceCraft)
        {
           


            return "teste";
        }

        //La clave está en recibir los parametros
        //y a partir de ahi crear los objetos que necesito
        //y enviar los objetos solo cuando sea posible


        /*
        [HttpGet("api/character/hero")]
        public Character GetCharacter(string name, string heType)
        {
            Hero ch = new Hero(name, searchHeroType(heType));
            ch.setPosition(new Position { x = 0, y = 0, z = 0 });
            gam.Height = 10;
            gam.Width = 10;
            gam.Join(ch);
            ch.myGameZone = gam;
            ch.ItemThatIHave = new Weapon() { Name = "Special Sword" };

            return ch;
        }*/




    }
}
