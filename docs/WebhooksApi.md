# FalaAI.Api.Api.WebhooksApi

All URIs are relative to *https://api01-falaai.action.tec.br*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateWebhookV1WebhooksPost**](WebhooksApi.md#createwebhookv1webhookspost) | **POST** /v1/webhooks | Create webhook |
| [**DeleteWebhookV1WebhooksWebhookIdDelete**](WebhooksApi.md#deletewebhookv1webhookswebhookiddelete) | **DELETE** /v1/webhooks/{webhook_id} | Delete webhook |
| [**ListWebhooksV1WebhooksGet**](WebhooksApi.md#listwebhooksv1webhooksget) | **GET** /v1/webhooks | List webhooks |
| [**UpdateWebhookV1WebhooksWebhookIdPut**](WebhooksApi.md#updatewebhookv1webhookswebhookidput) | **PUT** /v1/webhooks/{webhook_id} | Update webhook |

<a id="createwebhookv1webhookspost"></a>
# **CreateWebhookV1WebhooksPost**
> WebhookItem CreateWebhookV1WebhooksPost (CreateWebhookRequest createWebhookRequest)

Create webhook

Creates a subscription for alert events (10 alerts). Payload delivered: WebhookPayload(event, data, timestamp) with HMAC FalaAI-Signature. To verify the origin, recompute HMAC-SHA256 of \"timestamp.body\" with your secret.

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
    public class CreateWebhookV1WebhooksPostExample
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
            var apiInstance = new WebhooksApi(httpClient, config, httpClientHandler);
            var createWebhookRequest = new CreateWebhookRequest(); // CreateWebhookRequest | 

            try
            {
                // Create webhook
                WebhookItem result = apiInstance.CreateWebhookV1WebhooksPost(createWebhookRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WebhooksApi.CreateWebhookV1WebhooksPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreateWebhookV1WebhooksPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create webhook
    ApiResponse<WebhookItem> response = apiInstance.CreateWebhookV1WebhooksPostWithHttpInfo(createWebhookRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WebhooksApi.CreateWebhookV1WebhooksPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **createWebhookRequest** | [**CreateWebhookRequest**](CreateWebhookRequest.md) |  |  |

### Return type

[**WebhookItem**](WebhookItem.md)

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

<a id="deletewebhookv1webhookswebhookiddelete"></a>
# **DeleteWebhookV1WebhooksWebhookIdDelete**
> MessageResponse DeleteWebhookV1WebhooksWebhookIdDelete (string webhookId)

Delete webhook

Deletes a webhook subscription by ID.

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
    public class DeleteWebhookV1WebhooksWebhookIdDeleteExample
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
            var apiInstance = new WebhooksApi(httpClient, config, httpClientHandler);
            var webhookId = "webhookId_example";  // string | 

            try
            {
                // Delete webhook
                MessageResponse result = apiInstance.DeleteWebhookV1WebhooksWebhookIdDelete(webhookId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WebhooksApi.DeleteWebhookV1WebhooksWebhookIdDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteWebhookV1WebhooksWebhookIdDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete webhook
    ApiResponse<MessageResponse> response = apiInstance.DeleteWebhookV1WebhooksWebhookIdDeleteWithHttpInfo(webhookId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WebhooksApi.DeleteWebhookV1WebhooksWebhookIdDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **webhookId** | **string** |  |  |

### Return type

[**MessageResponse**](MessageResponse.md)

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

<a id="listwebhooksv1webhooksget"></a>
# **ListWebhooksV1WebhooksGet**
> WebhookListResponse ListWebhooksV1WebhooksGet (int? page = null, int? limit = null)

List webhooks

Lists the authenticated user's webhooks (10 alerts). Paginated. Includes the URL signature secret (always visible to the owner).

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
    public class ListWebhooksV1WebhooksGetExample
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
            var apiInstance = new WebhooksApi(httpClient, config, httpClientHandler);
            var page = 1;  // int? | Pagina (1-indexed) (optional)  (default to 1)
            var limit = 20;  // int? | Itens por pagina (max 100) (optional)  (default to 20)

            try
            {
                // List webhooks
                WebhookListResponse result = apiInstance.ListWebhooksV1WebhooksGet(page, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WebhooksApi.ListWebhooksV1WebhooksGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListWebhooksV1WebhooksGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List webhooks
    ApiResponse<WebhookListResponse> response = apiInstance.ListWebhooksV1WebhooksGetWithHttpInfo(page, limit);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WebhooksApi.ListWebhooksV1WebhooksGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **page** | **int?** | Pagina (1-indexed) | [optional] [default to 1] |
| **limit** | **int?** | Itens por pagina (max 100) | [optional] [default to 20] |

### Return type

[**WebhookListResponse**](WebhookListResponse.md)

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

<a id="updatewebhookv1webhookswebhookidput"></a>
# **UpdateWebhookV1WebhooksWebhookIdPut**
> MessageResponse UpdateWebhookV1WebhooksWebhookIdPut (string webhookId, UpdateWebhookRequest updateWebhookRequest)

Update webhook

Updates the webhook's name/url/events/retry_enabled/active. Valid events: 10 alerts.

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
    public class UpdateWebhookV1WebhooksWebhookIdPutExample
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
            var apiInstance = new WebhooksApi(httpClient, config, httpClientHandler);
            var webhookId = "webhookId_example";  // string | 
            var updateWebhookRequest = new UpdateWebhookRequest(); // UpdateWebhookRequest | 

            try
            {
                // Update webhook
                MessageResponse result = apiInstance.UpdateWebhookV1WebhooksWebhookIdPut(webhookId, updateWebhookRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WebhooksApi.UpdateWebhookV1WebhooksWebhookIdPut: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdateWebhookV1WebhooksWebhookIdPutWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update webhook
    ApiResponse<MessageResponse> response = apiInstance.UpdateWebhookV1WebhooksWebhookIdPutWithHttpInfo(webhookId, updateWebhookRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WebhooksApi.UpdateWebhookV1WebhooksWebhookIdPutWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **webhookId** | **string** |  |  |
| **updateWebhookRequest** | [**UpdateWebhookRequest**](UpdateWebhookRequest.md) |  |  |

### Return type

[**MessageResponse**](MessageResponse.md)

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

