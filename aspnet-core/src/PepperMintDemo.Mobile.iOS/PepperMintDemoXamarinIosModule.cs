using Abp.Modules;
using Abp.Reflection.Extensions;

namespace PepperMintDemo
{
    [DependsOn(typeof(PepperMintDemoXamarinSharedModule))]
    public class PepperMintDemoXamarinIosModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PepperMintDemoXamarinIosModule).GetAssembly());
        }
    }
}