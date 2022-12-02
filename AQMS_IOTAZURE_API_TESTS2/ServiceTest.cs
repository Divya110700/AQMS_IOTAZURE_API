using AQMS_IOTAZURE_API.Data;
using AQMS_IOTAZURE_API.Models;
using AQMS_IOTAZURE_API.Controllers;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace AQMS_IOTAZURE_API_TESTS2
{
    public class ServiceTest
    {
        private static DbContextOptions<SensorDbContext> dbContextOptions = new DbContextOptionsBuilder<SensorDbContext>()
            .UseInMemoryDatabase(databaseName: "AQMSDbTest")
            .Options;

        SensorDbContext context;
        SensorsController SensorsController;
            
        [OneTimeSetUp]
        public void Setup()
        {
            context = new SensorDbContext(dbContextOptions);
            context.Database.EnsureCreated();

            SeedDatabase();
            SensorsController = new SensorsController(context);
        }

        [Test, Order(1)]
        public void HttpGET_GetAllSensors()
        {
            var result = SensorsController.Get();
            //Assert.That(actionResult, Is.TypeOf<OkObjectResult>());
            //var ResultData = (Result as OkObjectResult).Value as List<Sensor>;
            //Assert.That(actionResultData.First().Name, Is.EqualTo("Sensor 6"));
            Assert.That(result.First().Id, Is.EqualTo(1));
            Assert.That(result.Count, Is.EqualTo(6));
            //Assert.AreEqual(result.Count, 6);
            //var Result = SensorsController.Get(1);
            //Assert.That(Result.Count, Is.EqualTo(6));
            //Assert.That(Result.First().Id, Is.EqualTo(1));
        }
        [Test, Order(2)]
        public void HttpPUT_GetAllSensors_byId()
        {
            var result1 = SensorsController.Get(1);
            Assert.That(result1.Id, Is.EqualTo(1));
        }
        [Test, Order(3)]
        public void HttpGET_GetAllSensorsById()
        {
            var result2 = SensorsController.Get(1);
            Assert.That(result2.Id, Is.EqualTo(1));
        }
        [Test, Order(4)]
        public void HttpDelete_DeleteSensorsById()
        {
            int Id = 1;
            IActionResult actionResult= SensorsController.Delete(Id);
            Assert.That(actionResult, Is.TypeOf<OkObjectResult>());
        }
        [Test, Order(5)]
        public void HttpPost_AddSensorData()
        {
            var Sensor = new Sensor()
            {
                
                Mapped_Floor = 2,
                Dust_Parcticle = 44,
                Co2 = 54,
                Co = 64,
                No2 = 74,
                So2 = 84

            };
            IActionResult actionResult = SensorsController.Post(Sensor);
            Assert.That(actionResult, Is.TypeOf<StatusCodeResult>());




        }



        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }

        private void SeedDatabase()
        {
            var Sensors = new List<Sensor>
            {
                new Sensor()
                {
                    Id = 1,
                    Mapped_Floor = 1,
                    Dust_Parcticle =56,
                    Co2 = 66,
                    Co = 76,
                    No2 = 86,
                    So2 = 96
                },
                 new Sensor()
                {
                    Id = 2,
                    Mapped_Floor = 2,
                    Dust_Parcticle =44,
                    Co2 = 54,
                    Co = 64,
                    No2 = 74,
                    So2 = 84
                },
                  new Sensor()
                {
                    Id = 3,
                    Mapped_Floor = 3,
                    Dust_Parcticle =33,
                    Co2 = 44,
                    Co = 55,
                    No2 = 66,
                    So2 = 77
                },
                   new Sensor()
                {
                    Id = 4,
                    Mapped_Floor = 1,
                    Dust_Parcticle =11,
                    Co2 = 12,
                    Co = 13,
                    No2 = 14,
                    So2 = 15
                },
                    new Sensor()
                {
                    Id = 5,
                    Mapped_Floor = 2,
                    Dust_Parcticle = 98,
                    Co2 = 88,
                    Co = 78,
                    No2 = 45,
                    So2 = 66
                },
                     new Sensor()
                {
                    Id = 6,
                    Mapped_Floor = 3,
                    Dust_Parcticle =65,
                    Co2 = 75,
                    Co = 85,
                    No2 = 55,
                    So2 = 67
                }
            };
            context.Sensors.AddRange(Sensors);


            context.SaveChanges();
        }
    }
}