namespace TelemetryApi.Model
{
    public class MachineStatus
    {
        public string MachineId { get; set; }
        public string Status { get; set; }
        public double TemperatureC { get; set; }
        public string LastErrorCode { get; set; }

        public bool HasAlert =>
            Status != "OK" || TemperatureC > 28;
    }
}
