using System.Threading.Tasks;
using Abp.Application.Services;
using PepperMintDemo.Configuration.Host.Dto;

namespace PepperMintDemo.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
