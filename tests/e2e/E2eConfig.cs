using System;
using System.Collections.Generic;
using System.IO;
using FalaAI.Api.Client;

namespace FalaAI.E2e;

public static class E2eConfig
{
    private static Dictionary<string, string>? _env;

    private static Dictionary<string, string> Env()
    {
        if (_env == null)
        {
            _env = new Dictionary<string, string>();
            var p = Path.Combine("..", ".env.e2e");
            if (File.Exists(p))
            {
                foreach (var line in File.ReadAllLines(p))
                {
                    var t = line.Trim();
                    if (t.Length == 0 || t.StartsWith("#") || !t.Contains("=")) continue;
                    var i = t.IndexOf('=');
                    _env[t.Substring(0, i).Trim()] = t.Substring(i + 1).Trim();
                }
            }
        }
        return _env;
    }

    private static string? Get(string name)
    {
        var v = Environment.GetEnvironmentVariable(name);
        if (!string.IsNullOrEmpty(v)) return v;
        return Env().TryGetValue(name, out var e) ? e : null;
    }

    public static string Base()
    {
        return Get("FALAAI_E2E_BASE") ?? Get("FALAAI_LOCAL_URL") ?? "http://localhost:8002";
    }

    public static string Prod()
    {
        return Get("FALAAI_PROD_URL") ?? "https://api01-falaai.action.tec.br";
    }

    public static string Key()
    {
        return Get("FALAAI_TEST_KEY") ?? throw new InvalidOperationException("FALAAI_TEST_KEY nao definida");
    }

    public static string Audio()
    {
        return Get("FALAAI_E2E_AUDIO") ?? throw new InvalidOperationException("FALAAI_E2E_AUDIO nao definida");
    }

    public static Configuration Configuration(string baseUrl)
    {
        return Configuration(baseUrl, Key());
    }

    public static Configuration Configuration(string baseUrl, string apiKey)
    {
        var cfg = new Configuration { BasePath = baseUrl, AccessToken = apiKey };
        return cfg;
    }
}