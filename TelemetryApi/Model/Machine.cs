using System.ComponentModel.DataAnnotations;

namespace TelemetryApi.Model
{
    public class MachineStatus
    {
        [Key]
        public string machineid { get; set; }
        public string address { get; set; }
        
        public DateTime createdat { get; set; }

        
    }
}
