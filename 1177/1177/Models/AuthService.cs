using System.IO;
using System.Text.Json;
using _1337.Models;

namespace _1337.Models
{
    public static class AuthService
    {
        public static async Task<bool> ValidateAsync<T>(
            string relativePath, 
            string targetKey, 
            Func<T, bool> validate)
        {
            string path = Path.Combine(AppContext.BaseDirectory, relativePath);

            if (!File.Exists(path))
            {
                return false;
            }

            string json = await File.ReadAllTextAsync(path);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            
     
            var dict = JsonSerializer.Deserialize<Dictionary<string, T>>(json, options);

  
            if (dict != null && dict.TryGetValue(targetKey, out var item))
            {
                return validate(item);
            }

            return false;
        }
    }
}