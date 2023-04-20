using Abp.Application.Services.Dto;

namespace PepperMintDemo.Notifications.Dto
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}