# FalaAI.Api.Api.EmailAlertsApi

All URIs are relative to *https://api01-falaai.action.tec.br*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateEmailAlertV1EmailAlertsPost**](EmailAlertsApi.md#createemailalertv1emailalertspost) | **POST** /v1/email-alerts | Create email alert |
| [**DeleteEmailAlertV1EmailAlertsAlertIdDelete**](EmailAlertsApi.md#deleteemailalertv1emailalertsalertiddelete) | **DELETE** /v1/email-alerts/{alert_id} | Delete email alert |
| [**ListEmailAlertsV1EmailAlertsGet**](EmailAlertsApi.md#listemailalertsv1emailalertsget) | **GET** /v1/email-alerts | List email alerts |
| [**UpdateEmailAlertV1EmailAlertsAlertIdPut**](EmailAlertsApi.md#updateemailalertv1emailalertsalertidput) | **PUT** /v1/email-alerts/{alert_id} | Update email alert |

<a id="createemailalertv1emailalertspost"></a>
# **CreateEmailAlertV1EmailAlertsPost**
> EmailAlertItem CreateEmailAlertV1EmailAlertsPost (CreateEmailAlertRequest createEmailAlertRequest)

Create email alert

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
    public class CreateEmailAlertV1EmailAlertsPostExample
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
            var apiInstance = new EmailAlertsApi(httpClient, config, httpClientHandler);
            var createEmailAlertRequest = new CreateEmailAlertRequest(); // CreateEmailAlertRequest | 

            try
            {
                // Create email alert
                EmailAlertItem result = apiInstance.CreateEmailAlertV1EmailAlertsPost(createEmailAlertRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling EmailAlertsApi.CreateEmailAlertV1EmailAlertsPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreateEmailAlertV1EmailAlertsPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create email alert
    ApiResponse<EmailAlertItem> response = apiInstance.CreateEmailAlertV1EmailAlertsPostWithHttpInfo(createEmailAlertRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling EmailAlertsApi.CreateEmailAlertV1EmailAlertsPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **createEmailAlertRequest** | [**CreateEmailAlertRequest**](CreateEmailAlertRequest.md) |  |  |

### Return type

[**EmailAlertItem**](EmailAlertItem.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="deleteemailalertv1emailalertsalertiddelete"></a>
# **DeleteEmailAlertV1EmailAlertsAlertIdDelete**
> EmailAlertMessageResponse DeleteEmailAlertV1EmailAlertsAlertIdDelete (string alertId)

Delete email alert

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
    public class DeleteEmailAlertV1EmailAlertsAlertIdDeleteExample
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
            var apiInstance = new EmailAlertsApi(httpClient, config, httpClientHandler);
            var alertId = "alertId_example";  // string | 

            try
            {
                // Delete email alert
                EmailAlertMessageResponse result = apiInstance.DeleteEmailAlertV1EmailAlertsAlertIdDelete(alertId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling EmailAlertsApi.DeleteEmailAlertV1EmailAlertsAlertIdDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteEmailAlertV1EmailAlertsAlertIdDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete email alert
    ApiResponse<EmailAlertMessageResponse> response = apiInstance.DeleteEmailAlertV1EmailAlertsAlertIdDeleteWithHttpInfo(alertId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling EmailAlertsApi.DeleteEmailAlertV1EmailAlertsAlertIdDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **alertId** | **string** |  |  |

### Return type

[**EmailAlertMessageResponse**](EmailAlertMessageResponse.md)

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

<a id="listemailalertsv1emailalertsget"></a>
# **ListEmailAlertsV1EmailAlertsGet**
> EmailAlertListResponse ListEmailAlertsV1EmailAlertsGet (int? page = null, int? limit = null)

List email alerts

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
    public class ListEmailAlertsV1EmailAlertsGetExample
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
            var apiInstance = new EmailAlertsApi(httpClient, config, httpClientHandler);
            var page = 1;  // int? |  (optional)  (default to 1)
            var limit = 20;  // int? |  (optional)  (default to 20)

            try
            {
                // List email alerts
                EmailAlertListResponse result = apiInstance.ListEmailAlertsV1EmailAlertsGet(page, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling EmailAlertsApi.ListEmailAlertsV1EmailAlertsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListEmailAlertsV1EmailAlertsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List email alerts
    ApiResponse<EmailAlertListResponse> response = apiInstance.ListEmailAlertsV1EmailAlertsGetWithHttpInfo(page, limit);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling EmailAlertsApi.ListEmailAlertsV1EmailAlertsGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **page** | **int?** |  | [optional] [default to 1] |
| **limit** | **int?** |  | [optional] [default to 20] |

### Return type

[**EmailAlertListResponse**](EmailAlertListResponse.md)

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

<a id="updateemailalertv1emailalertsalertidput"></a>
# **UpdateEmailAlertV1EmailAlertsAlertIdPut**
> EmailAlertMessageResponse UpdateEmailAlertV1EmailAlertsAlertIdPut (string alertId, UpdateEmailAlertRequest updateEmailAlertRequest)

Update email alert

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
    public class UpdateEmailAlertV1EmailAlertsAlertIdPutExample
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
            var apiInstance = new EmailAlertsApi(httpClient, config, httpClientHandler);
            var alertId = "alertId_example";  // string | 
            var updateEmailAlertRequest = new UpdateEmailAlertRequest(); // UpdateEmailAlertRequest | 

            try
            {
                // Update email alert
                EmailAlertMessageResponse result = apiInstance.UpdateEmailAlertV1EmailAlertsAlertIdPut(alertId, updateEmailAlertRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling EmailAlertsApi.UpdateEmailAlertV1EmailAlertsAlertIdPut: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdateEmailAlertV1EmailAlertsAlertIdPutWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update email alert
    ApiResponse<EmailAlertMessageResponse> response = apiInstance.UpdateEmailAlertV1EmailAlertsAlertIdPutWithHttpInfo(alertId, updateEmailAlertRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling EmailAlertsApi.UpdateEmailAlertV1EmailAlertsAlertIdPutWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **alertId** | **string** |  |  |
| **updateEmailAlertRequest** | [**UpdateEmailAlertRequest**](UpdateEmailAlertRequest.md) |  |  |

### Return type

[**EmailAlertMessageResponse**](EmailAlertMessageResponse.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

