using RocketLanding_AFerreiraPT.Factories.Interfaces;
using RocketLanding_AFerreiraPT.Models;

namespace RocketLanding_AFerreiraPT.Factories
{
    public class SpaceVehicleModelFactory: ISpaceVehicleModelFactory
    {

        public ISpaceVehicle GetSpaceVehicle(string name, SpaceType spaceType)
        {
            switch (spaceType)
            {
                case SpaceType.Rocket: return new Rocket(name);
                default: return null;
            }
          
        }

    }

}
