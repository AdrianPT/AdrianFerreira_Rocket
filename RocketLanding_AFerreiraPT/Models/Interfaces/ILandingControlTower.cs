using RocketLanding_AFerreiraPT.Models.Interfaces;
using System.Collections.Generic;

namespace RocketLanding_AFerreiraPT.Models
{
    public interface ILandingControlTower
    {
        public Dictionary<int, ISpaceVehicle> _rocketsInSpace { get; set; }
        public LandingArea _land { get; set; }
        public Dictionary<Position, ISpaceVehicle> checkedPositions { get; set; }

    }
}
