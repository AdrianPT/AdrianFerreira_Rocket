using RocketLanding_AFerreiraPT.Models;
using System.Collections.Generic;

namespace RocketLanding_AFerreiraPT.Services.Interfaces
{
    public interface ILandService
    {
        public void Add(LandingArea area, ILand cont);
        public void Remove(LandingArea area, ILand cont);

    }
}
