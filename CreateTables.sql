CREATE TABLE Machines (
    MachineId VARCHAR(50) PRIMARY KEY,
    Address VARCHAR(200),
    CreatedAt TIMESTAMP  DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE TelemetrySnapshots (
    Id SERIAL  PRIMARY KEY,
    MachineId VARCHAR(50) NOT NULL,
    status VARCHAR(20),
    temperatureC FLOAT,
    errorCode VARCHAR(50),
    report_time TIMESTAMP,

    FOREIGN KEY (MachineId) REFERENCES Machines(MachineId)
);
 --Index to be added for efficiency 
CREATE INDEX idx_machine_timestamp
ON TelemetrySnapshots (MachineId, report_time DESC);

-- Querry to select machines from telemetry with their latest values
SELECT m.MachineId, t.Status, t.TemperatureC, t.LastErrorCode
FROM Machines m
JOIN TelemetrySnapshots t 
ON m.MachineId = t.MachineId
WHERE t.Timestamp = (
    SELECT MAX(Timestamp)
    FROM TelemetrySnapshots
    WHERE MachineId = m.MachineId
);