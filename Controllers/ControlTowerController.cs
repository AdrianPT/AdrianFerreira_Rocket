using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RocketLanding_AFerreiraPT.Hubs;
using RocketLanding_AFerreiraPT.Models;
using System.Threading.Tasks;

namespace RocketLanding_AFerreiraPT.Controllers
{
    [Produces("application/json")]
    public class ControlTowerController : ControllerBase
    {



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

       




    }
}
