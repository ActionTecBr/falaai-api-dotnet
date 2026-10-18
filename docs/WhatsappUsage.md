# FalaAI.Api.Model.WhatsappUsage

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Conversations** | **int** | Number of conversations returned | 
**Characters** | **int** | Total characters across conversations | 
**Expressions** | **int** | Chargeable expression occurrences (figurinha+GIF+emoji); 0 quando expression&#x3D;false | 
**ExpressionsFigurinha** | **int** | Figurinha occurrences (cobra 0,15 cada quando expression&#x3D;true) | 
**ExpressionsGif** | **int** | GIF occurrences (cobra 0,18 cada quando expression&#x3D;true) | 
**ExpressionsEmoji** | **int** | Emoji occurrences (cobra 0,1 cada quando expression&#x3D;true) | 
**VoiceNotes** | **int** | Voice notes (PTT) resolved to text | 
**ConversationCredits** | **decimal** | Credits for conversations (0,15 each) | 
**ExpressionCredits** | **decimal** | Credits for expressions (figurinha 0,15 / GIF 0,18 / emoji 0,1) | 
**AudioCredits** | **decimal** | Credits for transcribed voice seconds (0,19 per second; 0 quando voice_note&#x3D;false) | 
**CreditsConsumed** | **decimal** | Total credits &#x3D; round(conversation_credits + expression_credits + audio_credits, 2) | 
**ProcessingMs** | **int** | Total processing time in milliseconds | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

