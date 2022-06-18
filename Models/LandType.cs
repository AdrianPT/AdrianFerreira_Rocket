using System.ComponentModel;

namespace RocketLanding_AFerreiraPT.Models
{
    public enum LandingStatus
    {
        [Description("ok for landing.")]
        OK,
        [Description("out of platform.")]
        Out,
        [Description("clash")]
        Clash
    }
}
