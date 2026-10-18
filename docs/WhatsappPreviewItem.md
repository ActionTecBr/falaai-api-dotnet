# FalaAI.Api.Model.WhatsappPreviewItem

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ConversationId** | **string** | Stable id: yyyymmddhhmm-&lt;first speaker&gt;[-xN for &gt;2 speakers] | 
**FirstAt** | **string** | Conversation start (ISO) | 
**LastAt** | **string** | Conversation end (ISO) | 
**DurationMinutes** | **decimal** | Conversation duration in minutes | 
**Messages** | **int** | Messages in this conversation | 
**Characters** | **int** | Characters of this conversation (estimate: media text is only replaced by tokens on extraction) | 
**Media** | [**WhatsappPreviewItemMedia**](WhatsappPreviewItemMedia.md) | Media of this conversation | 
**Credits** | [**WhatsappPreviewItemCredits**](WhatsappPreviewItemCredits.md) | Credits of this conversation | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

