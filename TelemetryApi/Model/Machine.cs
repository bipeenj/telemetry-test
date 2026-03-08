using System.ComponentModel.DataAnnotations;

namespace TelemetryApi.Model
{
    public class MachineEntry
    {
        [Key]
        public string machineid { get; set; }
        public string? address { get; set; }
        
        public DateTime createdat { get; set; }

        
    }
    public class MachineLog
    {
        [Key]
        public int id { get; set; }
        public string machineid { get; set; }
        public string status { get; set; }
        public double temperaturec { get; set; }
        public string error_code { get; set; }
        public DateTime reportTime { get; set; }
    }
}
