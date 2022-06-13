using System.Collections.Generic;
using System.Text;

namespace RocketLanding_AFerreiraPT.Models
{
    public interface ILand
    {

        public bool IsLandingPlatform();

        public List<ILand> GetContent();

        public StringBuilder GetDescription();


    }
}
