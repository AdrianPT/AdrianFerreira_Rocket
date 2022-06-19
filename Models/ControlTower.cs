using System.Collections.Generic;

namespace RocketLanding_AFerreiraPT.Models
{
    public class ControlTower : ILandingControlTower
    {

        public Dictionary<int, Rocket> _rocketsInSpace { get; set; }

        public ILand _land { get; set; }

        public Dictionary<Position, Rocket> checkedPositions { get; set; }


        public ControlTower()
        {
            checkedPositions = new Dictionary<Position, Rocket>();
        }

    }
}
