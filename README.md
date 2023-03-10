# Logging with ILogger and sending Telemetry data to Application Insights
.Net core logging with ILogger and sending Telemetry data to Application Insights

---

## There are 2 main ways to send Telemetry data to application insights
- Using ILogger or Logging mechanism and
- Using Tracing or through creating Telemetry client



## Difference between ILogger and Tracing (TelemetryClient for logging)
- ILogger supports fast **[structured logging](https://learn.microsoft.com/en-us/dotnet/core/diagnostics/logging-tracing#structured-logging)** and have a flexible configuration.
- Tracing supports **unstructured logging** i.e. Log entries have free-form text content
- Tracing is [only well supported](https://learn.microsoft.com/en-us/dotnet/core/diagnostics/logging-tracing#trace) in .Net Framework and doesn't have good support in .Net core.
- **ILogger may offer better functionality for .Net Core**

