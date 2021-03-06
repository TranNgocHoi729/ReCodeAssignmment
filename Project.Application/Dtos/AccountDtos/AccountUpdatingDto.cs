using Project.Core.Enums;
using System;

namespace Project.Application.Dtos.AccountDtos
{
    public class  AccountUpdatingDto
    {
        public string Name { get; set; }

        public string MobileNumber { get; set; }

        public Gender Gender { get; set; }

        public DateTime DOB { get; set; }

        public string? EmailOptIn { get; set; }
    }
}
