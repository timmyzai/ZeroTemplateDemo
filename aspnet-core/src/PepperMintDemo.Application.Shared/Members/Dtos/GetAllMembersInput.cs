using Abp.Application.Services.Dto;
using System;

namespace PepperMintDemo.Members.Dtos
{
    public class GetAllMembersInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string NameFilter { get; set; }

        public string UserNameFilter { get; set; }

    }
}