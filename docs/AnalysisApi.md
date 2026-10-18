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

Analyzes a call transcript and returns six structured blocks: dialogue summary, contact reason, identified action, theme label, predominant sentiment and identified participants with roles, names, confidence and evidence; use it for a fast, generic diagnosis of what happened in a call, and use /v1/analyze/riskAudit instead when the goal is compliance violation auditing. Provide at least one of dialog (primary source: diarized transcript in the format 'Speaker 1: [00:00:00.540 - 00:00:01.139] text', speaker labels accepted in any case as Speaker, Interlocutor, Hablante, Locutor or Orador plus number) or text (plain transcript fallback), each up to 300,000 characters; when dialog is used duration_seconds is required by the schema and, when provided, must be >= the last turn end time. Required: language; optional: model (always 'falaai-diagnostic-1'), audio_events, response_language (language of the results, defaulting to language), participants (up to 10 with interlocutor and optional name and role agent/client/bot, ground truth when the role is informed and otherwise inferred), call_direction (inferred when omitted), client_reference_id (echoed verbatim, charset [A-Za-z0-9 _/:.-], max 60). Returns id, object 'analysis', response_language, analysis with the six blocks, usage (characters, credits_consumed, processing_ms) and html_report (base64 gzip) only when dialog is provided; with text-only input the participant roles are forced to confidence 'low'. Credits are charged per character of the transcript (0.03/char, counted without speaker labels, timestamps and inline expression tokens, minimum 500 characters, plus 50 characters per audio event) and the amount charged is returned in usage.credits_consumed. Stateless: neither the transcript nor the analysis is persisted (only billing and usage metadata is logged), protecting personal data under LGPD.

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

Runs a compliance risk audit on a diarized call transcript, detecting violations and positives, applying the ISO 31000 risk matrix, classifying the conversation into a level and returning the verdict with the applied actions and the NIST/OWASP risk framework enquadramento; use it for compliance and quality audits of company-agent-to-client calls, not for generic conversation summarization. Required fields: dialog (diarized transcript in the format 'Speaker 1: [00:00:00.540 - 00:00:01.139] text', speaker labels accepted in any case as Speaker, Interlocutor, Hablante, Locutor or Orador plus number; plain text is not accepted; max 300,000 characters), duration_seconds (total audio duration in seconds, must be >= the last turn end time) and language plus response_language (only pt-BR, en-US or es-ES). Optional: model (always 'falaai-risk-audit-1'), audio_events (up to 500, each requiring event and start_s), participants (up to 10 with interlocutor and role agent/client/bot, ground truth when provided, else inferred), call_direction (inbound/outbound, inferred when omitted), response_format (only 'v2'), client_reference_id (echoed verbatim, charset [A-Za-z0-9 _/:.-], max 60). Returns response (V2) with meta+usage, participants, verdict with level and applied actions, scores, detections (violations, positives, client alerts), analysis frameworks, timeline, categories_summary, executive summary, scoring explanation and an HTML report (gzip+base64). Credits are charged per character of the spoken transcript (0.09/char, counted without speaker labels and inline expression tokens, minimum 1,000 characters, plus 50 characters per audio event) and a minimum-cost guard may raise the final amount, so response.meta.usage.credits_consumed is the amount actually charged. Stateless: neither the transcript nor the analysis is persisted (only billing and usage metadata is logged), protecting personal data under LGPD.

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

