using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FalaAI.Api.Api;
using FalaAI.Api.Model;
using Xunit;

namespace FalaAI.E2e;

public class WriteTest
{
    private const string WName = "E2E Test Webhook";
    private const string WUrl = "https://e2e-falaai.invalid/hook";
    private const string AName = "E2E Test Alert";
    private const string AEmail = "e2e-test@falaai.invalid";

    private static void NonEmpty(string label, string? v)
    {
        Assert.NotNull(v);
        Assert.False(string.IsNullOrEmpty(v), label + " vazio");
    }

    private static void AssertWebhookFull(WebhookItem w, string wid, string name, bool active)
    {
        Assert.Equal(wid, w.Id);
        NonEmpty("user_id", w.UserId);
        Assert.Equal(name, w.Name);
        Assert.Equal(WUrl, w.Url);
        NonEmpty("secret", w.Secret);
        Assert.NotNull(w.Events);
        Assert.Equal(2, w.Events.Count);
        Assert.Equal(active, w.Active);
        Assert.IsType<bool>(w.RetryEnabled);
        Assert.IsType<int>(w.FailureCount);
        NonEmpty("created_at", w.CreatedAt);
        NonEmpty("updated_at", w.UpdatedAt);
    }

    private static void AssertAlertFull(EmailAlertItem a, string aid, string name, bool active)
    {
        Assert.Equal(aid, a.Id);
        NonEmpty("user_id", a.UserId);
        Assert.Equal(name, a.Name);
        Assert.Equal(AEmail, a.Email);
        Assert.NotNull(a.Events);
        Assert.Equal(2, a.Events.Count);
        Assert.Equal(active, a.Active);
        NonEmpty("created_at", a.CreatedAt);
        NonEmpty("updated_at", a.UpdatedAt);
    }

    private static async Task CleanupWebhooks(WebhooksApi api)
    {
        var list = await api.ListWebhooksV1WebhooksGetWithHttpInfoAsync(1, 100);
        foreach (var w in list.Data.Data)
        {
            if (WUrl == w.Url) await api.DeleteWebhookV1WebhooksWebhookIdDeleteWithHttpInfoAsync(w.Id);
        }
    }

    private static async Task CleanupAlerts(EmailAlertsApi api)
    {
        var list = await api.ListEmailAlertsV1EmailAlertsGetWithHttpInfoAsync(1, 100);
        foreach (var a in list.Data.Data)
        {
            if (AEmail == a.Email) await api.DeleteEmailAlertV1EmailAlertsAlertIdDeleteWithHttpInfoAsync(a.Id);
        }
    }

    [Fact]
    public async Task WebhooksCrud()
    {
        var api = new WebhooksApi(E2eConfig.Configuration(E2eConfig.Base()));
        await CleanupWebhooks(api);

        var body = new CreateWebhookRequest(name: WName, url: WUrl, events: new List<WebhookEvent> { WebhookEvent.CreditsLow, WebhookEvent.PaymentFailed });
        var cr = await api.CreateWebhookV1WebhooksPostWithHttpInfoAsync(body);
        E2eLogger.Log("webhooks_create", "POST", "/v1/webhooks", body, cr.Data, $"HTTP {(int)cr.StatusCode}", (int)cr.StatusCode);
        Assert.Equal(HttpStatusCode.OK, cr.StatusCode);
        var wid = cr.Data.Id;
        AssertWebhookFull(cr.Data, wid, WName, true);

        var ub = new UpdateWebhookRequest(name: WName + " (updated)", active: false);
        var ur = await api.UpdateWebhookV1WebhooksWebhookIdPutWithHttpInfoAsync(wid, ub);
        E2eLogger.Log("webhooks_update", "PUT", "/v1/webhooks/" + wid, ub, ur.Data, $"HTTP {(int)ur.StatusCode}", (int)ur.StatusCode);
        Assert.Equal(HttpStatusCode.OK, ur.StatusCode);
        Assert.Equal("updated", ur.Data.Message);

        var list = await api.ListWebhooksV1WebhooksGetWithHttpInfoAsync(1, 100);
        WebhookItem? row = null;
        foreach (var w in list.Data.Data) if (wid == w.Id) row = w;
        Assert.NotNull(row);
        AssertWebhookFull(row!, wid, WName + " (updated)", false);

        var dr = await api.DeleteWebhookV1WebhooksWebhookIdDeleteWithHttpInfoAsync(wid);
        E2eLogger.Log("webhooks_delete", "DELETE", "/v1/webhooks/" + wid, null, dr.Data, $"HTTP {(int)dr.StatusCode}", (int)dr.StatusCode);
        Assert.Equal(HttpStatusCode.OK, dr.StatusCode);
        Assert.Equal("deleted", dr.Data.Message);

        var list2 = await api.ListWebhooksV1WebhooksGetWithHttpInfoAsync(1, 100);
        foreach (var w in list2.Data.Data) Assert.NotEqual(wid, w.Id);
    }

    [Fact]
    public async Task EmailAlertsCrud()
    {
        var api = new EmailAlertsApi(E2eConfig.Configuration(E2eConfig.Base()));
        await CleanupAlerts(api);

        var body = new CreateEmailAlertRequest(name: AName, email: AEmail, events: new List<EmailEvent> { EmailEvent.CreditsLow, EmailEvent.PaymentFailed });
        var cr = await api.CreateEmailAlertV1EmailAlertsPostWithHttpInfoAsync(body);
        E2eLogger.Log("email_alerts_create", "POST", "/v1/email-alerts", body, cr.Data, $"HTTP {(int)cr.StatusCode}", (int)cr.StatusCode);
        Assert.Equal(HttpStatusCode.OK, cr.StatusCode);
        var aid = cr.Data.Id;
        AssertAlertFull(cr.Data, aid, AName, true);

        var ub = new UpdateEmailAlertRequest(name: AName + " (updated)", active: false);
        var ur = await api.UpdateEmailAlertV1EmailAlertsAlertIdPutWithHttpInfoAsync(aid, ub);
        E2eLogger.Log("email_alerts_update", "PUT", "/v1/email-alerts/" + aid, ub, ur.Data, $"HTTP {(int)ur.StatusCode}", (int)ur.StatusCode);
        Assert.Equal(HttpStatusCode.OK, ur.StatusCode);
        Assert.Equal("updated", ur.Data.Message);

        var list = await api.ListEmailAlertsV1EmailAlertsGetWithHttpInfoAsync(1, 100);
        EmailAlertItem? row = null;
        foreach (var a in list.Data.Data) if (aid == a.Id) row = a;
        Assert.NotNull(row);
        AssertAlertFull(row!, aid, AName + " (updated)", false);

        var dr = await api.DeleteEmailAlertV1EmailAlertsAlertIdDeleteWithHttpInfoAsync(aid);
        E2eLogger.Log("email_alerts_delete", "DELETE", "/v1/email-alerts/" + aid, null, dr.Data, $"HTTP {(int)dr.StatusCode}", (int)dr.StatusCode);
        Assert.Equal(HttpStatusCode.OK, dr.StatusCode);
        Assert.Equal("deleted", dr.Data.Message);

        var list2 = await api.ListEmailAlertsV1EmailAlertsGetWithHttpInfoAsync(1, 100);
        foreach (var a in list2.Data.Data) Assert.NotEqual(aid, a.Id);
    }
}