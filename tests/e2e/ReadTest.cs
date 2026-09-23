using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FalaAI.Api.Api;
using FalaAI.Api.Model;
using Xunit;

namespace FalaAI.E2e;

public class ReadTest
{
    private static void NonEmpty(string label, string? v)
    {
        Assert.NotNull(v);
        Assert.False(string.IsNullOrEmpty(v), label + " vazio");
    }

    [Fact]
    public async Task HealthGet()
    {
        var api = new HealthApi(E2eConfig.Configuration(E2eConfig.Base()));
        var r = await api.HealthCheckWithHttpInfoAsync();
        E2eLogger.Log("health_get", "GET", "/v1/health", null, r.Data, $"HTTP {(int)r.StatusCode}", (int)r.StatusCode);
        Assert.Equal(HttpStatusCode.OK, r.StatusCode);
        var p = r.Data;
        Assert.Equal("ok", p.Status);
        NonEmpty("version", p.VarVersion);
        Assert.True(p.UptimeSeconds >= 0);
        Assert.IsType<bool>(p.Database);
        NonEmpty("phase", p.Phase);
        NonEmpty("launch_date", p.LaunchDate);
    }

    [Fact]
    public async Task HealthHead()
    {
        using var http = new HttpClient();
        var req = new HttpRequestMessage(HttpMethod.Head, E2eConfig.Base() + "/v1/health");
        var res = await http.SendAsync(req);
        E2eLogger.Log("health_head", "HEAD", "/v1/health", null, new { status = (int)res.StatusCode }, $"HTTP {(int)res.StatusCode}", (int)res.StatusCode);
        Assert.Equal(HttpStatusCode.OK, res.StatusCode);
    }

    [Fact]
    public async Task Version()
    {
        var api = new VersionApi(E2eConfig.Configuration(E2eConfig.Base()));
        var r = await api.GetVersionApiVersionGetWithHttpInfoAsync();
        E2eLogger.Log("version", "GET", "/api/version", null, r.Data, $"HTTP {(int)r.StatusCode}", (int)r.StatusCode);
        Assert.Equal(HttpStatusCode.OK, r.StatusCode);
        Assert.Equal("FalaAI API", r.Data.Service);
        NonEmpty("version", r.Data.VarVersion);
        NonEmpty("deploy_date", r.Data.DeployDate);
    }

    [Fact]
    public async Task UsageLog()
    {
        var api = new UsageApi(E2eConfig.Configuration(E2eConfig.Base()));
        var r = await api.GetUsageLogV1UsageLogGetWithHttpInfoAsync(1, 5);
        E2eLogger.Log("usage_log", "GET", "/v1/usage/log", new { page = 1, limit = 5 }, r.Data, $"HTTP {(int)r.StatusCode}", (int)r.StatusCode);
        Assert.Equal(HttpStatusCode.OK, r.StatusCode);
        Assert.Equal(1, r.Data.Page);
        Assert.Equal(5, r.Data.Limit);
        Assert.NotNull(r.Data.Data);
        foreach (var it in r.Data.Data)
        {
            NonEmpty("id", it.Id);
            NonEmpty("endpoint", it.Endpoint);
            Assert.IsType<int>(it.CreditsCost);
            NonEmpty("status", it.Status);
            Assert.IsType<int>(it.ErrorsCount);
            NonEmpty("created_at", it.CreatedAt);
        }
    }

    [Fact]
    public async Task UsageByKey()
    {
        var api = new UsageApi(E2eConfig.Configuration(E2eConfig.Base()));
        var r = await api.GetUsageByKeyV1UsageByKeyGetWithHttpInfoAsync();
        E2eLogger.Log("usage_by_key", "GET", "/v1/usage/by-key", null, r.Data, $"HTTP {(int)r.StatusCode}", (int)r.StatusCode);
        Assert.Equal(HttpStatusCode.OK, r.StatusCode);
        Assert.NotNull(r.Data);
        foreach (var it in r.Data)
        {
            NonEmpty("key_id", it.KeyId);
            Assert.NotNull(it.KeyName);
            Assert.IsType<int>(it.TotalCredits);
            Assert.IsType<int>(it.RequestCount);
        }
    }

    [Fact]
    public async Task WebhooksList()
    {
        var api = new WebhooksApi(E2eConfig.Configuration(E2eConfig.Base()));
        var r = await api.ListWebhooksV1WebhooksGetWithHttpInfoAsync(1, 5);
        E2eLogger.Log("webhooks_list", "GET", "/v1/webhooks", new { page = 1, limit = 5 }, r.Data, $"HTTP {(int)r.StatusCode}", (int)r.StatusCode);
        Assert.Equal(HttpStatusCode.OK, r.StatusCode);
        Assert.Equal(1, r.Data.Page);
        Assert.Equal(5, r.Data.Limit);
        Assert.NotNull(r.Data.Data);
        foreach (var w in r.Data.Data)
        {
            NonEmpty("id", w.Id);
            NonEmpty("user_id", w.UserId);
            Assert.NotNull(w.Name);
            NonEmpty("url", w.Url);
            Assert.NotNull(w.Secret);
            Assert.NotNull(w.Events);
            Assert.IsType<bool>(w.Active);
            Assert.IsType<bool>(w.RetryEnabled);
            Assert.IsType<int>(w.FailureCount);
            NonEmpty("created_at", w.CreatedAt);
            NonEmpty("updated_at", w.UpdatedAt);
        }
    }

    [Fact]
    public async Task EmailAlertsList()
    {
        var api = new EmailAlertsApi(E2eConfig.Configuration(E2eConfig.Base()));
        var r = await api.ListEmailAlertsV1EmailAlertsGetWithHttpInfoAsync(1, 5);
        E2eLogger.Log("email_alerts_list", "GET", "/v1/email-alerts", new { page = 1, limit = 5 }, r.Data, $"HTTP {(int)r.StatusCode}", (int)r.StatusCode);
        Assert.Equal(HttpStatusCode.OK, r.StatusCode);
        Assert.Equal(1, r.Data.Page);
        Assert.Equal(5, r.Data.Limit);
        Assert.NotNull(r.Data.Data);
        foreach (var a in r.Data.Data)
        {
            NonEmpty("id", a.Id);
            NonEmpty("user_id", a.UserId);
            Assert.NotNull(a.Name);
            NonEmpty("email", a.Email);
            Assert.NotNull(a.Events);
            Assert.IsType<bool>(a.Active);
            NonEmpty("created_at", a.CreatedAt);
            NonEmpty("updated_at", a.UpdatedAt);
        }
    }
}