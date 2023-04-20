using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using PepperMintDemo.Configure;
using PepperMintDemo.Startup;
using PepperMintDemo.Test.Base;

namespace PepperMintDemo.GraphQL.Tests
{
    [DependsOn(
        typeof(PepperMintDemoGraphQLModule),
        typeof(PepperMintDemoTestBaseModule))]
    public class PepperMintDemoGraphQLTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddAndConfigureGraphQL();

            WindsorRegistrationHelper.CreateServiceProvider(IocManager.IocContainer, services);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PepperMintDemoGraphQLTestModule).GetAssembly());
        }
    }
}