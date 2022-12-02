using AQMS_IOTAZURE_API.Data;
using AQMS_IOTAZURE_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AQMS_IOTAZURE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorsController : ControllerBase
    {
        private SensorDbContext _dbContext;
        public SensorsController(SensorDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        // GET: api/<SensorsController>
        [HttpGet]
        public IEnumerable<Sensor> Get()
        {
            return _dbContext.Sensors;
        }

        // GET api/<SensorsController>/1
        [HttpGet("{id}")]
        public Sensor Get(int id)
        {
            var Sensor = _dbContext.Sensors.Find(id);
            return Sensor;
        }

        // POST api/<SensorsController>
        [HttpPost]
        public IActionResult Post([FromBody] Sensor sensor)
        {
            _dbContext.Sensors.Add(sensor);
            _dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<SensorsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Sensor sensorObj)
        {
            var Sensor = _dbContext.Sensors.Find(id);
            Sensor.Mapped_Floor = sensorObj.Mapped_Floor;
            Sensor.Dust_Parcticle = sensorObj.Dust_Parcticle;
            Sensor.Co2 = sensorObj.Co2;
            Sensor.Co = sensorObj.Co;
            Sensor.No2 = sensorObj.No2;
            Sensor.So2 = sensorObj.So2;
            _dbContext.SaveChanges();
            return Ok("Record Updated Successfully");
        }


        

        // DELETE api/<SensorsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Sensor = _dbContext.Sensors.Find(id);
            
                _dbContext.Sensors.Remove(Sensor);
                _dbContext.SaveChanges();
                return Ok("Record Deleted Successfully");

            

        }
    }
}
