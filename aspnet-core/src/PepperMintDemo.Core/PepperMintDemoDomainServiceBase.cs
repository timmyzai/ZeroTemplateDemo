using Abp.Domain.Services;

namespace PepperMintDemo
{
    public abstract class PepperMintDemoDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected PepperMintDemoDomainServiceBase()
        {
            LocalizationSourceName = PepperMintDemoConsts.LocalizationSourceName;
        }
    }
}
