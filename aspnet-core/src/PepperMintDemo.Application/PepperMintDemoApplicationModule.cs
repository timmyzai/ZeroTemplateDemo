using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using PepperMintDemo.Authorization;

namespace PepperMintDemo
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(
        typeof(PepperMintDemoApplicationSharedModule),
        typeof(PepperMintDemoCoreModule)
        )]
    public class PepperMintDemoApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PepperMintDemoApplicationModule).GetAssembly());
        }
    }
}