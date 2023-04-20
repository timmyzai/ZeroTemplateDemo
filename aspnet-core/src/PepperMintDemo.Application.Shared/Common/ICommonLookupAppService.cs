using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using PepperMintDemo.Common.Dto;
using PepperMintDemo.Editions.Dto;

namespace PepperMintDemo.Common
{
    public interface ICommonLookupAppService : IApplicationService
    {
        Task<ListResultDto<SubscribableEditionComboboxItemDto>> GetEditionsForCombobox(bool onlyFreeItems = false);

        Task<PagedResultDto<NameValueDto>> FindUsers(FindUsersInput input);

        GetDefaultEditionNameOutput GetDefaultEditionName();
    }
}