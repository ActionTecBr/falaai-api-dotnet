# FalaAI.Api.Model.WhatsappUsage

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Conversations** | **int** | Number of conversations returned | 
**Characters** | **int** | Total characters across conversations | 
**Expressions** | **int** | Expression tokens across conversations (sticker/emoji/gif) | 
**VoiceNotes** | **int** | Voice notes (PTT) resolved to text | 
**ConversationCredits** | **int** | Credits for conversations (2 each) | 
**ExpressionCredits** | **decimal** | Credits for expressions (0.2 each) | 
**AudioCredits** | **decimal** | Credits for audio duration (0.2 per second) | 
**CreditsConsumed** | **int** | Total credits &#x3D; ceil(conversation_credits + expression_credits + audio_credits) | 
**ProcessingMs** | **int** | Total processing time in milliseconds | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

