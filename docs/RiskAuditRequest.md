# FalaAI.Api.Model.RiskAuditRequest

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Model** | **string** | Analysis model. Always &#39;falaai-risk-audit-1&#39; | [optional] [default to "falaai-risk-audit-1"]
**Text** | **string** | Plain transcript (fallback if dialog is empty). At least one of &#39;dialog&#39; or &#39;text&#39; required. Max 300,000 characters | [optional] [default to ""]
**Dialog** | **string** | Diarized transcript with speaker turns. PRIMARY source. Speaker labels accepted (any case): &#39;Speaker N&#39;, &#39;Interlocutor N&#39;, &#39;Hablante N&#39;, &#39;Locutor N&#39;, &#39;Orador N&#39; (space or underscore). Normalized internally to &#39;Speaker N&#39; in the response. Max 300,000 characters | [optional] [default to ""]
**AudioEvents** | [**List&lt;DiagnosticAudioEvent&gt;**](DiagnosticAudioEvent.md) | Audio events with timestamps (correlated with turns when diarization is present) | [optional] 
**DurationSeconds** | **decimal** | Total audio duration in seconds. Required. Max 3h (10800s). | 
**Language** | **string** | Language of the transcript being analyzed. Must match the dialog/text language. Accepted: pt-BR, en-US, es-ES. | 
**ResponseLanguage** | **string** | Language for analysis results (labels, categories, levels, actions, HTML report). Can differ from &#39;language&#39;. Accepted: pt-BR, en-US, es-ES. | 
**CallDirection** | **string** | Who originated the call. inbound&#x3D;client called, outbound&#x3D;company called. If omitted, LLM infers from context. | [optional] 
**Participants** | [**List&lt;Participant&gt;**](Participant.md) | Explicit participant roles. If omitted, LLM infers from dialog (Lei 17). When provided, used as ground truth — no inference. | [optional] 
**ResponseFormat** | **string** | Response format version. Only &#39;v2&#39; (structured EN-US blocks) is available today. | [optional] [default to ResponseFormatEnum.V2]
**ClientReferenceId** | **string** | Optional client-supplied ID echoed verbatim in the response. Use to correlate/sync with your system. Accepted charset: [A-Za-z0-9._:-], max 128 chars. Not idempotency. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

