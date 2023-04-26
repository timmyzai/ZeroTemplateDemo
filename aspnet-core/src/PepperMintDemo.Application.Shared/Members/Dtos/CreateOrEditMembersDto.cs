using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace PepperMintDemo.Members.Dtos
{
    public class CreateOrEditMembersDto : EntityDto<Guid?>
    {

        [Required]
        [StringLength(MembersConsts.MaxNameLength, MinimumLength = MembersConsts.MinNameLength)]
        public string Name { get; set; }

        public long UserId { get; set; }

    }
}