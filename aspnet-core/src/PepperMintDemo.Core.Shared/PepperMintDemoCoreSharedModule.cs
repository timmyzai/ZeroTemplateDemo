using Abp.Modules;
using Abp.Reflection.Extensions;

namespace PepperMintDemo
{
    public class PepperMintDemoCoreSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PepperMintDemoCoreSharedModule).GetAssembly());
        }
    }
}