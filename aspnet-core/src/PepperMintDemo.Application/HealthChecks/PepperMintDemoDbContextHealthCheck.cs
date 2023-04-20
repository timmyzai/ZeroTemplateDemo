using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using PepperMintDemo.EntityFrameworkCore;

namespace PepperMintDemo.HealthChecks
{
    public class PepperMintDemoDbContextHealthCheck : IHealthCheck
    {
        private readonly DatabaseCheckHelper _checkHelper;

        public PepperMintDemoDbContextHealthCheck(DatabaseCheckHelper checkHelper)
        {
            _checkHelper = checkHelper;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            if (_checkHelper.Exist("db"))
            {
                return Task.FromResult(HealthCheckResult.Healthy("PepperMintDemoDbContext connected to database."));
            }

            return Task.FromResult(HealthCheckResult.Unhealthy("PepperMintDemoDbContext could not connect to database"));
        }
    }
}
