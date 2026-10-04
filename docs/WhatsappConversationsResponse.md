# FalaAI.Api.Model.WhatsappConversationsResponse

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** | Unique identifier. Prefix &#39;wc-&#39; + UUID | 
**Object** | **string** | Object type. Always &#39;conversations&#39; | 
**Usage** | [**WhatsappUsage**](WhatsappUsage.md) | Usage and processing information | 
**Conversations** | [**List&lt;WhatsappConversation&gt;**](WhatsappConversation.md) | Segmented conversations | 
**ClientReferenceId** | **string** | Client-supplied ID echoed verbatim (if provided) | [optional] 
**Meta** | [**WhatsappMeta**](WhatsappMeta.md) | Segmentation parameters and counts | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

