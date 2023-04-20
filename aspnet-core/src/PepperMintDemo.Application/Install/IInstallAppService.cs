using System.Threading.Tasks;
using Abp.Application.Services;
using PepperMintDemo.Install.Dto;

namespace PepperMintDemo.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}