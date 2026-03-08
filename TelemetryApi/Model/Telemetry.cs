using System.ComponentModel.DataAnnotations;

namespace TelemetryApi.Model
{
    public class Telemetry
    {
            [Key]
            public int id { get; set; }
            public string machineid { get; set; }
            public string status { get; set; }
            public double temperaturec { get; set; }
            public string errorcode { get; set; }
            public DateTime report_time { get; set; }
        
    }
}
