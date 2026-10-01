# FalaAI.Api.Model.WebhookItem

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** | Webhook id | 
**UserId** | **string** | Owner user id | 
**Name** | **string** | Webhook name | 
**Url** | **string** | Destination URL | 
**Secret** | **string** | HMAC signing secret | 
**Events** | **List&lt;string&gt;** | Subscribed events | 
**Active** | **bool** | Is active | 
**RetryEnabled** | **bool** | Retry enabled | 
**LastDeliveryAt** | **string** | ISO 8601 of last delivery | [optional] 
**LastStatus** | **int?** | Last HTTP status delivered | [optional] 
**FailureCount** | **int** | Consecutive failures | [optional] [default to 0]
**CreatedAt** | **string** | ISO 8601 created | 
**UpdatedAt** | **string** | ISO 8601 updated | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

