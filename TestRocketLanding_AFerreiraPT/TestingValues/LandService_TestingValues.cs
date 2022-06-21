using RocketLanding_AFerreiraPT.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TestRocketLanding_AFerreiraPT.TestingValues
{

    public class LandService_TestingValues : IEnumerable<object[]>
    {

        private readonly List<object[]> _data = new List<object[]>
         {
            new object[]     { new LandingArea(874,"HOUSTON #874 Alfa"), new LandingPlatform()},
            new object[]     { new LandingArea(345,"NEW MEXICO #375 Beta"), new LandingPlatform()}
         };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


    }
}
