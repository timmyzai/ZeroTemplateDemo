using System.Threading.Tasks;
using Abp.Application.Services;
using PepperMintDemo.MultiTenancy.Payments.Dto;
using PepperMintDemo.MultiTenancy.Payments.Stripe.Dto;

namespace PepperMintDemo.MultiTenancy.Payments.Stripe
{
    public interface IStripePaymentAppService : IApplicationService
    {
        Task ConfirmPayment(StripeConfirmPaymentInput input);

        StripeConfigurationDto GetConfiguration();

        Task<SubscriptionPaymentDto> GetPaymentAsync(StripeGetPaymentInput input);

        Task<string> CreatePaymentSession(StripeCreatePaymentSessionInput input);
    }
}