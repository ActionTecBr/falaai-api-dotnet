using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using FalaAI.Api.Api;
using FalaAI.Api.Client;
using FalaAI.Api.Model;
using Xunit;

namespace FalaAI.E2e;

public class AiTest
{
    private static void NonEmpty(string label, string? v)
    {
        Assert.NotNull(v);
        Assert.False(string.IsNullOrEmpty(v), label + " vazio");
    }

    [Fact]
    public async Task AiChain()
    {
        var cfg = E2eConfig.Configuration(E2eConfig.Prod());
        var sp = new SpeechApi(cfg);
        var an = new AnalysisApi(cfg);

        using var stream = File.OpenRead(E2eConfig.Audio());
        var file = new FileParameter("analise_25s.mp3", "audio/mpeg", stream);
        var trr = await sp.CreateTranscriptionV1AudioTranscriptionsPostWithHttpInfoAsync(file, "falaai-transcribe-1", "pt", "e2e-call-2026-09-22-001");
        var tr = trr.Data;
        E2eLogger.Log("transcriptions", "POST", "/v1/audio/transcriptions",
            new { file = "analise_25s.mp3", model = "falaai-transcribe-1", language = "pt", client_reference_id = "e2e-call-2026-09-22-001" },
            tr, $"HTTP {(int)trr.StatusCode}", (int)trr.StatusCode);
        Assert.Equal(HttpStatusCode.OK, trr.StatusCode);
        NonEmpty("id", tr.Id);
        Assert.NotNull(tr.Object);
        NonEmpty("model", tr.Model);
        NonEmpty("filename", tr.Filename);
        NonEmpty("processed_at", tr.ProcessedAt);
        Assert.True(tr.Usage.AudioSeconds > 0);
        Assert.IsType<int>(tr.Usage.CreditsConsumed);
        Assert.IsType<int>(tr.Usage.ProcessingMs);
        NonEmpty("language", tr.Language);
        Assert.True(tr.DurationSeconds > 0);
        NonEmpty("text", tr.Text);
        NonEmpty("dialog", tr.Dialog);
        Assert.NotNull(tr.AudioEvents);
        foreach (var ev in tr.AudioEvents)
        {
            NonEmpty("event", ev.Event);
            Assert.IsType<decimal>(ev.StartS);
            Assert.IsType<decimal>(ev.EndS);
            Assert.IsType<decimal>(ev.DurationS);
            NonEmpty("formatted_timestamp", ev.FormattedTimestamp);
        }
        Assert.NotNull(tr.EventTypes);
        Assert.True(tr.WordCount > 0);
        Assert.IsType<decimal>(tr.Input.DurationS);
        NonEmpty("input.original_format", tr.Input.OriginalFormat);
        NonEmpty("input.codec", tr.Input.Codec);
        Assert.IsType<int>(tr.Input.SampleRate);
        Assert.IsType<int>(tr.Input.Channels);

        var events = new List<DiagnosticAudioEvent>();
        foreach (var ev in tr.AudioEvents)
        {
            events.Add(new DiagnosticAudioEvent(varEvent: ev.Event, startS: ev.StartS, endS: ev.EndS, durationS: ev.DurationS, formattedTimestamp: ev.FormattedTimestamp));
        }

        var db = new DiagnosticRequest(model: "falaai-diagnostic-1", text: tr.Text, dialog: tr.Dialog, audioEvents: events,
            language: "pt-BR", durationSeconds: tr.DurationSeconds, clientReferenceId: "e2e-diag-2026-09-22-001");
        var dr = await an.CreateDiagnosticV1AnalyzeDiagnosticPostWithHttpInfoAsync(db);
        var d = dr.Data;
        E2eLogger.Log("diagnostic", "POST", "/v1/analyze/diagnostic", db, d, $"HTTP {(int)dr.StatusCode}", (int)dr.StatusCode);
        Assert.Equal(HttpStatusCode.OK, dr.StatusCode);
        NonEmpty("id", d.Id);
        NonEmpty("response_language", d.ResponseLanguage);
        Assert.Equal("analysis", d.Object);
        Assert.NotNull(d.Analysis.DialogueSummary);
        Assert.NotNull(d.Analysis.ContactReason);
        Assert.NotNull(d.Analysis.IdentifiedAction);
        Assert.NotNull(d.Analysis.IdentifiedLabel);
        Assert.NotNull(d.Analysis.Sentiment);
        Assert.IsType<int>(d.Usage.Characters);
        Assert.IsType<int>(d.Usage.CreditsConsumed);
        Assert.IsType<int>(d.Usage.ProcessingMs);

        var ab = new AuditoriaRiscoRequest(model: "falaai-auditoria-risco-1", text: tr.Text, dialog: tr.Dialog, audioEvents: events,
            durationSeconds: tr.DurationSeconds, language: "pt-BR", responseLanguage: "pt-BR",
            callDirection: AuditoriaRiscoRequest.CallDirectionEnum.Inbound,
            participants: new List<Participant>
            {
                new Participant(interlocutor: "Speaker 1", name: "Mateus", role: Participant.RoleEnum.Agent),
                new Participant(interlocutor: "Speaker 2", name: "Cliente", role: Participant.RoleEnum.Client)
            },
            responseFormat: "v2", clientReferenceId: "e2e-aud-2026-09-22-001");
        var ar = await an.CreateAuditoriaRiscoV1AnalyzeAuditoriaRiscoPostWithHttpInfoAsync(ab);
        var pub = ar.Data.Response;
        E2eLogger.Log("auditoriaRisco", "POST", "/v1/analyze/auditoriaRisco", ab, ar.Data, $"HTTP {(int)ar.StatusCode}", (int)ar.StatusCode);
        Assert.Equal(HttpStatusCode.OK, ar.StatusCode);
        NonEmpty("meta.id", pub.Meta.Id);
        Assert.IsType<int>(pub.Meta.Usage.Characters);
        Assert.IsType<int>(pub.Meta.Usage.CreditsConsumed);
        Assert.IsType<int>(pub.Meta.Usage.ProcessingMs);
        Assert.NotNull(pub.Participants);
        Assert.NotNull(pub.Verdict);
        Assert.NotNull(pub.Scores);
        Assert.NotNull(pub.Detections);
        Assert.NotNull(pub.Analysis);
        Assert.NotNull(pub.Timeline);
        Assert.NotNull(pub.AudioEventModel);
        Assert.NotNull(pub.CategoriesSummary);
        Assert.NotNull(pub.Indexer);
        Assert.NotNull(pub.Summary);
        Assert.NotNull(pub.AcoesI18n);
        Assert.NotNull(pub.AuditDecisions);
        Assert.NotNull(pub.ScoringExplanation);
        Assert.NotNull(pub.HtmlReport);
    }
}