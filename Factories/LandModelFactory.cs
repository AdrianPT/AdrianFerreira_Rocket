using RocketLanding_AFerreiraPT.Factories.Interfaces;
using RocketLanding_AFerreiraPT.Models;

namespace RocketLanding_AFerreiraPT.Factories
{
    public class LandModelFactory : ILandModelFactory
    {
        public ILand GetLand(string name, LandType landType)
        {
            switch (landType)
            {
                case LandType.Platform: return new LandingPlatform(name);
                case LandType.LandingArea: return new LandingArea(name);
                default: return null;
            }

        }
    }

}
