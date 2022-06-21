using RocketLanding_AFerreiraPT.Models.Interfaces;
using System.Collections.Generic;

namespace RocketLanding_AFerreiraPT.Models
{
    public class ControlTower : ILandingControlTower
    {

        public Dictionary<int, ISpaceVehicle> _rocketsInSpace { get; set; }

        public LandingArea _land { get; set; }

        public Dictionary<Position, ISpaceVehicle> checkedPositions { get; set; }


        public ControlTower()
        {
            PositionComparer posCompare = new PositionComparer();
            checkedPositions = new Dictionary<Position, ISpaceVehicle>(posCompare);
            _rocketsInSpace = new Dictionary<int, ISpaceVehicle>();
            _land = new LandingArea();
        }

    }
}
