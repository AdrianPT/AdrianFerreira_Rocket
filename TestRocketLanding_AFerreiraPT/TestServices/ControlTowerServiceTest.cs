using Microsoft.Extensions.DependencyInjection;
using Moq;
using RocketLanding_AFerreiraPT.Factories;
using RocketLanding_AFerreiraPT.Factories.Interfaces;
using RocketLanding_AFerreiraPT.Models;
using RocketLanding_AFerreiraPT.Models.Interfaces;
using RocketLanding_AFerreiraPT.Services;
using RocketLanding_AFerreiraPT.Services.Interfaces;
using System;
using System.Collections.Generic;
using TestRocketLanding_AFerreiraPT.TestingValues;
using Xunit;

namespace TestRocketLanding_AFerreiraPT.TestServices
{
    public class ControlTowerServiceTest
    {

        private readonly IServiceProvider _serviceProvider;

        public ControlTowerServiceTest()
        {
            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider.Setup(x => x.GetService(typeof(IControlTowerService))).Returns(
                new ControlTowerService(new LandModelFactory(), new SpaceVehicleModelFactory(), new SpaceVehicleService(), new LandService(new LandModelFactory())));
            
            serviceProvider.Setup(x => x.GetService(typeof(ILandService))).Returns(new LandService(new LandModelFactory()));

            //Default code to implement mock of dependency injection
            var serviceScope = new Mock<IServiceScope>();
            serviceScope.Setup(x => x.ServiceProvider).Returns(serviceProvider.Object);

            var serviceScopeFactory = new Mock<IServiceScopeFactory>();
            serviceScopeFactory.Setup(x => x.CreateScope()).Returns(serviceScope.Object);

            serviceProvider.Setup(x => x.GetService(typeof(IServiceScopeFactory))).Returns(serviceScopeFactory.Object);

            _serviceProvider = serviceProvider.Object;
        }

        [Theory]
        [ClassData(typeof(ControlTowerService_TestingValues))]
        public void CheckLanding_OkForLanding_OkStatus(ISpaceVehicle _spaceCraft)
        {
            IDimension _pos = new Position(5, 5);
            _spaceCraft.LandCheckPosition = new Position(5, 5);

            _spaceCraft.Status = getStatus( _spaceCraft, _pos);

            Assert.Equal(LandingStatus.OK, _spaceCraft.Status);

        }

        [Theory]
        [ClassData(typeof(ControlTowerService_TestingValues))]
        public void CheckLanding_OutForLanding_OkStatus(ISpaceVehicle _spaceCraft)
        {
            IDimension _pos = _spaceCraft.LandCheckPosition = new Position(15, 16);

            _spaceCraft.Status = getStatus(_spaceCraft, _pos);

            Assert.Equal(LandingStatus.Out, _spaceCraft.Status);

        }

        [Theory]
        [ClassData(typeof(ControlTowerService_TestingValues))]
        public void CheckClash_ClashSamePosition_ClashStatus(ISpaceVehicle _spaceCraft)
        {
            IDimension _pos = _spaceCraft.LandCheckPosition = new Position(7, 7);
            _spaceCraft.Id = 1;
            _spaceCraft.myControlTower = new ControlTower();

            _spaceCraft.myControlTower.checkedPositions.Add(
            (Position)_spaceCraft.LandCheckPosition,
            new Rocket(3, new Position(7, 7)));

            _spaceCraft.Status = GetClash(_spaceCraft);

            Assert.Equal(LandingStatus.Clash, _spaceCraft.Status);

        }

        [Theory]
        [ClassData(typeof(ControlTowerService_TestingValues))]
        public void CheckClash_ClashNearPosition_ClashStatus(ISpaceVehicle _spaceCraft)
        {
            IDimension _pos = _spaceCraft.LandCheckPosition = new Position(6, 6);
            _spaceCraft.Id = 1;
            _spaceCraft.myControlTower=new ControlTower();

            _spaceCraft.myControlTower.checkedPositions.Add(
            (Position)_spaceCraft.LandCheckPosition,
            new Rocket(3, new Position(7, 7)));

            _spaceCraft.Status = GetClash(_spaceCraft);

            Assert.Equal(LandingStatus.Clash, _spaceCraft.Status);

        }

        [Theory]
        [ClassData(typeof(ControlTowerService_TestingValues))]
        public void CheckClash_ClashNearPosition_OKStatus(ISpaceVehicle _spaceCraft)
        {
            IDimension _pos = _spaceCraft.LandCheckPosition = new Position(9, 9);
            _spaceCraft.Id = 1;
            _spaceCraft.myControlTower = new ControlTower();

            _spaceCraft.myControlTower.checkedPositions.Add(
            (Position)_spaceCraft.LandCheckPosition,
            new Rocket(3, new Position(7, 7)));

            _spaceCraft.Status = GetClash(_spaceCraft);

            Assert.Equal(LandingStatus.OK, _spaceCraft.Status);

        }

        public LandingStatus getStatus(ISpaceVehicle _spaceCraft,IDimension _pos) {

            LandingStatus aux;

            ControlTower _controlTower = new ControlTower();
            _controlTower._land = new LandingArea(1, new Size(100, 100), new Position(), "Houston #1");
            ILand _platAux = new LandingPlatform(1, new Size(10, 10), new Position(5, 5), "Platform #1");
            _controlTower._land._content.Add(1, _platAux);

            _spaceCraft.myControlTower = _controlTower;

            LandingPlatform _firstPlatform=null;

            foreach (KeyValuePair<int, ILand> _iland in _spaceCraft.myControlTower._land._content)
            {
                if (_iland.Value.IsLandingPlatform())
                    _firstPlatform = (LandingPlatform)_spaceCraft.myControlTower._land._content[_iland.Key];
            }

            var landService = _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ILandService>();
            if ((_firstPlatform != null) && (_firstPlatform.IsLandingPlatform()))
            {
                bool inside = landService.isInside(_firstPlatform, _spaceCraft.LandCheckPosition);

                if (inside)
                {
              
                    aux = GetClash(_spaceCraft);


                }
                else
                {
                    aux= LandingStatus.Out;
                }

            }
            else {
                aux= LandingStatus.Out;
            }

            return aux;
        }

        public LandingStatus GetClash(ISpaceVehicle _spaceCraft) {

            LandingStatus aux= LandingStatus.OK;
            try
            {
                ISpaceVehicle _rocketSamePosition =
                           _spaceCraft.myControlTower.checkedPositions
                           [(Position)_spaceCraft.LandCheckPosition];


                if ((_rocketSamePosition != null)
                    && (_rocketSamePosition.Id != _spaceCraft.Id))
                {
                    ILand miniAntiLandingArea = new LandingArea();
                    miniAntiLandingArea._size = new Size(2, 2);
                    miniAntiLandingArea.InitialPosition =
                        new Position(_rocketSamePosition.LandCheckPosition.x - 1,
                        _rocketSamePosition.LandCheckPosition.y - 1);

                    var landService = _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ILandService>();

                    if (landService.isInside(miniAntiLandingArea, _spaceCraft.LandCheckPosition))
                        aux = LandingStatus.Clash;

                }

                if (_spaceCraft.myControlTower.checkedPositions.Count == 0)
                {
                    aux = LandingStatus.OK;
                }
            }
            catch (KeyNotFoundException e) {
                aux = LandingStatus.OK;
            }

            return aux;


        }
    }
}
