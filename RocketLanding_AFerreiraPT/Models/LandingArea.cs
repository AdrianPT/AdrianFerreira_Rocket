using RocketLanding_AFerreiraPT.Models.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace RocketLanding_AFerreiraPT.Models
{
    public class LandingArea : ILand
    {
        public Dictionary<int, ILand> _content { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public IDimension InitialPosition { get; set; }
        public IDimension _size { get; set; }

        public bool IsLandingPlatform()
        {
            return false;
        }

        public LandingArea() {
            _content=new Dictionary<int, ILand>(); 
        }

        public LandingArea(int _id) {
            Id = _id;
            _content = new Dictionary<int, ILand>();
        }

        public LandingArea(int _id,string _name)
        {
            Id = _id;
            Name = _name;
            _content = new Dictionary<int, ILand>();
        }

        public LandingArea(int _id, Size _size, Position _pos, string _name)
        {
            Id = _id;
            Name = _name;
            InitialPosition = _pos;
            this._size = _size;
            _content = new Dictionary<int, ILand>();

        }




    }
}
