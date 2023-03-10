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

----

# Practical Demo

**Step 1:** Create a .Net core 6.0 application and deploy it to Web App.

**Step 2:** Create Application Insights in Azure
<kbd>
![image](https://user-images.githubusercontent.com/30829678/224212706-b56a6941-fb30-4773-ad51-493822c24971.png)
</kbd>

![image](https://user-images.githubusercontent.com/30829678/224212956-68278d6c-53a6-40e7-9149-2ccc28a4b6d6.png)
<br/><br/>

**Step 3:**  Copy the Instrument Key of Application insight and save in WebApp Application configuration.
<kbd>
![image](https://user-images.githubusercontent.com/30829678/224213192-8ad3f6b9-87b5-402a-847d-72aeec53a456.png)
</kbd>

![image](https://user-images.githubusercontent.com/30829678/224213217-af7d37b6-6980-4ec5-977a-056001c229f1.png)

![image](https://user-images.githubusercontent.com/30829678/224213239-cd44c322-f46b-4ea8-b52b-94e78fa72f7d.png)
<br/><br/>

**Step 4:** Add nuget package - Microsoft.ApplicationInsights.Aspnetcore
<kbd>
![image](https://user-images.githubusercontent.com/30829678/224213527-7656a753-bb0a-481a-958a-08105e6ea8a7.png)
</kbd>

<br/><br/>

**Step 5:**  Update program.cs file to add service

<pre>
var builder = WebApplication.CreateBuilder(args);

<b>//Add Logging support
builder.Services.AddApplicationInsightsTelemetry();</b>

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
</pre>

<br/>

**Step 6:**  Add few logs for testing purpose in Home --> Index action method and Publish it to Azure.

```csharp
public IActionResult Index()
{
    //To log structure data
    var weatherObj = new
    {
        Date = DateTime.Now.AddDays(Random.Shared.Next(1, 15)),
        TemperatureC = Random.Shared.Next(-20, 55),
    };

    _logger.LogDebug($"Debug {weatherObj}");
    _logger.LogInformation($"Info {weatherObj}");
    _logger.LogWarning($"Warning {weatherObj}");
    _logger.LogError($"Error {weatherObj}");
    _logger.LogCritical($"Criteria {weatherObj}");

    try
    {
        throw new NotImplementedException();
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, ex.Message);
    }

    return View();
}
```


**Step 7:** Go to Application Insights and view the logs




