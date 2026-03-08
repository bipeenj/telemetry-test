namespace TelemetryApi.Model
{
    public class Telemetry
    {
        
            public string MachineId { get; set; }
            public string Status { get; set; }
            public double TemperatureC { get; set; }
            public string LastErrorCode { get; set; }
            public DateTime Timestamp { get; set; }
        
    }
}
