# FalaAI API — .NET SDK

Official .NET/C# SDK for the **FalaAI API** — AI-powered call transcription, diagnosis and compliance auditing.

## Install

```bash
dotnet add package FalaAI.Api
```

## Quick start

```csharp
using FalaAI.Api.Api;
using FalaAI.Api.Client;

var config = new Configuration { BasePath = "https://api01-falaai.action.tec.br", AccessToken = "fai_xxx" };
var health = new HealthApi(config);
var res = await health.HealthCheckWithHttpInfoAsync();
Console.WriteLine($"{res.Data.Status} {(int)res.StatusCode}");
```

## Endpoints

| Method | Path | Description |
|---|---|---|
| POST | `/v1/audio/transcriptions` | Audio to text (diarization, audio events) |
| POST | `/v1/analyze/diagnostic` | Conversation analysis |
| POST | `/v1/analyze/auditoriaRisco` | Compliance audit (risk) |
| GET | `/v1/usage/log` | Usage log |
| GET | `/v1/usage/by-key` | Usage grouped by API key |
| GET/POST | `/v1/webhooks` | List / create webhooks |
| PUT/DELETE | `/v1/webhooks/{webhook_id}` | Update / delete webhook |
| GET/POST | `/v1/email-alerts` | List / create email alerts |
| PUT/DELETE | `/v1/email-alerts/{alert_id}` | Update / delete email alert |
| GET | `/api/version` | API version |
| GET/HEAD | `/v1/health` | Health check |

## Authentication

Authenticated endpoints require an API key in the `Authorization` header:

```
Authorization: Bearer fai_xxx
```

Get your API key at [falaai.action.tec.br/api](https://falaai.action.tec.br/api).

## License

[MIT](LICENSE) © Action Tec Br