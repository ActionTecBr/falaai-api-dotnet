# sdks/dotnet/examples - exemplos dotnet (canonicos)

@version 1.5.0 | criado: 15/10/2026 22:20 | atualizado: 18/10/2026 00:21

## O que e
Os 7 exemplos dotnet (.cs) - 4 endpoints + 3 variantes do WhatsApp - EXPORTADOS DA LANDING PAGE (fonte unica
de verdade). Nunca editados a mao.

## Fonte unica de verdade
- FalaAI_landing/lib/sandbox-examples.ts -> SANDBOX_EXAMPLES[<endpoint>].dotnet
- que INTERPOLA FalaAI_landing/lib/sandbox-json-example.ts (SANDBOX_JSON_EXAMPLE = dados reais).

## Script (ferramenta)
_generate_dotnet_examples.mjs (prefixo _ = ferramenta, nao exemplo)

| Comando                                      | Acao                                                      |
|----------------------------------------------|-----------------------------------------------------------|
| node _generate_dotnet_examples.mjs             | Exporta (escreve os .cs a partir da landing + README)     |
| node _generate_dotnet_examples.mjs --check     | Verifica (compara .cs x landing; exit 1 se divergir)      |

- Roda de QUALQUER pasta (resolve a landing pelo proprio caminho).
- Pre-requisito: Node (v22+).
- NUNCA edite os .cs nem este README a mao: edite a landing e reexecute o script.

## Ordem obrigatoria (regra)
1. Altere a FONTE (landing / SANDBOX_JSON_EXAMPLE).
2. Valide o cURL primeiro:  node D:\ProjetoFalaAI\FalaAI\FalaAI_api\sdks\curl\examples\_generate_curl_examples.mjs --check   (exit 0 = ok)
3. So depois espelhe nas outras linguagens.
4. Cadeia integrada no pipeline: scripts/regenerate_all.py (T11) exporta via node.

## Relatorio da ultima execucao
| Data | Modo | Resultado |
|------|------|-----------|
| 18/10/2026 00:21 | exportacao | OK - 7 exemplos dotnet exportados da landing. |

| Arquivo | Endpoint | Status | Gerado em |
|---------|----------|--------|-----------|
| HealthExample.cs | GET  /v1/health | exportado (556 chars) | 18/10/2026 00:21 |
| TranscribeExample.cs | POST /v1/audio/transcriptions | exportado (1208 chars) | 18/10/2026 00:21 |
| DiagnoseExample.cs | POST /v1/analyze/diagnostic | exportado (4783 chars) | 18/10/2026 00:21 |
| AuditExample.cs | POST /v1/analyze/riskAudit | exportado (3574 chars) | 18/10/2026 00:21 |
| whatsapp_preview.cs | POST /v1/whatsapp/extractConversations | exportado (1331 chars) | 18/10/2026 00:21 |
| whatsapp_periodo.cs | POST /v1/whatsapp/extractConversations | exportado (1356 chars) | 18/10/2026 00:21 |
| whatsapp_janelas.cs | POST /v1/whatsapp/extractConversations | exportado (1449 chars) | 18/10/2026 00:21 |

## Datas
- Criacao:     15/10/2026 22:20
- Atualizacao: 18/10/2026 00:21

Gerado automaticamente por _generate_dotnet_examples.mjs - NAO edite a mao.
