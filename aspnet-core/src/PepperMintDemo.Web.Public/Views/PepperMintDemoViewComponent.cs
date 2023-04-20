using Abp.AspNetCore.Mvc.ViewComponents;

namespace PepperMintDemo.Web.Public.Views
{
    public abstract class PepperMintDemoViewComponent : AbpViewComponent
    {
        protected PepperMintDemoViewComponent()
        {
            LocalizationSourceName = PepperMintDemoConsts.LocalizationSourceName;
        }
    }
}