using System;
using Abp.Application.Services.Dto;

namespace PepperMintDemo.Members.Dtos
{
    public class MembersDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public long UserId { get; set; }

    }
}