using RocketLanding_AFerreiraPT.Factories.Interfaces;
using RocketLanding_AFerreiraPT.Models;

namespace RocketLanding_AFerreiraPT.Factories
{
    public class LandModelFactory : ILandModelFactory
    {
        public ILand CreateLand(int id, LandType landType)
        {
            switch (landType)
            {
                case LandType.Platform: return new LandingPlatform(id);
                case LandType.LandingArea: return new LandingArea(id);
                default: return null;
            }

        }


        public ILand CreateLand(int id, LandType landType,
            Size _size,Position _initialPosition,string _name="")
        {

            switch (landType)
            {
                case LandType.Platform: return new LandingPlatform(id, _size, _initialPosition, _name);
                case LandType.LandingArea: return new LandingArea(id, _size, _initialPosition, _name);
                default: return null;
            }

        }










    }

}
