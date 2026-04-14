using System.Security.Cryptography;
using System.Text;

namespace SpecBuilder.Infrastructure;

public static class Hashing
{
    public static string Sha256(params string?[] parts)
    {
        using var sha = SHA256.Create();
        var data = string.Join('\u001f', parts.Select(p => p ?? string.Empty));
        var bytes = Encoding.UTF8.GetBytes(data);
        var hash = sha.ComputeHash(bytes);
        return Convert.ToHexString(hash);
    }
}
