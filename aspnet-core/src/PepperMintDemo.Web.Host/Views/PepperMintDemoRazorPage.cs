using Abp.AspNetCore.Mvc.Views;

namespace PepperMintDemo.Web.Views
{
    public abstract class PepperMintDemoRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected PepperMintDemoRazorPage()
        {
            LocalizationSourceName = PepperMintDemoConsts.LocalizationSourceName;
        }
    }
}
