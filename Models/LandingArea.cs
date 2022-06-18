using RocketLanding_AFerreiraPT.Models.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace RocketLanding_AFerreiraPT.Models
{
    public class LandingArea : ILand
    {
        public List<ILand> _content = new List<ILand>();
        public string Name { get; set; }
        public IDimension InitialPosition { get; set; }
        public IDimension _size { get; set; }
        public ulong[][] Land { get; set; }

        public bool IsLandingPlatform()
        {
            return false;
        }

        public LandingArea() { }
        public LandingArea(string _name) {
            Name = _name;
        }
    }
}
