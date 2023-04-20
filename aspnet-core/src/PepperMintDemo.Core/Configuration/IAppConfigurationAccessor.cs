using Microsoft.Extensions.Configuration;

namespace PepperMintDemo.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
