using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace FalaAI.E2e;

public static class E2eLogger
{
    public static void Log(string name, string method, string path, object? payload, object? response, string result, int status)
    {
        var safe = System.Text.RegularExpressions.Regex.Replace(name.ToUpperInvariant(), "[^A-Z0-9]+", "_");
        var root = Path.GetFullPath(Path.Combine("..", "..", "..", "..", "..", "..", ".."));
        var dir = Path.Combine(root, "sdks", "dotnet", "tests", "e2e", "logs", safe);
        Directory.CreateDirectory(dir);
        var ts = DateTime.UtcNow.ToString("yyyyMMdd_HHmmss");
        var file = Path.Combine(dir, $"{safe}_{ts}.log");
        var sb = new StringBuilder();
        sb.Append(new string('=', 70)).Append('\n');
        sb.Append("TESTE: ").Append(method).Append(' ').Append(path).Append('\n');
        sb.Append("DATA: ").Append(DateTime.UtcNow.ToString("o")).Append('\n');
        sb.Append(new string('=', 70)).Append("\n\n");
        sb.Append("--- PAYLOAD (enviado) ---\n").Append(Enc(payload)).Append("\n\n");
        sb.Append("--- RESPOSTA (saida do SDK) ---\n").Append("HTTP: ").Append(status).Append('\n').Append(Enc(response)).Append("\n\n");
        sb.Append("--- RESULTADO ---\n").Append(result).Append('\n');
        File.WriteAllText(file, sb.ToString(), new UTF8Encoding(false));
    }

    private static string Enc(object? v)
    {
        if (v == null) return "(sem dados)";
        try
        {
            return JsonConvert.SerializeObject(v, Formatting.Indented);
        }
        catch (Exception)
        {
            return v.ToString() ?? "(sem dados)";
        }
    }
}