# FalaAI.Api.Model.WhatsappPreviewItemMedia

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Figurinha** | **int** | Figurinha occurrences in this conversation (0 quando expression&#x3D;false) | 
**Gif** | **int** | GIF occurrences in this conversation (0 quando expression&#x3D;false) | 
**Emoji** | **int** | Emoji occurrences in this conversation (0 quando expression&#x3D;false) | 
**Ptt** | **int** | Voice/audio/video turns in this conversation (cobra 0,19/segundo SO quando voice_note&#x3D;true) | 
**PttSeconds** | **decimal** | Voice/video SECONDS counted in this conversation (0 quando voice_note&#x3D;false) | 
**Anexos** | **int** | Image/document turns in this conversation (ANEXO: nunca cobrado) | 
**ByType** | **Dictionary&lt;string, int&gt;** | Media turns by type in THIS conversation (voz/audio/video/imagem/figurinha/gif/arquivo/oculta/chamada) | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

