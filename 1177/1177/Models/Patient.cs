namespace _1177.Models
{
    public class Patient
    {
        public string PersonNr { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNr { get; set; } = string.Empty;
    }
}
﻿namespace _1177.Models
{
    public class Patient
    {
        public int PersonNr { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNr { get; set; }
    }
}
