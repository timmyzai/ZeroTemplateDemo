using Abp.Application.Services;
using Abp.Application.Services.Dto;
using PepperMintDemo.Authorization.Permissions.Dto;

namespace PepperMintDemo.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
