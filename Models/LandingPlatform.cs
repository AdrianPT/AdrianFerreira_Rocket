using System.Collections.Generic;
using System.Text;
using System.Drawing;
using RocketLanding_AFerreiraPT.Models.Interfaces;

namespace RocketLanding_AFerreiraPT.Models
{
    public class LandingPlatform : ILand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IDimension InitialPosition { get; set; }
        public IDimension _size { get; set; }
     
        public bool IsLandingPlatform()
        {
            return true;
        }

        public LandingPlatform() {
            Id = 0;
            Name = "";
            InitialPosition = new Position();
            _size = new Size();
        }

        public LandingPlatform(int _id)
        {
            Id = _id;
            Name = "";
            InitialPosition = new Position();
            _size = new Size();

        }

        public LandingPlatform(int _id, Size _size,Position _pos,string _name)
        {
            Id = _id;
            Name = _name;
            InitialPosition = _pos;
            this._size = _size;

        }


    }

}
