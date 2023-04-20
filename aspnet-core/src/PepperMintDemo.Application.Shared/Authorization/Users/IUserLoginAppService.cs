using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using PepperMintDemo.Authorization.Users.Dto;

namespace PepperMintDemo.Authorization.Users
{
    public interface IUserLoginAppService : IApplicationService
    {
        Task<PagedResultDto<UserLoginAttemptDto>> GetUserLoginAttempts(GetLoginAttemptsInput input);
    }
}
