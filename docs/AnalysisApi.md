# FalaAI.Api.Api.AnalysisApi

All URIs are relative to *https://api01-falaai.action.tec.br*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateDiagnosticV1AnalyzeDiagnosticPost**](AnalysisApi.md#creatediagnosticv1analyzediagnosticpost) | **POST** /v1/analyze/diagnostic | Analyze a call transcript — 5 parallel analyses |
| [**CreateRiskAuditV1AnalyzeRiskAuditPost**](AnalysisApi.md#createriskauditv1analyzeriskauditpost) | **POST** /v1/analyze/riskAudit | Compliance Risk Audit — conversation compliance analysis |

<a id="creatediagnosticv1analyzediagnosticpost"></a>
# **CreateDiagnosticV1AnalyzeDiagnosticPost**
> DiagnosticResponse CreateDiagnosticV1AnalyzeDiagnosticPost (DiagnosticRequest diagnosticRequest)

Analyze a call transcript — 5 parallel analyses

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
    public class CreateDiagnosticV1AnalyzeDiagnosticPostExample
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
            var apiInstance = new AnalysisApi(httpClient, config, httpClientHandler);
            var diagnosticRequest = new DiagnosticRequest(); // DiagnosticRequest | 

            try
            {
                // Analyze a call transcript — 5 parallel analyses
                DiagnosticResponse result = apiInstance.CreateDiagnosticV1AnalyzeDiagnosticPost(diagnosticRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AnalysisApi.CreateDiagnosticV1AnalyzeDiagnosticPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreateDiagnosticV1AnalyzeDiagnosticPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Analyze a call transcript — 5 parallel analyses
    ApiResponse<DiagnosticResponse> response = apiInstance.CreateDiagnosticV1AnalyzeDiagnosticPostWithHttpInfo(diagnosticRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AnalysisApi.CreateDiagnosticV1AnalyzeDiagnosticPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **diagnosticRequest** | [**DiagnosticRequest**](DiagnosticRequest.md) |  |  |

### Return type

[**DiagnosticResponse**](DiagnosticResponse.md)

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

<a id="createriskauditv1analyzeriskauditpost"></a>
# **CreateRiskAuditV1AnalyzeRiskAuditPost**
> RiskAuditV2Response CreateRiskAuditV1AnalyzeRiskAuditPost (RiskAuditRequest riskAuditRequest)

Compliance Risk Audit — conversation compliance analysis

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
    public class CreateRiskAuditV1AnalyzeRiskAuditPostExample
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
            var apiInstance = new AnalysisApi(httpClient, config, httpClientHandler);
            var riskAuditRequest = new RiskAuditRequest(); // RiskAuditRequest | 

            try
            {
                // Compliance Risk Audit — conversation compliance analysis
                RiskAuditV2Response result = apiInstance.CreateRiskAuditV1AnalyzeRiskAuditPost(riskAuditRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AnalysisApi.CreateRiskAuditV1AnalyzeRiskAuditPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreateRiskAuditV1AnalyzeRiskAuditPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Compliance Risk Audit — conversation compliance analysis
    ApiResponse<RiskAuditV2Response> response = apiInstance.CreateRiskAuditV1AnalyzeRiskAuditPostWithHttpInfo(riskAuditRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AnalysisApi.CreateRiskAuditV1AnalyzeRiskAuditPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **riskAuditRequest** | [**RiskAuditRequest**](RiskAuditRequest.md) |  |  |

### Return type

[**RiskAuditV2Response**](RiskAuditV2Response.md)

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

