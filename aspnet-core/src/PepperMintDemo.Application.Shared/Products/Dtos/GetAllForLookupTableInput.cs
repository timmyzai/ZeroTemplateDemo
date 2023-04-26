using Abp.Application.Services.Dto;

namespace PepperMintDemo.Products.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}