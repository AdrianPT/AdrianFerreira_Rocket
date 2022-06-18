using RocketLanding_AFerreiraPT.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace RocketLanding_AFerreiraPT.Models
{
    public class Rocket : ISpaceVehicle
    {
        public ControlTower myControlTower { get; set; }

        [Required]
        public string RocketId { get; set; }
        public string Name { get; set; }

        [Required]
        public IDimension CurrentPosition { get; set; }

        [Required]
        public IDimension LandCheckPosition { get; set; }
        public LandingStatus Status { get; set; }

        public Rocket() { 
        
        }

        public Rocket(string _name)
        {
            Name = _name;
        }

    }


}
