# FalaAI.Api.Model.RiskAuditMetaV2

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** | Analysis id | 
**Object** | **string** | Object type | [optional] [default to "risk_audit"]
**CallDurationS** | **decimal?** | Call duration (s) | [optional] 
**AnalyzedAt** | **string** | ISO 8601 analyzed timestamp | [optional] 
**Usage** | [**RiskAuditUsageV2**](RiskAuditUsageV2.md) | Usage block | 
**ClientReferenceId** | **string** | Echoed client reference id | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

