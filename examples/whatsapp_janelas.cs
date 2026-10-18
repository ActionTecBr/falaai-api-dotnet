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

        // EXTRACAO real (debita creditos) por VARIAS janelas - selecao = UNIAO das sobreposicoes (dedup).
        // windows NAO combina com start/end (400 invalid_windows); a 2a janela e um exemplo.
        // REQUIRED: file (.zip/.txt export), windows, timezone, date_format + Authorization
        // OPTIONAL: gap_minutes (default 720) | min_messages (default 2) | client_reference_id
        using var stream = File.OpenRead("demo_whatsapp.zip");
        var result = await new WhatsappApi(config).ExtractConversationsV1WhatsappExtractConversationsPostAsync(
            file: stream,
            windows: "[{\"start\":\"2024-01-01 00:00\",\"end\":\"2024-12-31 23:59\"},{\"start\":\"06/03/2024 09:00\",\"end\":\"06/03/2024 12:00\"}]",
            timezone: "-3",
            dateFormat: "day_first",
            gapMinutes: 720,
            minMessages: 2,
            voiceNote: true,
            expression: true);

        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented));
    }
}
