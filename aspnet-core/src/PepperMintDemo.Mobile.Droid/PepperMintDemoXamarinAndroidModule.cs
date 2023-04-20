using Abp.Modules;
using Abp.Reflection.Extensions;

namespace PepperMintDemo
{
    [DependsOn(typeof(PepperMintDemoXamarinSharedModule))]
    public class PepperMintDemoXamarinAndroidModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PepperMintDemoXamarinAndroidModule).GetAssembly());
        }
    }
}