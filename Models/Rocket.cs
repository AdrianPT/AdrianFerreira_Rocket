using RocketLanding_AFerreiraPT.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace RocketLanding_AFerreiraPT.Models
{
    public class Rocket : ISpaceVehicle
    {
        public ILandingControlTower myControlTower { get; set; }

        [Required]
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        public IDimension CurrentPosition { get; set; }

        [Required]
        public IDimension LandCheckPosition { get; set; }
        public LandingStatus Status { get; set; }

        public Rocket() {
            Id = 0;
            CurrentPosition = new Position();
            LandCheckPosition = new Position();
        }

        public Rocket(int _id)
        {
            Id = _id;
            CurrentPosition = new Position();
            LandCheckPosition = new Position();
        }
        public Rocket(int _id,string _name)
        {
            Id = _id;
            Name = _name;
            CurrentPosition=new Position();
            LandCheckPosition = new Position();
        }

        public Rocket(int _id, Position _landCheck)
        {
            Id = _id;
            Name = "";
            CurrentPosition = new Position();
            LandCheckPosition = _landCheck;
        }

    }


}
