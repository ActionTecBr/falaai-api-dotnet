# FLUXO DE TESTES DA SDK .NET (NuGet `FalaAI.Api`)
@version 1.0.0 | 30/09/2026 | MANUAL — nao e regenerado pelo exportador de exemplos
SDK: `D:\ProjetoFalaAI\FalaAI\FalaAI_api\sdks\dotnet\` (pacote NuGet `FalaAI.Api`) · Docker: imagem `mcr.microsoft.com/dotnet/sdk:8.0`
Regra de fundo: `.opencode/rules/macro/modulos/falaai-api/sdk-fonte-unica.md` (tests/e2e = MANUAL)

## Scripts e arquivos usados (nomes e paths exatos — LINGUAGEM: C#/.NET)
| # | Script / Arquivo | Path completo | Papel no fluxo |
|---|---|---|---|
| 1 | `run_docker.ps1` v1.1.0 | `D:\ProjetoFalaAI\FalaAI\FalaAI_api\sdks\dotnet\tests\e2e\run_docker.ps1` | WRAPPER (PowerShell): valida csproj + mp3 → **PASSO 0a** (sync exemplos) → Docker `sdk:8.0` → **PASSO FINAL** (sync sandbox-responses) |
| 2 | `run_examples.sh` v2.1.0 | `D:\ProjetoFalaAI\FalaAI\FalaAI_api\sdks\dotnet\tests\e2e\run_examples.sh` | RUNNER (bash, roda DENTRO do container): **limpa logs antigos**, `dotnet build`, executa os 4 exemplos, grava os logs JSON + `.html` |
| 3 | `_generate_dotnet_examples.mjs` v1.4.0 | `D:\ProjetoFalaAI\FalaAI\FalaAI_api\sdks\dotnet\examples\_generate_dotnet_examples.mjs` | EXPORTADOR (**PASSO 0a**, roda no HOST): re-exporta os 4 `.cs` da FONTE UNICA + **gera o README** (versao/data) |
| 4 | `sandbox-examples.ts` | `D:\ProjetoFalaAI\FalaAI\FalaAI_landing\lib\sandbox-examples.ts` | FONTE UNICA dos exemplos (8 linguagens x 4 endpoints, tokens `{{...}}`) |
| 5 | `HealthExample.cs` · `TranscribeExample.cs` · `DiagnoseExample.cs` · `AuditExample.cs` | `D:\ProjetoFalaAI\FalaAI\FalaAI_api\sdks\dotnet\examples\*.cs` | OS 4 EXEMPLOS GERADOS (usam o SDK .NET: `Configuration` + `*Api`) |
| 6 | `README.md` | `D:\ProjetoFalaAI\FalaAI\FalaAI_api\sdks\dotnet\examples\README.md` | manual dos exemplos (**GERADO** pelo exportador v1.4.0 — versao/data) |
| 7 | `demo_callcenter.mp3` | `D:\ProjetoFalaAI\FalaAI\FalaAI_api\sdks\dotnet\tests\e2e\demo_callcenter.mp3` | audio do teste (1.3 MB) |
| 8 | `logs\dotnet_<endpoint>_<ts>_tst.json` (+ `.html`) | `D:\ProjetoFalaAI\FalaAI\FalaAI_api\sdks\dotnet\tests\e2e\logs\` | LOGS gerados pelo runner (**limpa os antigos a cada rodada**) |
| 9 | `VERSION.txt` | `D:\ProjetoFalaAI\FalaAI\FalaAI_api\VERSION.txt` | versao da API que o health devolve (`api_v1.21.49`) — SEM BOM |
| 10 | `_FLUXO_TESTE_SDK_DOTNET.md` (este doc) | `D:\ProjetoFalaAI\FalaAI\FalaAI_api\sdks\dotnet\examples\_FLUXO_TESTE_SDK_DOTNET.md` | este doc |

## Requisitos do dev (inviolaveis)
- R-A: roda em Docker DA LINGUAGEM (`mcr.microsoft.com/dotnet/sdk:8.0`)
- R-B: roda os 4 exemplos GERADOS (`*Example.cs`) — nunca reescreve
- R-C: LOG = request (codigo do exemplo) + response (o objeto do SDK .NET) + `.html` da auditoria
- R-D: chave `fai_668e6474b83dd24540860d9ab9df0b738f7171a0f5bd8179` hardcoded no runner (local-only)
- R-E: **PASSO 0 antes de tudo** — exemplos sincronizados com a FONTE UNICA

## Fluxo (com os nomes reais dos scripts)
```mermaid
flowchart TD
    A["1. run_docker.ps1<br/>sdks/dotnet/tests/e2e/run_docker.ps1"] --> B{"valida csproj + demo_callcenter.mp3"}
    B --> P0["PASSO 0a (HOST): node _generate_dotnet_examples.mjs<br/>(exemplos + README = sandbox-examples.ts)"]
    P0 --> C["2. docker run sdk:8.0<br/>-e FALAAI_API_KEY -e TZ -e FALAAI_BASE_URL<br/>-v sdks/dotnet:/dotnet"]
    C --> D["3. run_examples.sh LIMPA logs antigos<br/>+ dotnet build"]
    D --> E{"para cada endpoint<br/>health / transcribe / diagnostic / auditoria"}
    E --> F["dotnet app.dll<br/>(usa o SDK .NET: Configuration + *Api)"]
    F --> G{"stdout = JSON valido?"}
    G -- "sim" --> H["log: logs/dotnet_<endpoint>_<ts>_tst.json<br/>{language, endpoint, generated_at,<br/>request = codigo C#, response = objeto do SDK}"]
    G -- "nao" --> I["log {response: null, error: stdout}"]
    H --> J{"endpoint = auditoria?"}
    I --> J
    J -- "sim" --> K["unzip html_report (base64+gzip)<br/>grava dotnet_auditoria_<ts>_tst.html"]
    J -- "nao" --> E
    K --> E
    E -- "fim" --> L["TODOS OK (exit 0) / HOUVE FALHA (exit 1)"]
    L --> M["PASSO FINAL: node _sync_sandbox_responses.mjs<br/>(so em sucesso) -> lib/sandbox-responses.ts"]
