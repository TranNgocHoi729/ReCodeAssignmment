using Project.Core.Enums;
using System;

namespace Project.Core.Entities
{
    public class Account
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string MobileNumber { get; set; }

        public Gender Gender { get; set; }

        public DateTime DOB { get; set; }

        public string? EmailOptIn { get; set; }
    }
}
