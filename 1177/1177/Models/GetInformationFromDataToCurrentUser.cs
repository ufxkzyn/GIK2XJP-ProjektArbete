using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace _1337.Models
{
    public class GetInformationFromDataToCurrentUser
    {
        public void GetUserInformation(string userId, string dataPath)
        {

            var usersData = JsonNode.Parse(File.ReadAllText(dataPath))?.AsObject();

        
            if (usersData != null && usersData.TryGetPropertyValue(userId, out JsonNode? currentUser))
            {
                string Tojson = JsonSerializer.Serialize(currentUser, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText("Data/CurrentUser.json", Tojson);
            }
        }

    }
}
