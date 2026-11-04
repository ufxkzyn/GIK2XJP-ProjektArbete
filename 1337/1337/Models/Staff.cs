namespace _1337.Models
{
    public class Staff
    {
        public string PersonNr { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNr { get; set; }

        public Dictionary<string, string?> Måndag { get; set; } = new();
        public Dictionary<string, string?> Tisdag { get; set; } = new();
        public Dictionary<string, string?> Onsdag { get; set; } = new();
        public Dictionary<string, string?> Torsdag { get; set; } = new();
        public Dictionary<string, string?> Fredag { get; set; } = new();
        public Dictionary<string, string?> Lördag { get; set; } = new();
        public Dictionary<string, string?> Söndag { get; set; } = new();

        public string Roll { get; set; }
    }
}
