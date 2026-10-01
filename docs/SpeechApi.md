# FalaAI.Api.Api.SpeechApi

All URIs are relative to *https://api01-falaai.action.tec.br*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateTranscriptionV1AudioTranscriptionsPost**](SpeechApi.md#createtranscriptionv1audiotranscriptionspost) | **POST** /v1/audio/transcriptions | Transcribe audio to text |

<a id="createtranscriptionv1audiotranscriptionspost"></a>
# **CreateTranscriptionV1AudioTranscriptionsPost**
> TranscriptionResponse CreateTranscriptionV1AudioTranscriptionsPost (FileParameter file, string? model = null, string? language = null, string? clientReferenceId = null)

Transcribe audio to text

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
    public class CreateTranscriptionV1AudioTranscriptionsPostExample
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
            var apiInstance = new SpeechApi(httpClient, config, httpClientHandler);
            var file = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // FileParameter | 
            var model = "\"falaai-transcribe-1\"";  // string? |  (optional)  (default to "falaai-transcribe-1")
            var language = "\"pt\"";  // string? |  (optional)  (default to "pt")
            var clientReferenceId = "clientReferenceId_example";  // string? | Optional client-supplied ID echoed verbatim in the response. Use to correlate/sync with your system. Accepted charset: [A-Za-z0-9._:-]. Not idempotency. (optional) 

            try
            {
                // Transcribe audio to text
                TranscriptionResponse result = apiInstance.CreateTranscriptionV1AudioTranscriptionsPost(file, model, language, clientReferenceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SpeechApi.CreateTranscriptionV1AudioTranscriptionsPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreateTranscriptionV1AudioTranscriptionsPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Transcribe audio to text
    ApiResponse<TranscriptionResponse> response = apiInstance.CreateTranscriptionV1AudioTranscriptionsPostWithHttpInfo(file, model, language, clientReferenceId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SpeechApi.CreateTranscriptionV1AudioTranscriptionsPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **file** | **FileParameter****FileParameter** |  |  |
| **model** | **string?** |  | [optional] [default to &quot;falaai-transcribe-1&quot;] |
| **language** | **string?** |  | [optional] [default to &quot;pt&quot;] |
| **clientReferenceId** | **string?** | Optional client-supplied ID echoed verbatim in the response. Use to correlate/sync with your system. Accepted charset: [A-Za-z0-9._:-]. Not idempotency. | [optional]  |

### Return type

[**TranscriptionResponse**](TranscriptionResponse.md)

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

