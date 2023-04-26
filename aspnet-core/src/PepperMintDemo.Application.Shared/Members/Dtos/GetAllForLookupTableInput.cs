using Abp.Application.Services.Dto;

namespace PepperMintDemo.Members.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}