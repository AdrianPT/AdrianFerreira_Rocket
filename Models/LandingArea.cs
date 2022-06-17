using RocketLanding_AFerreiraPT.Models.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace RocketLanding_AFerreiraPT.Models
{
    public class LandingArea : ILand
    {
        public IDimension InitialPosition { get; set; }
        public IDimension _size { get; set; }




        public List<ILand> GetContent()
        {
            throw new System.NotImplementedException();
        }

        public StringBuilder GetDescription()
        {
            throw new System.NotImplementedException();
        }

        public bool IsLandingPlatform()
        {
            throw new System.NotImplementedException();
        }
    }
}
