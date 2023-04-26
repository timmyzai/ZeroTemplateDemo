using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace PepperMintDemo.Members.Dtos
{
    public class GetMembersForEditOutput
    {
        public CreateOrEditMembersDto Members { get; set; }

        public string UserName { get; set; }

    }
}