# FalaAI.Api.Model.RiskAuditV2
Response V2 (build_public_response_v2) — blocos logicos EN-US. Fonte: response_builder.py.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Meta** | [**RiskAuditMetaV2**](RiskAuditMetaV2.md) | Identification + usage | 
**Participants** | [**RiskAuditParticipantsV2**](RiskAuditParticipantsV2.md) | Participants/roles/direction | 
**Verdict** | [**RiskAuditVerdictV2**](RiskAuditVerdictV2.md) | Verdict + level + applied actions | 
**Scores** | [**RiskAuditScoresV2**](RiskAuditScoresV2.md) | Consolidated + per-participant scores | 
**Detections** | [**RiskAuditDetectionsV2**](RiskAuditDetectionsV2.md) | violations/positives/client alerts | 
**Analysis** | [**RiskAuditAnalysisV2**](RiskAuditAnalysisV2.md) | global_metrics + final_analysis + frameworks | 
**Timeline** | [**RiskAuditTimelineV2**](RiskAuditTimelineV2.md) | turns_sentiment + audio_events + groups | 
**AudioEventModel** | [**RiskAuditAudioEventModelV2**](RiskAuditAudioEventModelV2.md) | MAC audio event semantics | 
**CategoriesSummary** | **Dictionary&lt;string, Object&gt;** | Per-category summary (keyed by category) | 
**Indexer** | [**RiskAuditIndexerV2**](RiskAuditIndexerV2.md) | Suggested terms for bank | 
**Summary** | [**RiskAuditSummaryV2**](RiskAuditSummaryV2.md) | Executive summary counts | 
**ActionsI18n** | **Dictionary&lt;string, Object&gt;** | Used actions i18n catalog (keyed by action) | 
**AuditDecisions** | [**RiskAuditAuditDecisionsV2**](RiskAuditAuditDecisionsV2.md) | Risk origin + validator changes | 
**ScoringExplanation** | [**RiskAuditScoringExplanationV2**](RiskAuditScoringExplanationV2.md) | Score composition explanation | 
**HtmlReport** | **string** | HTML report (base64 gzip) | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

