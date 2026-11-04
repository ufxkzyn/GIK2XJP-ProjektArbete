using System.Text.Json;
using System.Text.Json.Nodes;

namespace _1337.Models
{
    public class GetUserName
    {
        public (DateTime Date, string Name) GetUserNameMethod()
        {
            var CurrentUser = JsonNode.Parse(File.ReadAllText("Data/CurrentUser.json"));

            DateTime CurrentDate = DateTime.Now;
            var CurrentUserName = $"{CurrentUser?["FirstName"]?.ToString() ?? "Användare"} {CurrentUser?["LastName"]?.ToString() ?? ""}".Trim();

            return (CurrentDate, CurrentUserName);
        }
    }
}