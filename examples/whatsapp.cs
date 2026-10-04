using System;
using System.IO;
using System.Threading.Tasks;
using FalaAI.Api.Api;
using FalaAI.Api.Client;

public class WhatsappExample
{
    public static async Task Main()
    {
        var config = new Configuration
        {
            BasePath = Environment.GetEnvironmentVariable("FALAAI_BASE_URL"),
            AccessToken = Environment.GetEnvironmentVariable("FALAAI_API_KEY"),
        };

        // REQUIRED: file (.zip/.txt export), start, end, timezone, date_format + Authorization
        // OPTIONAL: gap_minutes (default 720) | min_messages (default 2) | chars_per_minute (default 800) | client_reference_id
        using var stream = File.OpenRead("demo_whatsapp.zip");
        var result = await new WhatsappApi(config).ExtractConversationsV1WhatsappExtractConversationsPostAsync(
            file: stream,
            start: "2024-01-01T00:00:00",
            end: "2024-12-31T23:59:59",
            timezone: "-3",
            dateFormat: "day_first",
            gapMinutes: 720,
            minMessages: 2,
            charsPerMinute: 800);

        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented));
    }
}
