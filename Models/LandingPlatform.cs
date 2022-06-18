using System.Collections.Generic;
using System.Text;
using System.Drawing;
using RocketLanding_AFerreiraPT.Models.Interfaces;

namespace RocketLanding_AFerreiraPT.Models
{
    public class LandingPlatform : ILand
    {
        public string Name { get; set; }
        public IDimension InitialPosition { get; set; }
        public IDimension _size { get; set; }
        public ulong[][] Land { get; set; }

        public bool IsLandingPlatform()
        {
            return true;
        }

        public LandingPlatform() { }
        public LandingPlatform(string _name)
        {
            Name = _name;
        }

    }

}
