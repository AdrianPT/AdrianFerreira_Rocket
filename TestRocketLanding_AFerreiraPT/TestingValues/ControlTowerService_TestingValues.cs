using RocketLanding_AFerreiraPT.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using RocketLanding_AFerreiraPT.Services;
using RocketLanding_AFerreiraPT.Factories;

namespace TestRocketLanding_AFerreiraPT.TestingValues
{

    public class ControlTowerService_TestingValues : IEnumerable<object[]>
    {

        private readonly List<object[]> _data = new List<object[]>
         {
            new object[]     { new Rocket() }
         };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


    }
}
