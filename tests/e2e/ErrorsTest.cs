using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FalaAI.E2e;

public class ErrorsTest
{
    private static async Task<HttpResponseMessage> Post(string path, string json)
    {
        using var http = new HttpClient();
        var req = new HttpRequestMessage(HttpMethod.Post, E2eConfig.Base() + path)
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };
        req.Headers.Add("Authorization", "Bearer " + E2eConfig.Key());
        return await http.SendAsync(req);
    }

    private static async Task<HttpResponseMessage> Get(string path, string auth)
    {
        using var http = new HttpClient();
        var req = new HttpRequestMessage(HttpMethod.Get, E2eConfig.Base() + path);
        req.Headers.Add("Authorization", auth);
        return await http.SendAsync(req);
    }

    [Fact]
    public async Task InvalidKey401()
    {
        var r = await Get("/v1/usage/log?page=1&limit=1", "Bearer fai_chave_invalida_000");
        var body = await r.Content.ReadAsStringAsync();
        E2eLogger.Log("errors_401", "GET", "/v1/usage/log", null, body, $"HTTP {(int)r.StatusCode}", (int)r.StatusCode);
        Assert.Equal(HttpStatusCode.Unauthorized, r.StatusCode);
    }

    [Fact]
    public async Task DiagnosticMissing422()
    {
        var body = "{\"language\":\"pt-BR\",\"dialog\":\"Speaker 1: ola\"}";
        var r = await Post("/v1/analyze/diagnostic", body);
        var outBody = await r.Content.ReadAsStringAsync();
        E2eLogger.Log("errors_422_diag", "POST", "/v1/analyze/diagnostic", body, outBody, $"HTTP {(int)r.StatusCode}", (int)r.StatusCode);
        Assert.Equal(HttpStatusCode.UnprocessableEntity, r.StatusCode);
    }

    [Fact]
    public async Task AuditoriaMissing422()
    {
        var body = "{\"language\":\"pt-BR\",\"dialog\":\"Speaker 1: ola\"}";
        var r = await Post("/v1/analyze/auditoriaRisco", body);
        var outBody = await r.Content.ReadAsStringAsync();
        E2eLogger.Log("errors_422_aud", "POST", "/v1/analyze/auditoriaRisco", body, outBody, $"HTTP {(int)r.StatusCode}", (int)r.StatusCode);
        Assert.Equal(HttpStatusCode.UnprocessableEntity, r.StatusCode);
    }

    [Fact]
    public async Task ExtraForbidden422()
    {
        var body = "{\"dialog\":\"Speaker 1: ola\",\"language\":\"pt-BR\",\"response_language\":\"pt-BR\",\"duration_seconds\":10,\"threshold_multiplier\":1}";
        var r = await Post("/v1/analyze/auditoriaRisco", body);
        var outBody = await r.Content.ReadAsStringAsync();
        E2eLogger.Log("errors_422_extra", "POST", "/v1/analyze/auditoriaRisco", body, outBody, $"HTTP {(int)r.StatusCode}", (int)r.StatusCode);
        Assert.Equal(HttpStatusCode.UnprocessableEntity, r.StatusCode);
    }

    [Fact]
    public async Task AuditoriaLanguage400()
    {
        var body = "{\"dialog\":\"Speaker 1: ola\",\"language\":\"xx\",\"response_language\":\"pt-BR\",\"duration_seconds\":10}";
        var r = await Post("/v1/analyze/auditoriaRisco", body);
        var outBody = await r.Content.ReadAsStringAsync();
        E2eLogger.Log("errors_400_aud", "POST", "/v1/analyze/auditoriaRisco", body, outBody, $"HTTP {(int)r.StatusCode}", (int)r.StatusCode);
        Assert.Equal(HttpStatusCode.BadRequest, r.StatusCode);
    }

    [Fact]
    public async Task DiagnosticLanguage400()
    {
        var body = "{\"dialog\":\"Speaker 1: ola\",\"language\":\"xx\",\"duration_seconds\":10}";
        var r = await Post("/v1/analyze/diagnostic", body);
        var outBody = await r.Content.ReadAsStringAsync();
        E2eLogger.Log("errors_400_diag", "POST", "/v1/analyze/diagnostic", body, outBody, $"HTTP {(int)r.StatusCode}", (int)r.StatusCode);
        Assert.Equal(HttpStatusCode.BadRequest, r.StatusCode);
    }
}