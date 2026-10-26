using System.IO;
using System.Text.Json;
using _1337.Models;

namespace _1337.Models
{
    // Exists to decouple the JSON file and the login method.
    public static class AuthService
    {
        public static async Task<bool> ValidateAsync<T>(string relativePath, Func<T, bool> match)
        {
            string path = Path.Combine(AppContext.BaseDirectory, relativePath);

            if (!File.Exists(path))
            {
                return false;
            }

            string json = await File.ReadAllTextAsync(path);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var list = JsonSerializer.Deserialize<List<T>>(json, options);

            return list?.Any(match) ?? false;
        }
    }
}