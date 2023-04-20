using Abp.AspNetCore.Mvc.Authorization;
using PepperMintDemo.Authorization;
using PepperMintDemo.Storage;
using Abp.BackgroundJobs;

namespace PepperMintDemo.Web.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Users)]
    public class UsersController : UsersControllerBase
    {
        public UsersController(IBinaryObjectManager binaryObjectManager, IBackgroundJobManager backgroundJobManager)
            : base(binaryObjectManager, backgroundJobManager)
        {
        }
    }
}