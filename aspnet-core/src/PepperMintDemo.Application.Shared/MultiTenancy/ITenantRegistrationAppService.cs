using System.Threading.Tasks;
using Abp.Application.Services;
using PepperMintDemo.Editions.Dto;
using PepperMintDemo.MultiTenancy.Dto;

namespace PepperMintDemo.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}