using Abp.Modules;
using Abp.Reflection.Extensions;

namespace PepperMintDemo
{
    public class PepperMintDemoClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PepperMintDemoClientModule).GetAssembly());
        }
    }
}
