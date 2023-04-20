using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace PepperMintDemo.Web.Authentication.JwtBearer
{
    public class AsyncJwtBearerOptions : JwtBearerOptions
    {
        public readonly List<IAsyncSecurityTokenValidator> AsyncSecurityTokenValidators;
        
        private readonly PepperMintDemoAsyncJwtSecurityTokenHandler _defaultAsyncHandler = new PepperMintDemoAsyncJwtSecurityTokenHandler();

        public AsyncJwtBearerOptions()
        {
            AsyncSecurityTokenValidators = new List<IAsyncSecurityTokenValidator>() {_defaultAsyncHandler};
        }
    }

}
