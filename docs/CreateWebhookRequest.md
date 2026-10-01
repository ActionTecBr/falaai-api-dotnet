# FalaAI.Api.Model.CreateWebhookRequest

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Nome identificador do webhook | 
**Url** | **string** | URL HTTPS que recebera POST com HMAC FalaAI-Signature | 
**Events** | [**List&lt;WebhookEvent&gt;**](WebhookEvent.md) | Eventos subscritos (10 alertas) | 
**RetryEnabled** | **bool** | Retry exponencial 5 tentativas quando true (false&#x3D;1 tentativa) | [optional] [default to false]

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

