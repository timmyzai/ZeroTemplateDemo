using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace PepperMintDemo
{
    [DependsOn(typeof(PepperMintDemoClientModule), typeof(AbpAutoMapperModule))]
    public class PepperMintDemoXamarinSharedModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.IsEnabled = false;
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PepperMintDemoXamarinSharedModule).GetAssembly());
        }
    }
}