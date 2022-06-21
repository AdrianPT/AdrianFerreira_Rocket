using RocketLanding_AFerreiraPT.Factories.Interfaces;
using RocketLanding_AFerreiraPT.Models;
using RocketLanding_AFerreiraPT.Models.Interfaces;
using RocketLanding_AFerreiraPT.Services.Interfaces;
using System.Collections.Generic;

namespace RocketLanding_AFerreiraPT.Services
{
    public class LandService : ILandService
    {

        private readonly ILandModelFactory _landModelFactory;

        public LandService(ILandModelFactory landModelFactory)
        {
            _landModelFactory = landModelFactory;
        }

        public void Add(LandingArea area, ILand item)
        {
            area._content.Add(item.Id, item);
        }

        public void Remove(LandingArea area, ILand item)
        {
            area._content.Remove(item.Id);
        }

        public void ChangeSize(LandingArea area, ILand item)
        {
            int absoluteX = (item._size.x +
                  item.InitialPosition.x);
            int absoluteY = (item._size.y +
                item.InitialPosition.y);

            if (absoluteX > area._size.x)
            {
                area._size.x = absoluteX;
            }
            if (absoluteY > area._size.y)
            {
                area._size.y = absoluteY;
            }

        }

        public void ChangeSize(ISpaceVehicle _rocket,Size _size) {

            LandingPlatform _firstPlatform = null;

            foreach (KeyValuePair<int, ILand> _iland in _rocket.myControlTower._land._content)
            {
                if (_iland.Value.IsLandingPlatform())
                    _firstPlatform = (LandingPlatform)_rocket.myControlTower._land._content[_iland.Key];
            }

            if ((_firstPlatform != null) && (_firstPlatform.IsLandingPlatform()))
            {
                _firstPlatform._size = _size;
                ChangeSize(_rocket.myControlTower._land, _firstPlatform);
            }

        }


        public bool isInside(ILand platform, IDimension _pos) {
 
            bool xInside = false;
            bool yInside = false;

            int max_X = platform._size.x + platform.InitialPosition.x;
            int max_Y = platform._size.y + platform.InitialPosition.y;
            int min_X = platform.InitialPosition.x;
            int min_Y = platform.InitialPosition.y;

            if ((_pos.x >= min_X) && (_pos.x <= max_X))
            {
                xInside = true;
            }
            if ((_pos.y >= min_Y) && (_pos.y <= max_Y))
            {
                yInside = true;
            }

            return (xInside && yInside);
        }


    }
}