```

## Comando (API no micro do dev)
```powershell
powershell -ExecutionPolicy Bypass -File "D:\ProjetoFalaAI\FalaAI\FalaAI_api\sdks\dotnet\tests\e2e\run_docker.ps1" -BaseUrl http://host.docker.internal:8002 -Only all
# -Only: all | health | transcribe | diagnostic | auditoria | build
# health = publico (sem creditos) · transcribe/diagnostic/auditoria = consomem creditos da chave FAI
```

## Log (formato — secoes separadas por linha em branco, JSON valido)
```json
{
  "language": "dotnet",
  "endpoint": "health",
  "generated_at": "2026-09-30T17:04:00Z",

  "request": "<codigo do exemplo .cs, linhas escapadas como \n>",

  "response": { "o objeto do SDK .NET serializado — snake_case" }
}
```
Falha: `"response": null, "error": "<stdout/stderr>"` · Auditoria: + `dotnet_auditoria_<ts>_tst.html` (unzip de `html_report`)

## O que garantir
1. O exemplo usa o SDK .NET (`Configuration` + `*Api`) — NUNCA chamada HTTP/curl direta.
2. O request sai do SDK (Bearer fai_...) — a API responde — o SDK devolve — o runner grava o log.
3. PASSO 0 roda ANTES de qualquer teste (exemplos na ultima versao da fonte unica).
4. O runner LIMPA os logs antigos a cada rodada (so os da execucao atual ficam).
5. PASSO FINAL: em sucesso, o wrapper sincroniza `lib/sandbox-responses.ts` (automatico).
6. Refaco a qualquer momento: mesmo comando = mesmo comportamento (deterministico).

## Historico
- **v1.0.0 (30/09 14:04):** doc inicial (padrao 3.1) — wrapper v1.1.0 (PASSO 0a + sync), runner v2.1.0 (log JSON canonico + secoes separadas + limpa logs + `.html`), exportador v1.4.0 (README GERADO).