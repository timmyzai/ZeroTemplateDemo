using Abp.AutoMapper;
using PepperMintDemo.Organizations.Dto;

namespace PepperMintDemo.Models.Users
{
    [AutoMapFrom(typeof(OrganizationUnitDto))]
    public class OrganizationUnitModel : OrganizationUnitDto
    {
        public bool IsAssigned { get; set; }
    }
}