using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using Xunit;

namespace FalaAI.E2e;

public class ContractTest
{
    private static readonly string Root = Path.GetFullPath(Path.Combine("..", "..", "..", "..", "..", "..", ".."));

    private static readonly List<string> Expected = new()
    {
        "POST /v1/audio/transcriptions", "POST /v1/analyze/diagnostic", "POST /v1/analyze/auditoriaRisco",
        "GET /v1/usage/log", "GET /v1/usage/by-key", "GET /v1/webhooks", "POST /v1/webhooks",
        "PUT /v1/webhooks/{webhook_id}", "DELETE /v1/webhooks/{webhook_id}",
        "GET /v1/email-alerts", "POST /v1/email-alerts", "PUT /v1/email-alerts/{alert_id}",
        "DELETE /v1/email-alerts/{alert_id}", "GET /api/version", "GET /v1/health", "HEAD /v1/health"
    };

    [Fact]
    public void OpenapiTemOperacoesEsperadas()
    {
        var spec = Path.Combine(Root, "openapi.json");
        Assert.True(File.Exists(spec), "openapi.json ausente: " + spec);
        var root = JObject.Parse(File.ReadAllText(spec));
        var paths = (JObject)root["paths"]!;
        var ops = new List<string>();
        foreach (var path in paths.Properties())
        {
            var methods = (JObject)path.Value;
            foreach (var m in methods.Properties())
            {
                if (new[] { "get", "post", "put", "delete", "patch", "head" }.Contains(m.Name))
                {
                    ops.Add(m.Name.ToUpperInvariant() + " " + path.Name);
                }
            }
        }
        Assert.Equal(Expected.OrderBy(x => x).ToList(), ops.OrderBy(x => x).ToList());
    }

    [Fact]
    public void SdkCobre100pc()
    {
        var apiDir = Path.Combine(Root, "sdks", "dotnet", "src", "FalaAI.Api", "Api");
        var src = string.Concat(Directory.GetFiles(apiDir, "*.cs").Select(File.ReadAllText));
        foreach (var p in new[] { "/v1/usage/log", "/v1/webhooks", "/v1/email-alerts", "/api/version", "/v1/health", "/v1/analyze/auditoriaRisco" })
        {
            Assert.Contains(p, src);
        }
    }

    [Fact]
    public void ExemplosExistem()
    {
        var files = new[]
        {
            "curl/transcribe.sh", "python/transcribe.py", "nodejs/transcribe.js",
            "curl/auditoria_risco.sh", "python/auditoria_risco.py", "nodejs/auditoria_risco.js",
            "curl/diagnostic.sh", "python/diagnostic.py", "nodejs/diagnostic.js"
        };
        foreach (var f in files)
        {
            Assert.True(File.Exists(Path.Combine(Root, "app", "static", "examples", f)), "exemplo ausente: " + f);
        }
    }
}