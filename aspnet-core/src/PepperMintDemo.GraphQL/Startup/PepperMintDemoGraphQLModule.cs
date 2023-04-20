using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace PepperMintDemo.Startup
{
    [DependsOn(typeof(PepperMintDemoCoreModule))]
    public class PepperMintDemoGraphQLModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PepperMintDemoGraphQLModule).GetAssembly());
        }

        public override void PreInitialize()
        {
            base.PreInitialize();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }
    }
}