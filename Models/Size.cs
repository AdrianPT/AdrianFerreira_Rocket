using RocketLanding_AFerreiraPT.Models.Interfaces;

namespace RocketLanding_AFerreiraPT.Models
{
    public struct Size : IDimension
    {
        public int widht;
        public int height;

        public Size(int widht, int height)
        {
            this.widht = widht;
            this.height = height;

        }

    }

}