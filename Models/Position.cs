using RocketLanding_AFerreiraPT.Models.Interfaces;

namespace RocketLanding_AFerreiraPT.Models
{
    public class Position : IDimension
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }

        public Position(int x, int y, int z=0)
        {
            this.x = x;
            this.y = y;
            this.z = z;

        }

    }

}
