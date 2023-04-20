using System.Threading.Tasks;
using Abp.Application.Services;
using PepperMintDemo.Sessions.Dto;

namespace PepperMintDemo.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
