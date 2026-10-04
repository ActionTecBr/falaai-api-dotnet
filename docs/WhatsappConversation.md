# FalaAI.Api.Model.WhatsappConversation

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ConversationId** | **string** | Conversation identifier in the batch | 
**FirstAt** | **string** | Real start (wall-clock, ISO) | 
**LastAt** | **string** | Real end (wall-clock, ISO) | 
**DurationSeconds** | **decimal** | (last - first) + last turn duration | 
**Speakers** | [**List&lt;WhatsappSpeaker&gt;**](WhatsappSpeaker.md) | Speakers of THIS conversation (dynamic) | 
**Dialog** | **string** | Lines &#39;Speaker N: [HH:MM:SS.mmm - HH:MM:SS.mmm] text&#39; (real offset) | 
**MessageCount** | **int** | Number of messages | 
**Characters** | **int** | Total characters of the conversation | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

