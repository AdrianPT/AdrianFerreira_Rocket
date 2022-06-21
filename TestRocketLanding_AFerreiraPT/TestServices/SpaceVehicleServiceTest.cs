using System;
using TestRocketLanding_AFerreiraPT.TestingValues;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using RocketLanding_AFerreiraPT.Factories;
using RocketLanding_AFerreiraPT.Factories.Interfaces;
using RocketLanding_AFerreiraPT.Models;
using RocketLanding_AFerreiraPT.Services.Interfaces;
using Xunit;
using RocketLanding_AFerreiraPT.Services;

namespace TestRocketLanding_AFerreiraPT.TestServices
{
    public class SpaceVehicleServiceTest
    {
        private readonly IServiceProvider _serviceProvider;

        public SpaceVehicleServiceTest()
        {
            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider.Setup(x => x.GetService(typeof(ISpaceVehicleModelFactory))).Returns(new SpaceVehicleModelFactory());
            serviceProvider.Setup(x => x.GetService(typeof(ISpaceVehicleService))).Returns(new SpaceVehicleService());

            //Default code to implement mock of dependency injection
            var serviceScope = new Mock<IServiceScope>();
            serviceScope.Setup(x => x.ServiceProvider).Returns(serviceProvider.Object);

            var serviceScopeFactory = new Mock<IServiceScopeFactory>();
            serviceScopeFactory.Setup(x => x.CreateScope()).Returns(serviceScope.Object);

            serviceProvider.Setup(x => x.GetService(typeof(IServiceScopeFactory))).Returns(serviceScopeFactory.Object);

            _serviceProvider = serviceProvider.Object;
        }


        [Theory]
        [ClassData(typeof(SpaceVehicleService_TestingValues))]
        public void ChangeCheckPosition_Rocket_NewPosition(ISpaceVehicle _rocket)
        {
            var spaceVehicleService = _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ISpaceVehicleService>();
            spaceVehicleService.ChangeCheckPosition(_rocket,new Position(3,4));
            Assert.Equal(3,_rocket.LandCheckPosition.x);

        }

        [Theory]
        [ClassData(typeof(SpaceVehicleService_TestingValues))]
        public void ChangeCurrentPosition_Rocket_NewPosition(ISpaceVehicle _rocket)
        {
            var spaceVehicleService = _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ISpaceVehicleService>();
            spaceVehicleService.ChangeCurrentPosition(_rocket, new Position(3, 4));
            Assert.Equal(3, _rocket.CurrentPosition.x);

        }


        [Fact]
        public void IsRocket_SpaceVehicleType_ReturnTrue()
        {
            var _rocket = new Rocket();
            Assert.IsAssignableFrom<ISpaceVehicle>(_rocket);
        }


    }
}
