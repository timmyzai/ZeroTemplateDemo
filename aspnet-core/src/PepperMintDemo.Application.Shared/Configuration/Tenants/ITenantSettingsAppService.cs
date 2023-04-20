using System.Threading.Tasks;
using Abp.Application.Services;
using PepperMintDemo.Configuration.Tenants.Dto;

namespace PepperMintDemo.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
