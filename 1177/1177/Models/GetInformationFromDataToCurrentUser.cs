using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace _1337.Models
{
    public class GetInformationFromDataToCurrentUser
    {
        public void GetUserInformation(string userId, string dataPath)
        {
            var usersData = JsonNode.Parse(File.ReadAllText(dataPath));

            JsonNode? CurrentUser = null;
            foreach (var person in usersData.AsArray())
            {
                if (person["PersonNr"].ToString() == userId)
                {
                    CurrentUser = person;
                    break;
                }
            }

            string Tojson = JsonSerializer.Serialize(CurrentUser, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("Data/CurrentUser.json", Tojson);
        }
    }
}