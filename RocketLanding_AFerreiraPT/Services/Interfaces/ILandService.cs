using RocketLanding_AFerreiraPT.Models;
using RocketLanding_AFerreiraPT.Models.Interfaces;
using System.Collections.Generic;

namespace RocketLanding_AFerreiraPT.Services.Interfaces
{
    public interface ILandService
    {
        public void Add(LandingArea area, ILand cont);
        public void Remove(LandingArea area, ILand cont);
        public bool isInside(ILand platAux, IDimension landCheckPosition);
        public void ChangeSize(LandingArea area, ILand item);
        public void ChangeSize(ISpaceVehicle _rocket, Size _size);
        

        }
}
