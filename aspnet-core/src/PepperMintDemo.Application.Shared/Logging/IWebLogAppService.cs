using Abp.Application.Services;
using PepperMintDemo.Dto;
using PepperMintDemo.Logging.Dto;

namespace PepperMintDemo.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
