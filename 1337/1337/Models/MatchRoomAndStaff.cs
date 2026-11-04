using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Unicode;

namespace _1337.Models
{
    public class MatchRoomAndStaff
    {
        public void MatchRoomAndStaffMethod()
        {
            var roomBookings = new RoomBook().GetRoomBookings();
            var staffAvailable = new CheckAvailabilityStaff().StaffAvailability();

            



        }
    }
}
