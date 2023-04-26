using Abp.Application.Services.Dto;
using System;

namespace PepperMintDemo.Members.Dtos
{
    public class GetAllMembersForExcelInput
    {
        public string Filter { get; set; }

        public string NameFilter { get; set; }

        public string UserNameFilter { get; set; }

    }
}