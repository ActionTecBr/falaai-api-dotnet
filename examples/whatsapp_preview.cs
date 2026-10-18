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

        // PREVIEW (dry_run) - passo GRATIS: valida/segmenta o export e ESTIMA os creditos, SEM IA e SEM debito.
        // SEM start/end: a API usa o periodo REAL do export (fora do preview a janela e obrigatoria).
        // REQUIRED: file (.zip/.txt export), timezone, date_format + Authorization
        // OPTIONAL: gap_minutes (default 720) | min_messages (default 2) | client_reference_id
        using var stream = File.OpenRead("demo_whatsapp.zip");
        var result = await new WhatsappApi(config).ExtractConversationsV1WhatsappExtractConversationsPostAsync(
            file: stream,
            timezone: "-3",
            dateFormat: "day_first",
            gapMinutes: 720,
            minMessages: 2,
            voiceNote: true,
            expression: true,
            dryRun: true);

        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented));
    }
}
