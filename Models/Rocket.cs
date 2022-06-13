using System.ComponentModel.DataAnnotations;

namespace RocketLanding_AFerreiraPT.Models
{
    public class Rocket
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Position CurrentPosition { get; set; }

        [Required]
        public Position LandCheckPosition { get; set; }
        public LandingStatus Status { get; set; }

    }


}
