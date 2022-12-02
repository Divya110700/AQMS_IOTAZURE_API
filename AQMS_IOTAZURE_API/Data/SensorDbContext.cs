using AQMS_IOTAZURE_API.Models;
using Microsoft.EntityFrameworkCore;

namespace AQMS_IOTAZURE_API.Data
{
    public class SensorDbContext : DbContext
    {
        public SensorDbContext(DbContextOptions<SensorDbContext>options):base(options)
        {
                  
        }
        public DbSet<Sensor> Sensors { get; set; } //sensors data name will be given to the table in database
    }
}
