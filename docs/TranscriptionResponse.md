# FalaAI.Api.Model.TranscriptionResponse

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** | Unique transcription identifier. Prefix &#39;tr-&#39; followed by UUID | 
**Object** | **string** | Returned object type. Always &#39;transcription&#39; | 
**Model** | **string** | Model used for transcription. Ex: &#39;falaai-transcribe-1&#39; | 
**Filename** | **string** | Original audio file name uploaded | 
**ProcessedAt** | **string** | Processing datetime in ISO 8601 UTC format | 
**Usage** | [**TranscriptionUsage**](TranscriptionUsage.md) | Usage and processing information | 
**Language** | **string** | ISO 639-3 language code detected in audio. Ex: &#39;por&#39; (Portuguese), &#39;eng&#39; (English), &#39;spa&#39; (Spanish) | 
**LanguageConfidence** | **decimal?** | Language detection confidence level (0.0 to 1.0). Higher is more reliable | [optional] 
**DurationSeconds** | **decimal** | Total audio duration in seconds | 
**Text** | **string** | Full transcription as plain text, including audio events in brackets | 
**Dialog** | **string** | Turn-by-turn formatted transcript with speaker identification and start/end timestamps | 
**AudioEvents** | [**List&lt;AudioEvent&gt;**](AudioEvent.md) | List of detected audio events (laughs, sighs, pauses, etc) with timestamps and duration | 
**EventTypes** | **List&lt;string&gt;** | Unique audio event types found in transcription, alphabetically sorted | 
**WordCount** | **int** | Total number of recognized words in transcription | 
**Input** | [**AudioInputMeta**](AudioInputMeta.md) | Metadados do arquivo de audio enviado (duracao, formato, codec, sample rate, canais) | 
**ClientReferenceId** | **string** | Client-supplied ID echoed verbatim (if provided in request) | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

