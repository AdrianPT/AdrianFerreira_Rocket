using RocketLanding_AFerreiraPT.Models.Interfaces;

namespace RocketLanding_AFerreiraPT.Models
{
    public class Size : IDimension
    {
        public int x { get; set; }
        public int y { get; set; }

        public Size(int x, int y)
        {
            this.x = x;
            this.y = y;

        }


        public Size()
        {
            x = 0;
            y = 0;

        }

    }

}