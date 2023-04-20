using Abp.Modules;
using Abp.Reflection.Extensions;

namespace PepperMintDemo
{
    [DependsOn(typeof(PepperMintDemoCoreSharedModule))]
    public class PepperMintDemoApplicationSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PepperMintDemoApplicationSharedModule).GetAssembly());
        }
    }
}