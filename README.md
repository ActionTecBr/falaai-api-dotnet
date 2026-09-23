# FalaAI API - .NET / C# SDK

[![version](https://img.shields.io/badge/version-1.21.47-blue)](https://www.nuget.org/packages/FalaAI.Api)
[![license](https://img.shields.io/badge/license-MIT-green)](https://github.com/ActionTecBr/falaai-api-dotnet/blob/main/LICENSE)
[![build](https://github.com/ActionTecBr/falaai-api-dotnet/actions/workflows/ci.yml/badge.svg)](https://github.com/ActionTecBr/falaai-api-dotnet/actions/workflows/ci.yml)

Official .NET / C# SDK for the **FalaAI API**.

## What is FalaAI API?

FalaAI API turns conversations into auditable business intelligence, in three steps:

1. **Transcribe** - audio (calls, voice notes, meetings) to text, with speaker separation.
2. **Diagnose** - summary, reason, recommended action, topic and sentiment per conversation.
3. **Audit compliance** - risk score and violations against **COPC CX** and **ISO 18295-1**.

It works with **phone calls and call recordings** (PABX IP, Asterisk, FreePBX, contact center),
**messaging** (WhatsApp, Telegram, web chat, SMS) and email - anything that can be turned into
text. Three REST endpoints, one API key, no setup.

## Who it's for

| Role | What they get |
| --- | --- |
| **Contact Center / Quality** | Audit 100% of conversations instead of a sample |
| **Compliance / Legal** | Forensic, auditable evidence for audits and disputes |
| **CX / Operations** | Risk score, sentiment and reason for every conversation |
| **Developers** | One typed SDK, three REST endpoints, one API key |
| **Data / BI** | Clean, typed JSON ready for your database or BI tool |

## Install

```bash
dotnet add package FalaAI.Api
```

## Quick start

```csharp
using FalaAI.Api.Api;
using FalaAI.Api.Client;

var config = new Configuration
{
    BasePath = "https://api01-falaai.action.tec.br",
    AccessToken = "fai_xxxxxx",
};

var speech = new SpeechApi(config);

using var stream = File.OpenRead("call.mp3");
var file = new FileParameter("call.mp3", "audio/mpeg", stream);

var response = await speech.CreateTranscriptionV1AudioTranscriptionsPostWithHttpInfoAsync(
    file, "falaai-transcribe-1", "pt");

Console.WriteLine(response.Data.Text);
```

## Use cases

- Call and voice-note **transcription** with speaker separation
- **Contact center quality assurance (QA)** automation
- **Compliance auditing** against **COPC CX** and **ISO 18295-1**
- **Risk detection** - churn risk, legal threats, escalation
- **WhatsApp, Telegram and chat** conversation analysis
- **CRM and help desk** enrichment
- **LGPD**-aware handling of customer conversations

## Where it fits

Common .NET stacks in contact center, CRM and help desk - if you build on any of these, the SDK drops in:

Microsoft Dynamics 365 - Genesys Cloud CX - 3CX - Microsoft Teams - Telegram.Bot

> Product names are trademarks of their respective owners, listed as common stacks in this ecosystem. No partnership is implied.

## Endpoints

| Method | Path | Description |
| --- | --- | --- |
| `POST` | `/v1/audio/transcriptions` | Audio to text, with speaker separation |
| `POST` | `/v1/analyze/diagnostic` | Conversation analysis - summary, reason, action, topic, sentiment |
| `POST` | `/v1/analyze/auditoriaRisco` | Compliance audit - risk score and violations |

All endpoints require `Authorization: Bearer fai_xxxxxx`.
Full reference: <https://api01-falaai.action.tec.br/docs>

## Links

- **Product:** <https://falaai.action.tec.br/api>
- **API reference:** <https://api01-falaai.action.tec.br/docs>
- **Get an API key:** <https://falaai.action.tec.br/api/auth>
- **Package (NuGet):** <https://www.nuget.org/packages/FalaAI.Api>
- **Source:** <https://github.com/ActionTecBr/falaai-api-dotnet>

## License

MIT (c) 2026 Action Tec Br - see [LICENSE](LICENSE).
