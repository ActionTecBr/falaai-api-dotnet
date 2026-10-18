# FalaAI.Api.Model.WhatsappPreviewResponse

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Object** | **string** | Object type. Always &#39;whatsapp_preview&#39; | 
**DryRun** | **bool** | Always true (preview: no AI call, no charge) | 
**CreditsCharged** | **int** | Always 0 in preview | 
**CreditsTotal** | **decimal** | TOTAL credits &#x3D; exact SUM of the selected conversations (2 decimals, NO rounding up) | 
**Params** | [**WhatsappPreviewParams**](WhatsappPreviewParams.md) | Filter parameters actually used (reuse them in the extraction) | 
**Windows** | [**List&lt;WhatsappPreviewWindow&gt;**](WhatsappPreviewWindow.md) | Explicit windows used (empty when a single start/end range was used) | 
**Items** | [**List&lt;WhatsappPreviewItem&gt;**](WhatsappPreviewItem.md) | Per-conversation detail (send back as &#x60;windows&#x60; to extract only what you want) | 
**Warnings** | **List&lt;string&gt;** | Human-readable notices about what would be ignored | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

