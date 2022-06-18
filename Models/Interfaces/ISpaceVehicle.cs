using RocketLanding_AFerreiraPT.Models.Interfaces;

namespace RocketLanding_AFerreiraPT.Models
{
    public interface ISpaceVehicle
    {
        public ControlTower myControlTower { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public IDimension CurrentPosition { get; set; }
        public IDimension LandCheckPosition { get; set; }
        public LandingStatus Status { get; set; }

    }
}
