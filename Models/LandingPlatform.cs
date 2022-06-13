using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace RocketLanding_AFerreiraPT.Models
{
    public class LandingPlatform : ILand
    {
        public Size _size { get; set; }
        public Position InitialPosition { get; set; }
        public Position FinalPosition => 
            new Position(InitialPosition.x + _size.Width,
                         InitialPosition.y +_size.Height,
                         InitialPosition.z );

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
