# FalaAI.Api.Model.WhatsappMeta

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**File** | **string** | Uploaded file name | 
**ChatTxt** | **string** | chat.txt entry name inside the export | 
**Format** | **string** | Detected format: Android | iOS | 
**DateFormat** | **string** | Date order used | 
**Timezone** | **string** | Timezone informed | 
**Start** | **string** | Window start (ISO) | 
**End** | **string** | Window end (ISO) | 
**GapMinutes** | **decimal** | Gap used to split conversations | 
**MinMessages** | **int** | Minimum messages per conversation | 
**CharsPerMinute** | **decimal** | Chars per minute used to estimate duration | 
**Turns** | **int** | Total parsed turns | 
**SystemLines** | **int** | System lines ignored | 
**ConversationsTotal** | **int** | Conversations before window filter | 
**ConversationsInWindow** | **int** | Conversations overlapping the window | 
**MonologuesDropped** | **int** | Single-speaker conversations dropped | 
**ConversationsSelected** | **int** | Final conversations returned | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

