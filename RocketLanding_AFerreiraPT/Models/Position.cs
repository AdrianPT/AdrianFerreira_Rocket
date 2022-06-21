using RocketLanding_AFerreiraPT.Models.Interfaces;
using System.Collections.Generic;

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

        public Position()
        {
            x = 0;y = 0;z = 0;
        }


    }


    class PositionComparer : IEqualityComparer<Position>
    {
        public bool Equals(Position p1, Position p2)
        {
            if (p2 == null && p1 == null)
                return true;
            else if (p1 == null || p2 == null)
                return false;
            else if (p1.x == p2.x && p1.y == p2.y
                                && p1.z == p2.z)
                return true;
            else
                return false;
        }

        public int GetHashCode(Position p)
        {
            int hCode = p.x.GetHashCode() ^ p.y.GetHashCode();
            return hCode.GetHashCode();
        }
    }

}
