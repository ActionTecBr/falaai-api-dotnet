# FalaAI.Api.Api.WhatsappApi

All URIs are relative to *https://api01-falaai.action.tec.br*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ExtractConversationsV1WhatsappExtractConversationsPost**](WhatsappApi.md#extractconversationsv1whatsappextractconversationspost) | **POST** /v1/whatsapp/extractConversations | Extract and segment WhatsApp conversations from an export |

<a id="extractconversationsv1whatsappextractconversationspost"></a>
# **ExtractConversationsV1WhatsappExtractConversationsPost**
> WhatsappConversationsResponse ExtractConversationsV1WhatsappExtractConversationsPost (FileParameter file, string start, string end, string timezone, string dateFormat, decimal? gapMinutes = null, int? minMessages = null, decimal? charsPerMinute = null, string? clientReferenceId = null)

Extract and segment WhatsApp conversations from an export

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
            var start = "start_example";  // string | 
            var end = "end_example";  // string | 
            var timezone = "timezone_example";  // string | 
            var dateFormat = "dateFormat_example";  // string | 
            var gapMinutes = 720MD;  // decimal? |  (optional)  (default to 720M)
            var minMessages = 2;  // int? |  (optional)  (default to 2)
            var charsPerMinute = 800MD;  // decimal? |  (optional)  (default to 800M)
            var clientReferenceId = "clientReferenceId_example";  // string? |  (optional) 

            try
            {
                // Extract and segment WhatsApp conversations from an export
                WhatsappConversationsResponse result = apiInstance.ExtractConversationsV1WhatsappExtractConversationsPost(file, start, end, timezone, dateFormat, gapMinutes, minMessages, charsPerMinute, clientReferenceId);
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
    ApiResponse<WhatsappConversationsResponse> response = apiInstance.ExtractConversationsV1WhatsappExtractConversationsPostWithHttpInfo(file, start, end, timezone, dateFormat, gapMinutes, minMessages, charsPerMinute, clientReferenceId);
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
| **start** | **string** |  |  |
| **end** | **string** |  |  |
| **timezone** | **string** |  |  |
| **dateFormat** | **string** |  |  |
| **gapMinutes** | **decimal?** |  | [optional] [default to 720M] |
| **minMessages** | **int?** |  | [optional] [default to 2] |
| **charsPerMinute** | **decimal?** |  | [optional] [default to 800M] |
| **clientReferenceId** | **string?** |  | [optional]  |

### Return type

[**WhatsappConversationsResponse**](WhatsappConversationsResponse.md)

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

