namespace AQMS_IOTAZURE_API.Models
{
    public class Sensor
    {
        public int Id { get; set; }
        public int Mapped_Floor { get; set; } //floor to which the sensor is mapped to
        public double Dust_Parcticle { get; set; }//dust particles in Air
        public double Co2 { get; set; }//Carbon-di-oxide
        public double Co { get; set; }//Carbon-mono-oxide
        public double No2 { get; set; }//Nitrogen-dioxide
        public double So2 { get; set; }//Sulphur-dioxide
    }
}
