using System;
using System.Threading.Tasks;
using System.IO;
using FalaAI.Api.Api;
using FalaAI.Api.Client;
using FalaAI.Api.Model;

public class TranscribeExample
{
    public static async Task Main()
    {
        var config = new Configuration
        {
            BasePath = Environment.GetEnvironmentVariable("FALAAI_BASE_URL"),
            AccessToken = Environment.GetEnvironmentVariable("FALAAI_API_KEY"),
        };

        TranscriptionResponse transcription;
        using (var stream = File.OpenRead("demo_callcenter.mp3"))
        {
            var file = new FileParameter("demo_callcenter.mp3", "audio/mpeg", stream);
// REQUIRED: file (audio) + Authorization (fai_ key)
// OPTIONAL (server defaults): model -> falaai-transcribe-1 | language -> pt | client_reference_id -> (empty)
            transcription = await new SpeechApi(config).CreateTranscriptionV1AudioTranscriptionsPostAsync(
                file,
                model: "falaai-transcribe-1",
                language: "pt",
                clientReferenceId: "call_202609271408");
        }

        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(transcription, Newtonsoft.Json.Formatting.Indented));
    }
}
