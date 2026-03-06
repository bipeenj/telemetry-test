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

CREATE INDEX idx_machine_timestamp
ON TelemetrySnapshots (MachineId, report_time DESC);
