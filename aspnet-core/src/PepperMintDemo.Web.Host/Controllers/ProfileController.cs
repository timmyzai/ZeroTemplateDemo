using Abp.AspNetCore.Mvc.Authorization;
using PepperMintDemo.Authorization.Users.Profile;
using PepperMintDemo.Graphics;
using PepperMintDemo.Storage;

namespace PepperMintDemo.Web.Controllers
{
    [AbpMvcAuthorize]
    public class ProfileController : ProfileControllerBase
    {
        public ProfileController(
            ITempFileCacheManager tempFileCacheManager,
            IProfileAppService profileAppService,
            IImageFormatValidator imageFormatValidator) :
            base(tempFileCacheManager, profileAppService, imageFormatValidator)
        {
        }
    }
}