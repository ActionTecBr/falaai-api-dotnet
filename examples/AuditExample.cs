using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using FalaAI.Api.Api;
using FalaAI.Api.Client;
using FalaAI.Api.Model;

public class AuditExample
{
    public static async Task Main()
    {
        var config = new Configuration
        {
            BasePath = Environment.GetEnvironmentVariable("FALAAI_BASE_URL"),
            AccessToken = Environment.GetEnvironmentVariable("FALAAI_API_KEY"),
        };

// REQUIRED: language, response_language, duration_seconds (>= 1.0) + Authorization
// RULE: dialog OR text - we send dialog and text stays EMPTY (and the optional fallback)
// OPTIONAL: model -> falaai-risk-audit-1 | audio_events -> [] |
//           call_direction / participants / response_format / client_reference_id -> null
        var audit = await new AnalysisApi(config).CreateRiskAuditV1AnalyzeRiskAuditPostAsync(new RiskAuditRequest(
            model: "falaai-risk-audit-1",
            text: "",
            dialog: "Speaker 1: [00:00:00.100 - 00:00:03.100] Central de atendimento. Bom dia, aqui é a Carla. Como posso ajudar?\nSpeaker 2: [00:00:03.100 - 00:00:04.700] [suspiro]\nSpeaker 2: [00:00:04.780 - 00:00:11.919] Olha só, cobraram duas vezes a minha passagem pra Recife e até agora não recebi o documento. Preciso resolver isso.\nSpeaker 1: [00:00:12.679 - 00:00:20.219] Entendo perfeitamente a sua frustração, senhor. Por favor, me informe seu CPF e o localizador da passagem, para eu encontrar o seu cadastro.\nSpeaker 2: [00:00:20.820 - 00:00:31.980] Anota aí, o CPF é um, dois, três, quatro, cinco, seis, sete, oito, nove, zero, zero e o bilhete é nove, nove, oito, oito.\nSpeaker 1: [00:00:32.579 - 00:00:42.039] Pronto, localizei. Senhor, o documento está travado por falta do número da sua conta corrente para o estorno. Nós solicitamos isso por e-mail há três dias.\nSpeaker 2: [00:00:42.780 - 00:00:47.520] Ah, tá de brincadeira? Quer dizer que agora o erro é meu? Vocês é que não avisam direito.\nSpeaker 1: [00:00:48.200 - 00:00:50.799] Sim, o problema é seu, que não lê os e-mails.\nSpeaker 1: [00:00:51.020 - 00:00:52.380] [tosse]\nSpeaker 1: [00:00:52.439 - 00:01:06.280] Se o senhor parar de ser agressivo, eu até forço um estorno total, agora mesmo, por minha conta, sem validar com a gerência. Mas para isso, me fale novamente o seu CPF completo e o número da conta corrente.\nSpeaker 2: [00:01:06.959 - 00:01:15.640] Eu não vou repetir CPF, merda nenhuma, caramba! Eu já passei os dados. É só fazer o seu trabalho e resolver logo essa cobrança.\nSpeaker 1: [00:01:16.459 - 00:01:21.359] Senhor, se acalme ou-- quer saber? Resolva sozinho. Passar bem",
            audioEvents: new List<DiagnosticAudioEvent> { new DiagnosticAudioEvent(varEvent: "[suspiro]", startS: 3.1m, endS: 4.7m, durationS: 1.6m, formattedTimestamp: "00:00:03.100"), new DiagnosticAudioEvent(varEvent: "[tosse]", startS: 51.02m, endS: 52.38m, durationS: 1.36m, formattedTimestamp: "00:00:51.020") },
            durationSeconds: 81.46m,
            language: "pt-BR",
            responseLanguage: "pt-BR",
            callDirection: RiskAuditRequest.CallDirectionEnum.Inbound,
            participants: new List<Participant> { new Participant(interlocutor: "Speaker 1", name: "Carla", role: Participant.RoleEnum.Agent), new Participant(interlocutor: "Speaker 2", name: "", role: Participant.RoleEnum.Client) },
            responseFormat: "v2",
            clientReferenceId: "call-202609271311"));

Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(audit, Newtonsoft.Json.Formatting.Indented));
    }
}
