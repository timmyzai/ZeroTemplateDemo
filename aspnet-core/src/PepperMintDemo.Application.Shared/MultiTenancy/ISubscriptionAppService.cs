using System.Threading.Tasks;
using Abp.Application.Services;

namespace PepperMintDemo.MultiTenancy
{
    public interface ISubscriptionAppService : IApplicationService
    {
        Task DisableRecurringPayments();

        Task EnableRecurringPayments();
    }
}
