using RocketLanding_AFerreiraPT.Factories.Interfaces;
using RocketLanding_AFerreiraPT.Models;

namespace RocketLanding_AFerreiraPT.Factories
{
    public class LandModelFactory : ILandModelFactory
    {
        public ILand GetLand(int id, LandType landType)
        {
            switch (landType)
            {
                case LandType.Platform: return new LandingPlatform(id);
                case LandType.LandingArea: return new LandingArea(id);
                default: return null;
            }

        }
    }

}
