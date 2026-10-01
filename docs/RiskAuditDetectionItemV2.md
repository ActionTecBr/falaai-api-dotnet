# FalaAI.Api.Model.RiskAuditDetectionItemV2

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Turn** | **int?** | Turn number | [optional] 
**Interlocutor** | **string** | Speaker | [optional] 
**Role** | **string** | Role | [optional] 
**TimestampStartS** | **decimal?** | Start (s) | [optional] 
**TimestampEndS** | **decimal?** | End (s) | [optional] 
**TimestampFormatted** | **string** | Formatted timestamp | [optional] 
**TermText** | **string** | Detected term | [optional] 
**SuggestedTermForBank** | **Object** | Suggested term for bank | [optional] 
**Category** | **string** | Category code | [optional] 
**CategoryLabel** | **string** | Category label (i18n) | 
**CategoryColor** | **string** | Category color | [optional] 
**CategoryIcon** | **string** | Category icon | [optional] 
**Criticality** | **string** | Criticality | [optional] 
**CategoryThreshold** | **decimal?** | Category threshold | [optional] 
**CategoryType** | **string** | Category type | [optional] 
**CategoryGroup** | **string** | Category group label (i18n) | 
**Nature** | **string** | Nature | [optional] 
**LlmConfidence** | **decimal?** | LLM confidence | [optional] 
**Reason** | **string** | Reason | [optional] 
**IsValidContext** | **bool?** | Valid context | [optional] 
**RiskProbability** | **decimal?** | Risk probability | [optional] 
**RiskImpact** | **decimal?** | Risk impact | [optional] 
**CategoryWeight** | **decimal?** | Category weight | [optional] 
**TurnSentiment** | **string** | Turn sentiment | [optional] 
**Intensity** | **Object** | Intensity | [optional] 
**ModApplied** | **decimal?** | Total modifier applied | [optional] 
**MacApplied** | **decimal?** | Audio modifier applied | [optional] 
**MvadApplied** | **decimal?** | Intensity modifier applied | [optional] 
**ModFormula** | **string** | Modifier formula | [optional] 
**MacDetails** | **List&lt;Dictionary&lt;string, Object&gt;&gt;** | MAC details | [optional] 
**CalibrationReason** | **string** | Calibration reason | [optional] 
**FinalScore** | **decimal?** | Final score | [optional] 
**FinalScoreFormula** | **string** | Final score formula | [optional] 
**ConversationLimit** | **Object** | Conversation limit | [optional] 
**ApplySaturation** | **bool?** | Apply saturation | [optional] 
**BlockRepetition** | **bool?** | Block repetition | [optional] 
**Status** | **string** | Status | [optional] 
**EffectiveImpact** | **decimal?** | Effective impact | [optional] 
**SaturationFactor** | **decimal?** | Saturation factor | [optional] 
**SaturationFormula** | **string** | Saturation formula | [optional] 
**ThresholdFormula** | **string** | Threshold formula | [optional] 
**BlockedFormula** | **string** | Blocked formula | [optional] 
**ReconciliationNote** | **string** | Reconciliation note | [optional] 
**ViolatedFrameworks** | **List&lt;Object&gt;** | Violated frameworks | [optional] 
**CitationFidelity** | **bool** | Citation fidelity | [optional] [default to true]
**Subcategory** | **string** | Subcategory code | [optional] 
**SubcategoryLabel** | **string** | Subcategory label (i18n) | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

