# FalaAI.Api.Model.DiagnosticResponse

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** | Unique analysis identifier. Prefix &#39;di-&#39; + UUID | 
**ResponseLanguage** | **string** | Language used in the response. E.g.: &#39;pt-BR&#39;, &#39;en-US&#39;, &#39;es-ES&#39; | 
**Object** | **string** | Object type. Always &#39;analysis&#39; | 
**Analysis** | [**DiagnosticAnalysisMap**](DiagnosticAnalysisMap.md) | The 6 conversation analyses (5 + participants) | 
**Usage** | [**DiagnosticUsage**](DiagnosticUsage.md) | Usage and processing information | 
**ClientReferenceId** | **string** | Client-supplied ID echoed verbatim (if provided in request) | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

