using Abp.Modules;
using PepperMintDemo.Test.Base;

namespace PepperMintDemo.Tests
{
    [DependsOn(typeof(PepperMintDemoTestBaseModule))]
    public class PepperMintDemoTestModule : AbpModule
    {
       
    }
}
