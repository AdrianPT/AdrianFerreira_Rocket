using RocketLanding_AFerreiraPT.Models;

namespace RocketLanding_AFerreiraPT.Factories.Interfaces
{
    public interface ILandModelFactory
    {
        public ILand GetLand(string name, LandType landType);
    }
}
