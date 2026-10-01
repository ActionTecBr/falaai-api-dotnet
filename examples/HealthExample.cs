using System;
using System.Threading.Tasks;
using FalaAI.Api.Api;
using FalaAI.Api.Client;

public class HealthExample
{
    public static async Task Main()
    {
        var config = new Configuration
        {
            BasePath = Environment.GetEnvironmentVariable("FALAAI_BASE_URL"),
        };

        var health = await new HealthApi(config).HealthCheckAsync();
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(health, Newtonsoft.Json.Formatting.Indented));

        await new HealthApi(config).HealthCheckHeadAsync();
    }
}
