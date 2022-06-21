using Microsoft.Extensions.DependencyInjection;
using Moq;
using RocketLanding_AFerreiraPT.Factories;
using RocketLanding_AFerreiraPT.Factories.Interfaces;
using RocketLanding_AFerreiraPT.Models;
using RocketLanding_AFerreiraPT.Services;
using RocketLanding_AFerreiraPT.Services.Interfaces;
using System;
using System.Collections.Generic;
using TestRocketLanding_AFerreiraPT.TestingValues;
using Xunit;

namespace TestRocketLanding_AFerreiraPT.TestServices
{
    public class LandServiceTest
    {
        private readonly IServiceProvider _serviceProvider;
  
        public LandServiceTest()
        {
            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider.Setup(x => x.GetService(typeof(ILandModelFactory))).Returns(new LandModelFactory());

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
        [ClassData(typeof(LandService_TestingValues))]
        public void AddLand(LandingArea area, ILand item)
        {
            area._content.Add(item.Id, item);
            Assert.NotEmpty(area._content);
        }

        [Theory]
        [ClassData(typeof(LandService_TestingValues))]
        public void RemoveLand(LandingArea area, ILand item)
        {
            area._content.Add(item.Id, item);
            area._content.Remove(item.Id);
            Assert.Empty(area._content);
        }


        [Theory]
        [ClassData(typeof(LandService_TestingValues))]
        public void CreateLandingArea_LandingAreaWithLandingPlatform_LandingAreaWithPlatform
            (LandingArea _landArea, LandingPlatform _platform)
        {
            var landService = _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ILandService>();

            landService.Add(_landArea,_platform);
            LandingPlatform aux= (LandingPlatform)_landArea._content[_platform.Id];
            Assert.Equal(_platform.Id, aux.Id);
            
        }

        [Theory]
        [ClassData(typeof(LandService_TestingValues))]
        public void RemovePlatform_FromLandingAreaWithLandingPlatform_LandingAreaWithoutPlatform
             (LandingArea _landArea, LandingPlatform _platform)
        {
            var landService = _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ILandService>();

            landService.Add(_landArea, _platform);
            landService.Remove(_landArea, _platform);

            Assert.Empty(_landArea._content);
        }

        [Theory]
        [ClassData(typeof(LandService_TestingValues))]
        public void ChangeSize_ChangeSizeLandingPlatformBiggerThanArea_PlatformAndLandAreaNewSize
         (LandingArea _landArea, LandingPlatform _platform)
        {
            _landArea._size = new Size(3, 3);
            _platform.InitialPosition = new Position(1, 1);
            _platform._size = new Size(3, 4);
            int absoluteX = (_platform._size.x +
                _platform.InitialPosition.x);
            int absoluteY = (_platform._size.y +
                _platform.InitialPosition.y);

            if (absoluteX > _landArea._size.x)
            {
                _landArea._size.x = absoluteX;
            }
            if (absoluteY > _landArea._size.y)
            {
                _landArea._size.y = absoluteY;
            }

            Assert.Equal(absoluteY, _landArea._size.y);
            Assert.Equal(absoluteX, _landArea._size.x);
        }

        [Fact]
        public void ChangeSize()
        {
            ISpaceVehicle _rocket = new Rocket();
            Size _size = new Size(3, 3);

            _rocket.Id = 1;

            ControlTower _controlTower = new ControlTower();
            _controlTower._land = new LandingArea(1, new Size(100, 100), new Position(), "Houston #1");
            ILand _platAux = new LandingPlatform(1, new Size(10, 10), new Position(5, 5), "Platform #1");
            _controlTower._land._content.Add(1, _platAux);

            _rocket.myControlTower = _controlTower;


            LandingPlatform _firstPlatform = null;

            foreach (KeyValuePair<int, ILand> _iland in _rocket.myControlTower._land._content)
            {
                if (_iland.Value.IsLandingPlatform())
                    _firstPlatform = (LandingPlatform)_rocket.myControlTower._land._content[_iland.Key];
            }
            var landService = _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ILandService>();

            if ((_firstPlatform != null) && (_firstPlatform.IsLandingPlatform()))
            {
                _firstPlatform._size = _size;
                landService.ChangeSize(_rocket.myControlTower._land, _firstPlatform);
            }

            Assert.Equal(_firstPlatform._size.x, _size.x);
            Assert.Equal(_firstPlatform._size.y, _size.y);
        }


        [Theory]
        [InlineData(5, 5)]
        [InlineData(15, 15)]
        [InlineData(7, 7)]
        public void isInside_True(int x,int y)
        {
            bool xInside = false;
            bool yInside = false;

            Position _pos = new Position(x, y);

            ILand platform = new LandingPlatform();

            platform.InitialPosition = new Position(5, 5);
            platform._size = new Size(10, 10);

            int max_X = platform._size.x + platform.InitialPosition.x;
            int max_Y = platform._size.y + platform.InitialPosition.y;
            int min_X = platform.InitialPosition.x;
            int min_Y = platform.InitialPosition.y;

            if ((_pos.x >= min_X) && (_pos.x <= max_X)) {
                xInside = true;
            }
            if ((_pos.y >= min_Y) && (_pos.y <= max_Y))
            {
                yInside = true;
            }

            Assert.True((xInside && yInside));
            
        }



        [Theory]
        [ClassData(typeof(LandService_TestingValues))]
        public void UpdateSizePlatform_ServiceChangeSizeLandingPlatform_PlatformNewSize
         (LandingArea _landArea, LandingPlatform _platform)
        {
          
            var landService = _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ILandService>();
      
            _platform._size = new Size(3,4);
            landService.Add(_landArea, _platform);
            _landArea._content[_platform.Id]._size = new Size(5, 7);
            Assert.Equal(5, _landArea._content[_platform.Id]._size.x);
        }



        [Fact]
        public void IsLandingPlatform_LandPlatformTypeIsCreated_ReturnTrue()
        {
            var result = IsPlatformWithDependencyInjection(_serviceProvider, 758, LandType.Platform);
            Assert.True(result);
        }

        [Fact]
        public void IsLandingPlatform_LandingAreaTypeIsCreated_ReturnFalse()
        {
            var result = IsPlatformWithDependencyInjection(_serviceProvider, 758, LandType.LandingArea);
            Assert.False(result);
        }

        public static bool IsPlatformWithDependencyInjection(IServiceProvider services, int id, LandType _landType)
        {
            using var serviceScope = services.CreateScope();
            var provider = serviceScope.ServiceProvider;

            var landFactory = provider.GetRequiredService<ILandModelFactory>();

            return landFactory.CreateLand(id, _landType).IsLandingPlatform();
        }

        [Fact]
        public void IsLandingArea_LandType_ReturnTrue()
        {
            var _landingArea = new LandingArea();
            Assert.IsAssignableFrom<ILand>(_landingArea);
        }

        [Fact]
        public void IsPlatform_LandType_ReturnTrue()
        {
            var _platform = new LandingPlatform();
            Assert.IsAssignableFrom<ILand>(_platform);
        }

    }
}
