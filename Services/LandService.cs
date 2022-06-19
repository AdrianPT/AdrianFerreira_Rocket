using RocketLanding_AFerreiraPT.Models;
using RocketLanding_AFerreiraPT.Services.Interfaces;
using System.Collections.Generic;

namespace RocketLanding_AFerreiraPT.Services
{
    public class LandService : ILandService
    {

        public void Add(LandingArea area, ILand cont)
        {
            area._content.Add(cont.Id,cont);
        }

        public void Remove(LandingArea area, ILand cont)
        {
            area._content.Remove(cont.Id);
        }


    }
}
