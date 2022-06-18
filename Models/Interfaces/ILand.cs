using RocketLanding_AFerreiraPT.Models.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace RocketLanding_AFerreiraPT.Models
{
    public interface ILand
    {
        public string Name { get; set; }
        public IDimension InitialPosition { get; set; }
        public IDimension _size { get; set; }
        public ulong[][] Land { get; set; }

        public bool IsLandingPlatform();
    
    }
}
