# FalaAI.Api.Api.WhatsappApi

All URIs are relative to *https://api01-falaai.action.tec.br*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ExtractConversationsV1WhatsappExtractConversationsPost**](WhatsappApi.md#extractconversationsv1whatsappextractconversationspost) | **POST** /v1/whatsapp/extractConversations | Extract and segment WhatsApp conversations from an export |

<a id="extractconversationsv1whatsappextractconversationspost"></a>
# **ExtractConversationsV1WhatsappExtractConversationsPost**
> ResponseExtractConversationsV1WhatsappExtractconversationsPost ExtractConversationsV1WhatsappExtractConversationsPost (FileParameter file, string timezone, string dateFormat, string? start = null, string? end = null, string? windows = null, decimal? gapMinutes = null, int? minMessages = null, bool? voiceNote = null, bool? expression = null, bool? dryRun = null, string? clientReferenceId = null)

Extract and segment WhatsApp conversations from an export

Extracts and segments the conversations of a WhatsApp export (.zip or .txt containing chat.txt in UTF-8 with at least one turn) and, unless it is a preview, resolves each selected conversation with AI by transcribing voice/audio/video notes and describing visual expressions, returning the segmented conversations with speakers, dialogs, counts and usage. Use dry_run=true for a PREVIEW: it validates the file, segments the conversations, counts media and ESTIMATES the credits WITHOUT calling the AI and WITHOUT charging (credits_charged=0), returning object whatsapp_preview with credits_total, the params actually used, the windows, per-conversation items and warnings. The window is given either as a single start/end pair or as windows, a JSON string holding a non-empty list of sub-objects each with start and end; windows must not be combined with start/end, and a windows selection is the deduplicated chronological union of the overlaps, which bypasses the noise filter and keeps conversations that are monologues or below min_messages, while for a single window sending only one of start/end is rejected and empty/all-zeros values select the real period of the export, both being allowed to be omitted in dry_run while outside dry_run both absent is rejected. timezone and date_format are required, where date_format must be day_first, month_first or year_first. gap_minutes is optional (default 720) and splits conversations on idle gaps, min_messages is optional (default 2) and is the minimum messages kept per conversation outside the explicit windows selection, voice_note is optional (default true) and turns voice/audio/video media into text, expression is optional (default true) and describes visual expressions (figurinha, GIF, emoji), and client_reference_id is optional, echoed verbatim, charset A-Za-z0-9 space _/:.- up to 60 chars. Billing outside the preview is 0.15 credit per conversation plus 0.15 per figurinha, 0.18 per GIF and 0.1 per emoji (only with expression=true) plus 0.19 per second of voice/audio/video (only with voice_note=true), rounded to 2 decimals with no rounding up, and the preview credits_total is the same exact sum with 2 decimals; files are limited to 1GB and the endpoint is stateless (export and media processed in memory, temporary files removed, nothing persisted), returning object conversations with id (wc-), usage and the conversations (conversation_id, first_at, last_at, duration_seconds, speakers, dialog, message_count, characters) plus meta.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using FalaAI.Api.Api;
using FalaAI.Api.Client;
using FalaAI.Api.Model;

namespace Example
{
    public class ExtractConversationsV1WhatsappExtractConversationsPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api01-falaai.action.tec.br";
            // Configure Bearer token for authorization: ApiKeyAuth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new WhatsappApi(httpClient, config, httpClientHandler);
            var file = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // FileParameter | 
            var timezone = "timezone_example";  // string | 
            var dateFormat = "dateFormat_example";  // string | 
            var start = "start_example";  // string? | Inicio da janela. Obrigatorio fora do dry_run; no dry_run ausente = primeiro turno do export. (optional) 
            var end = "end_example";  // string? | Fim da janela. Obrigatorio fora do dry_run; no dry_run ausente = ultimo turno do export. (optional) 
            var windows = "windows_example";  // string? | Selecao explicita por varias janelas: JSON [{\\\"start\\\":\\\"...\\\",\\\"end\\\":\\\"...\\\"}]. Nao combinar com 'start'/'end'. (optional) 
            var gapMinutes = 720MD;  // decimal? |  (optional)  (default to 720M)
            var minMessages = 2;  // int? |  (optional)  (default to 2)
            var voiceNote = true;  // bool? | Transcrever mensagens de voz/video gravadas na hora? (optional)  (default to true)
            var expression = true;  // bool? | Descrever expressoes visuais (figurinha/GIF/imagem)? (optional)  (default to true)
            var dryRun = false;  // bool? | So analisa o arquivo: valida, segmenta e ESTIMA os creditos SEM chamar a IA e SEM debitar (credits_charged=0). (optional)  (default to false)
            var clientReferenceId = "clientReferenceId_example";  // string? |  (optional) 

            try
            {
                // Extract and segment WhatsApp conversations from an export
                ResponseExtractConversationsV1WhatsappExtractconversationsPost result = apiInstance.ExtractConversationsV1WhatsappExtractConversationsPost(file, timezone, dateFormat, start, end, windows, gapMinutes, minMessages, voiceNote, expression, dryRun, clientReferenceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WhatsappApi.ExtractConversationsV1WhatsappExtractConversationsPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ExtractConversationsV1WhatsappExtractConversationsPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Extract and segment WhatsApp conversations from an export
    ApiResponse<ResponseExtractConversationsV1WhatsappExtractconversationsPost> response = apiInstance.ExtractConversationsV1WhatsappExtractConversationsPostWithHttpInfo(file, timezone, dateFormat, start, end, windows, gapMinutes, minMessages, voiceNote, expression, dryRun, clientReferenceId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WhatsappApi.ExtractConversationsV1WhatsappExtractConversationsPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **file** | **FileParameter****FileParameter** |  |  |
| **timezone** | **string** |  |  |
| **dateFormat** | **string** |  |  |
| **start** | **string?** | Inicio da janela. Obrigatorio fora do dry_run; no dry_run ausente &#x3D; primeiro turno do export. | [optional]  |
| **end** | **string?** | Fim da janela. Obrigatorio fora do dry_run; no dry_run ausente &#x3D; ultimo turno do export. | [optional]  |
| **windows** | **string?** | Selecao explicita por varias janelas: JSON [{\\\&quot;start\\\&quot;:\\\&quot;...\\\&quot;,\\\&quot;end\\\&quot;:\\\&quot;...\\\&quot;}]. Nao combinar com &#39;start&#39;/&#39;end&#39;. | [optional]  |
| **gapMinutes** | **decimal?** |  | [optional] [default to 720M] |
| **minMessages** | **int?** |  | [optional] [default to 2] |
| **voiceNote** | **bool?** | Transcrever mensagens de voz/video gravadas na hora? | [optional] [default to true] |
| **expression** | **bool?** | Descrever expressoes visuais (figurinha/GIF/imagem)? | [optional] [default to true] |
| **dryRun** | **bool?** | So analisa o arquivo: valida, segmenta e ESTIMA os creditos SEM chamar a IA e SEM debitar (credits_charged&#x3D;0). | [optional] [default to false] |
| **clientReferenceId** | **string?** |  | [optional]  |

### Return type

[**ResponseExtractConversationsV1WhatsappExtractconversationsPost**](ResponseExtractConversationsV1WhatsappExtractconversationsPost.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

