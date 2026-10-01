# FalaAI.Api.Api.UsageApi

All URIs are relative to *https://api01-falaai.action.tec.br*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetUsageByKeyV1UsageByKeyGet**](UsageApi.md#getusagebykeyv1usagebykeyget) | **GET** /v1/usage/by-key | Get Usage By Key |
| [**GetUsageLogV1UsageLogGet**](UsageApi.md#getusagelogv1usagelogget) | **GET** /v1/usage/log | Get Usage Log |

<a id="getusagebykeyv1usagebykeyget"></a>
# **GetUsageByKeyV1UsageByKeyGet**
> List&lt;UsageByKeyItem&gt; GetUsageByKeyV1UsageByKeyGet (string? keyId = null)

Get Usage By Key

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
    public class GetUsageByKeyV1UsageByKeyGetExample
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
            var apiInstance = new UsageApi(httpClient, config, httpClientHandler);
            var keyId = "keyId_example";  // string? |  (optional) 

            try
            {
                // Get Usage By Key
                List<UsageByKeyItem> result = apiInstance.GetUsageByKeyV1UsageByKeyGet(keyId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UsageApi.GetUsageByKeyV1UsageByKeyGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetUsageByKeyV1UsageByKeyGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get Usage By Key
    ApiResponse<List<UsageByKeyItem>> response = apiInstance.GetUsageByKeyV1UsageByKeyGetWithHttpInfo(keyId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UsageApi.GetUsageByKeyV1UsageByKeyGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **keyId** | **string?** |  | [optional]  |

### Return type

[**List&lt;UsageByKeyItem&gt;**](UsageByKeyItem.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getusagelogv1usagelogget"></a>
# **GetUsageLogV1UsageLogGet**
> UsageLogResponse GetUsageLogV1UsageLogGet (int? page = null, int? limit = null, string? apiKeyId = null)

Get Usage Log

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
    public class GetUsageLogV1UsageLogGetExample
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
            var apiInstance = new UsageApi(httpClient, config, httpClientHandler);
            var page = 1;  // int? |  (optional)  (default to 1)
            var limit = 20;  // int? |  (optional)  (default to 20)
            var apiKeyId = "apiKeyId_example";  // string? |  (optional) 

            try
            {
                // Get Usage Log
                UsageLogResponse result = apiInstance.GetUsageLogV1UsageLogGet(page, limit, apiKeyId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UsageApi.GetUsageLogV1UsageLogGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetUsageLogV1UsageLogGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get Usage Log
    ApiResponse<UsageLogResponse> response = apiInstance.GetUsageLogV1UsageLogGetWithHttpInfo(page, limit, apiKeyId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UsageApi.GetUsageLogV1UsageLogGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **page** | **int?** |  | [optional] [default to 1] |
| **limit** | **int?** |  | [optional] [default to 20] |
| **apiKeyId** | **string?** |  | [optional]  |

### Return type

[**UsageLogResponse**](UsageLogResponse.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

