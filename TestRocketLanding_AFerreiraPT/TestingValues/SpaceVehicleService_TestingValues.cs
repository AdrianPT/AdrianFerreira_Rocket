using RocketLanding_AFerreiraPT.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace TestRocketLanding_AFerreiraPT.TestingValues
{

    public class SpaceVehicleService_TestingValues : IEnumerable<object[]>
    {

        private readonly List<object[]> _data = new List<object[]>
         {
            new object[]     { new Rocket(11, "Apollo 11") },
            new object[]     { new Rocket(13, "Apollo 13") }
         };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


    }
}
